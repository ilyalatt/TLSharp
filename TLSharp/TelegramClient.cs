using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using LanguageExt;
using TLSharp.Auth;
using TLSharp.Rpc;
using TLSharp.Rpc.Functions;
using TLSharp.Rpc.Functions.Account;
using TLSharp.Rpc.Functions.Auth;
using TLSharp.Rpc.Functions.Contacts;
using TLSharp.Rpc.Functions.Help;
using TLSharp.Rpc.Functions.Messages;
using TLSharp.Rpc.Functions.Upload;
using TLSharp.Rpc.Types;
using TLSharp.Rpc.Types.Account;
using TLSharp.Rpc.Types.Auth;
using TLSharp.Rpc.Types.Contacts;
using TLSharp.Rpc.Types.Messages;
using TLSharp.Rpc.Types.Upload;
using Helpers = TLSharp.Utils.Helpers;
using Search = TLSharp.Rpc.Functions.Contacts.Search;
using static LanguageExt.Prelude;

namespace TLSharp
{
    public class TelegramClient : IDisposable
    {
        TlTransport _transport;
        readonly string _apiHash;
        readonly int _apiId;
        readonly Session _session;
        readonly ISessionStore _sessionSessionStore;
        List<DcOption.Tag> _dcOptions;
        readonly TcpClientConnectionHandler _handler;

        async Task<System.Net.Sockets.TcpClient> CreateTcpClient()
        {
            var ep = _session.Endpoint;
            if (_handler != null) return await _handler(ep);

            var res = new System.Net.Sockets.TcpClient();
            await res.ConnectAsync(ep.Address, ep.Port);
            return res;
        }

        async Task<TcpTransport> CreateTcpTransport() =>
            new TcpTransport(await CreateTcpClient());

        static readonly IPEndPoint DefaultEndpoint = new IPEndPoint(IPAddress.Parse("149.154.167.50"), 443);

        TelegramClient(
            int apiId,
            string apiHash,
            Session session,
            ISessionStore sessionStore,
            TcpClientConnectionHandler handler
        ) {
            _apiHash = apiHash;
            _apiId = apiId;
            _session = session;
            _sessionSessionStore = sessionStore;
            _handler = handler;
        }

        public void Dispose() => _transport.Dispose();


        static async Task<T> Wrap<T>(Func<Task<T>> wrapper)
        {
            try
            {
                return await Task.Run(wrapper).ConfigureAwait(false);
            }
            // TODO: a separate class handling this stuff
            catch (Exception exc) when (!(exc is TlException) && !(exc is OutOfMemoryException))
            {
                throw new TlInternalException("Unhandled exception. See an inner exception.", exc);
            }
        }

        async Task<Unit> Connect()
        {
            _transport?.Dispose();
            var tcpTransport = await CreateTcpTransport();

            if (_session.AuthKey == null)
            {
                var mtPlainTransport = new MtProtoPlainTransport(tcpTransport);
                var result = await Authenticator.DoAuthentication(mtPlainTransport);
                _session.AuthKey = result.AuthKey;
                _session.TimeOffset = result.TimeOffset;
            }

            Console.WriteLine("AuthKey: " + _session.AuthKey);
            var mtCipherTransport = new MtProtoCipherTransport(tcpTransport, _session, _sessionSessionStore);
            _transport = new TlTransport(mtCipherTransport, _session, _sessionSessionStore);

            //set-up layer
            var config = new GetConfig();
            var request = new InitConnection<GetConfig, Config>(
                apiId: _apiId,
                appVersion: "1.0.0",
                deviceModel: "PC",
                langCode: "en",
                query: config,
                systemVersion: "Win 10.0"
                //systemLangCode: "en",
                //langPack: "en",
                //proxy: None
            );
            var invokeWithLayer = new InvokeWithLayer<InitConnection<GetConfig, Config>, Config>(layer: SchemeInfo.LayerVersion, query: request);
            var cfg = await _transport.Call(invokeWithLayer);

            _dcOptions = cfg.Match(identity).DcOptions.Map(x => x.Match(identity)).ToList();
            return unit;
        }

