using System;
using System.Collections.Concurrent;
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
        readonly MtProtoCipherTransport _transport;
        readonly Session _session;
        readonly ISessionStore _sessionStore;
        readonly TaskQueue _rpcQueue = new TaskQueue();
        readonly ConcurrentStack<long> _unconfirmedMsgIds = new ConcurrentStack<long>(); // such a bad design

        readonly Task _receiveLoopTask;
        // TODO
        readonly Dictionary<long, TaskCompletionSource<RpcResult>> _rpcFlow =
            new Dictionary<long, TaskCompletionSource<RpcResult>>();
        async Task ReceiveLoop()
        {
            while (true)
            {
                var msgBody = await _transport.Receive();
                var msg = TlSystemMessageHandler.ReadMsg(msgBody);
                _unconfirmedMsgIds.Push(msg.Id);

                Option<TaskCompletionSource<RpcResult>> CaptureFlow(long id) =>
                    _rpcFlow.TryGetValue(id, out var flow) ? Some(flow).Do(_ => _rpcFlow.Remove(id)) : None;
                var callResults = msg.Apply(TlSystemMessageHandler.Handle(_session)).ToArray();
                await _sessionStore.Save(_session);
                callResults.Iter(res => CaptureFlow(res.Id).Match(
                    flow => flow.SetResult(res),
                    () => Console.WriteLine("Unexpected RPC result, the message id is " + res.Id)
                ));
            }
        }

        public TlTransport(MtProtoCipherTransport transport, Session session, ISessionStore sessionStore)
        {
            _transport = transport;
            _session = session;
            _sessionStore = sessionStore;
            _receiveLoopTask = Task.Run(ReceiveLoop);
        }


        async Task SendConfirmations()
        {
            var cnt = _unconfirmedMsgIds.Count;
            if (cnt == 0) return;

            const int magic = 3;
            var ids = new List<long>(cnt + magic);
            while (_unconfirmedMsgIds.TryPop(out var id)) ids.Add(id);

            try
            {
                var ack = (MsgsAck) new MsgsAck.Tag(ids.ToArr());
                var msgId = _session.GetNewMessageId();
                await _transport.Send(messageId: msgId, incSeqNum: false, dto: ack);
            }
            finally
            {
                _unconfirmedMsgIds.PushRange(ids.ToArray());
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

                var respTask = await _rpcQueue.Put(async () =>
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
    }
}
