using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Ionic.Zlib;
using LanguageExt;
using LanguageExt.UnsafeValueAccess;
using TLSharp.Auth;
using TLSharp.Rpc;
using TLSharp.Rpc.Functions;
using TLSharp.Rpc.Types;
using TLSharp.Utils;
using static LanguageExt.Prelude;

namespace TLSharp.Rpc
{
    class TlTransport
    {
        private readonly MtProtoCipherTransport _transport;
        private readonly Session _session;
        readonly Task _receiveLoopTask;

        readonly List<long> _needConfirmation = new List<long>();

        public TlTransport(MtProtoCipherTransport transport, Session session)
        {
            _transport = transport;
            _session = session;
            _receiveLoopTask = Task.Run(ReceiveLoop);
        }


        async Task SendConfirmations()
        {
            if (_needConfirmation.Count == 0) return;

            var ack = (MsgsAck) new MsgsAck.Tag(_needConfirmation.ToArr());
            var msgId = _session.GetNewMessageId();
            await _transport.Send(messageId: msgId, incSeqNum: false, dto: ack);

            _needConfirmation.Clear();
        }

        readonly Dictionary<long, TaskCompletionSource<RpcResult>> _rpcFlow =
            new Dictionary<long, TaskCompletionSource<RpcResult>>();


        readonly SemaphoreSlim _rpcQueue = new SemaphoreSlim(1, 1);

        async Task<T> WithRpcQueue<T>(Func<Task<T>> func)
        {
            await _rpcQueue.WaitAsync();
            try
            {
                return await func();
            }
            finally
            {
                _rpcQueue.Release(1);
            }
        }

        public async Task<T> Call<T>(ITlFunc<T> request)
        {
            async Task CheckReceiveLoop()
            {
                if (_receiveLoopTask.IsFaulted) await _receiveLoopTask;
            }

            while (true)
            {
                await CheckReceiveLoop();

                var respTask = await WithRpcQueue(async () =>
                {
                    await SendConfirmations();

                    var msgId = _session.GetNewMessageId();
                    var tcs = new TaskCompletionSource<RpcResult>();
                    _rpcFlow[msgId] = tcs;

                    await _transport.Send(messageId: msgId, incSeqNum: true, dto: request);
                    return tcs.Task;
                });

                await Task.WhenAny(_receiveLoopTask, respTask);
                await CheckReceiveLoop();

                var resp = await respTask;
                if (resp.IsSuccess) return resp.Body.Apply(request.DeserializeResult);

                if (!resp.IsFail) throw new Exception("WTF");
                var exc = resp.Exception;

                if (exc is TlBadSalt) continue;
                throw exc;
            }
        }

        async Task ReceiveLoop()
        {
            while (true)
            {
                var msgBody = await _transport.Receive();
                var msg = TlSystemMessageHandler.ReadMsg(msgBody);
                _needConfirmation.Add(msg.Id);

                var callResults = msg.Apply(TlSystemMessageHandler.Handle(_session));
                callResults.Iter(res => _rpcFlow[res.Id].SetResult(res));
            }
        }

        async Task<Pong> SendPingAsync()
        {
            var ping = new Ping(Helpers.GenerateRandomLong());
            return await Call(ping);
        }
    }
}