        public static async Task<TelegramClient> Connect(
            int apiId,
            Some<string> apiHash,
            ISessionStore store = null,
            TcpClientConnectionHandler handler = null,
            IPEndPoint endpoint = null
        ) {
            if (apiId == default(int)) throw new ArgumentNullException(nameof(apiId));

            store = store ?? new FileSessionStore("session.dat");
            var session = (await store.Load()).IfNone(Session.New);
            session.Endpoint = endpoint ?? DefaultEndpoint;

            var client = new TelegramClient(
                apiId,
                apiHash,
                session,
                store,
                handler
            );
            await Wrap(client.Connect);
            return client;
        }


        public bool IsAuthenticated() => _session.IsAuthenticated;

        async Task SetAuthorized(User user)
        {
            Console.WriteLine("Authorized: " + user);
            _session.IsAuthenticated = true;
            await _sessionSessionStore.Save(_session);
        }

        async Task ReconnectToDc(int dcId)
        {
            Helpers.Assert(_dcOptions != null && _dcOptions.Count > 0, "bad dc options");

            ExportedAuthorization.Tag exported = null;
            if (IsAuthenticated())
            {
                var exportAuthorization = new ExportAuthorization(dcId: dcId);
                var resp = await _transport.Call(exportAuthorization);
                exported = resp.Match(identity);
            }

            var dc = _dcOptions.First(d => d.Id == dcId);
            _session.Endpoint = new IPEndPoint(IPAddress.Parse(dc.IpAddress), dc.Port);
            _session.AuthKey = null;
            await Connect();

            if (exported != null)
            {
                var importAuthorization = new ImportAuthorization(id: exported.Id, bytes: exported.Bytes);
                var resp = await _transport.Call(importAuthorization);
                var user = resp.Match(identity).User;
                await SetAuthorized(user);
            }
        }

        async Task<T> RequestWithDcMigration<T>(ITlFunc<T> func)
        {
            while (true)
            {
                try
                {
                    return await _transport.Call(func);
                }
                catch (TlDataCenterMigrationException e)
                {
                    await ReconnectToDc(e.Dc);
                }
            }
        }

        // TODO: call middleware
        // chains like RequestWithDcMigration -> TlExceptionWrapper -> Delayer
        public Task<T> Call<T>(ITlFunc<T> func) =>
            Wrap(() => RequestWithDcMigration(func ?? throw new ArgumentNullException(nameof(func))));


        public async Task<string> SendCodeRequest(Some<string> phoneNumber)
        {
            var resp = await Call(new SendCode(
                phoneNumber: phoneNumber,
                apiId: _apiId, apiHash:
                _apiHash,
                allowFlashcall: false,
                currentNumber: None
            ));
            return resp.Match(identity).PhoneCodeHash;
        }

        public async Task<User> MakeAuth(Some<string> phoneNumber, Some<string> phoneCodeHash, Some<string> code)
        {
            var resp = await Call(new SignIn(phoneNumber: phoneNumber, phoneCodeHash: phoneCodeHash, phoneCode: code));
            var user = resp.Match(identity).User;
            await SetAuthorized(user);
            return user;
        }

        public async Task<Password> GetPasswordSetting()
        {
            return await Call(new GetPassword());
        }

        public async Task<User> MakeAuthWithPassword(Some<Password.Tag> password, Some<string> passwordStr)
        {
            var passwordBytes = Encoding.UTF8.GetBytes(passwordStr.Value);
            var currentSalt = password.Value.CurrentSalt;
            // TODO: check new salt
            var rv = currentSalt.Concat(passwordBytes).Concat(currentSalt);

            var hash = new SHA256Managed();
            var passwordHash = hash.ComputeHash(rv.ToArray());

            var request = new CheckPassword(passwordHash: passwordHash.ToArr());

            var res = await Call(request);

            await SetAuthorized(res.Match(identity).User);

            return (res.Match(identity).User);
        }

        public async Task<User> SignUp(
            Some<string> phoneNumber,
            Some<string> phoneCodeHash,
            Some<string> code,
            Some<string> firstName,
            Some<string> lastName
        ) {
            var res = await Call(new SignUp(
                phoneNumber: phoneNumber,
                phoneCode: code,
                phoneCodeHash: phoneCodeHash,
                firstName: firstName,
                lastName: lastName
            ));
            var user = res.Match(identity).User;
            await SetAuthorized(user);
            return user;
        }


        public async Task<Contacts> GetContacts()
        {
            if (!IsAuthenticated())
                throw new InvalidOperationException("Authorize user first!");

            return await Call(new GetContacts(hash: ""));
        }

        public async Task<UpdatesType> SendMessage(Some<InputPeer> peer, Some<string> message)
        {
            if (!IsAuthenticated())
                throw new InvalidOperationException("Authorize user first!");

            return await Call(new SendMessage(
               peer: peer,
               message: message,
               randomId: Helpers.GenerateRandomLong(),
               noWebpage: true,
               silent: false,
               background: false,
               clearDraft: false,
               replyToMsgId: None,
               replyMarkup: None,
               entities: None
           ));
        }

        public async Task<bool> SendTyping(Some<InputPeer> peer)
        {
            var req = new SetTyping(
                action: (SendMessageAction) new SendMessageAction.TypingTag(),
                peer: peer
            );
            return await Call(req);
        }

        public async Task<Dialogs> GetUserDialogs()
        {
            var peer = (InputPeer) new InputPeer.SelfTag();
            return await Call(
                new GetDialogs(offsetDate: 0, offsetPeer: peer, limit: 100, excludePinned: false, offsetId: 0/*, hash: 0*/)
            );
        }

        public async Task<UpdatesType> SendUploadedPhoto(Some<InputPeer> peer, Some<InputFile> file) =>
            await Call(new SendMedia(
                randomId: Helpers.GenerateRandomLong(),
                background: false,
                clearDraft: false,
                media: (InputMedia) new InputMedia.UploadedPhotoTag(file: file, stickers: None, caption: ""/*, ttlSeconds: None*/),
                peer: peer,
                //entities: None,
                replyToMsgId: None,
                replyMarkup: None,
                //message: "",
                silent: false
            ));

        public async Task<UpdatesType> SendUploadedDocument(
            Some<InputPeer> peer,
            Some<InputFile> file,
            Some<string> mimeType,
            Some<Arr<DocumentAttribute>> attributes
        ) =>
            await Call(new SendMedia(
                randomId: Helpers.GenerateRandomLong(),
                background: false,
                clearDraft: false,
                media: (InputMedia) new InputMedia.UploadedDocumentTag(
                    // nosoundVideo: false,
                    file: file,
                    mimeType: mimeType,
                    attributes: attributes,
                    // thumb: None,
                    stickers: None,
                    caption: ""
                    // ttlSeconds: None
                ),
                peer: peer,
                silent: false,
                replyToMsgId: None,
                replyMarkup: None
                // entities: None,
                // message: ""
            ));

        public async Task<File> GetFile(
            Some<InputFileLocation> location,
            int filePartSize,
            int offset = 0
        ) =>
            await Call(new GetFile(
                location: location,
                limit: filePartSize,
                offset: offset
            ));

        public async Task<Messages> GetHistory(
            Some<InputPeer> peer,
            int offsetId = 0,
            int offsetDate = 0,
            int addOffset = 0,
            int limit = 100,
            int maxId = 0,
            int minId = 0
            //int has = 0
        ) {
            if (!IsAuthenticated())
                throw new InvalidOperationException("Authorize user first!");

            return await Call(new GetHistory(
                peer,
                offsetId,
                offsetDate,
                addOffset,
                limit,
                maxId,
                minId
            ));
        }

        /// <summary>
        /// Serch user or chat. API: contacts.search#11f812d8 q:string limit:int = contacts.Found;
        /// </summary>
        /// <param name="q">User or chat name</param>
        /// <param name="limit">Max result count</param>
        /// <returns></returns>
        public async Task<Found> SearchUser(
            Some<string> q,
            int limit = 10
        ) => await Call(new Search(
            q: q,
            limit: limit
        ));
    }
}
