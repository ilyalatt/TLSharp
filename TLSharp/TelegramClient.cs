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
        TcpTransport _tcpTransport;
        TlTransport _tlTransport;
        readonly string _apiHash;
        readonly int _apiId;
        readonly Session _session;
        List<DcOption.Tag> _dcOptions;
        readonly TcpClientConnectionHandler _handler;

        async Task<System.Net.Sockets.TcpClient> CreateTcpClient()
        {
            var ep = new IPEndPoint(IPAddress.Parse(_session.ServerAddress), _session.Port);
            if (_handler != null) return await _handler(ep);

            var res = new System.Net.Sockets.TcpClient();
            await res.ConnectAsync(ep.Address, ep.Port);
            return res;
        }

        async Task<TcpTransport> CreateTcpTransport() =>
            new TcpTransport(await CreateTcpClient());

        public TelegramClient(
            int apiId,
            string apiHash,
            ISessionStore store = null,
            string sessionUserId = "session",
            TcpClientConnectionHandler handler = null,
            IPEndPoint connectionAddress = null
        ) {
            if (apiId == default(int)) throw new ArgumentNullException(nameof(apiId));
            if (apiHash == null) throw new ArgumentNullException(nameof(apiHash));

            _apiHash = apiHash;
            _apiId = apiId;
            _handler = handler;

            store = store ?? new FileSessionStore();
            _session =
                Session.TryLoad(store, sessionUserId) ?? (connectionAddress != null
                   ? Session.Create(store, sessionUserId, connectionAddress.Address.ToString(), connectionAddress.Port)
                   : Session.Create(store, sessionUserId)
                );
        }

        static async Task<T> Wrap<T>(Func<Task<T>> wrapper)
        {
            try
            {
                return await Task.Run(wrapper).ConfigureAwait(false);
            }
            catch (Exception exc) when (!(exc is TlException))
            {
                throw new TlInternalException("Unhandled exception. See an inner exception.", exc);
            }
        }

        async Task<Unit> ConnectImpl(bool forceReconnect)
        {
            _tcpTransport = _tcpTransport ?? await CreateTcpTransport();

            if (_session.AuthKey == null || forceReconnect)
            {
                _tcpTransport = await CreateTcpTransport();
                var mtPlainTransport = new MtProtoPlainTransport(_tcpTransport);
                var result = await Authenticator.DoAuthentication(mtPlainTransport);
                _session.AuthKey = result.AuthKey;
                _session.TimeOffset = result.TimeOffset;
            }

            var mtCipherTransport = new MtProtoCipherTransport(_tcpTransport, _session);
            _tlTransport = new TlTransport(mtCipherTransport, _session);

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
            var cfg = await _tlTransport.Call(invokeWithLayer);

            _dcOptions = cfg.Match(identity).DcOptions.Map(x => x.Match(identity)).ToList();
            return unit;
        }

        public Task Connect(bool forceReconnect = false) =>
            Wrap(() => ConnectImpl(forceReconnect));


        async Task ReconnectToDc(int dcId)
        {
            Helpers.Assert(_dcOptions != null && _dcOptions.Count > 0, "bad dc options");

            ExportedAuthorization.Tag exported = null;
            if (_session.TlUser != null)
            {
                var exportAuthorization = new ExportAuthorization(dcId: dcId);
                var resp = await _tlTransport.Call(exportAuthorization);
                exported = resp.Match(identity);
            }

            var dc = _dcOptions.First(d => d.Id == dcId);
            _session.ServerAddress = dc.IpAddress;
            _session.Port = dc.Port;
            await Connect(forceReconnect: true);

            if (exported != null)
            {
                var importAuthorization = new ImportAuthorization(id: exported.Id, bytes: exported.Bytes);
                var resp = await _tlTransport.Call(importAuthorization);
                var user = resp.Match(identity).User;
                OnUserAuthenticated(user);
            }
        }

        async Task<T> RequestWithDcMigration<T>(ITlFunc<T> func)
        {
            if (_tlTransport == null)
                throw new InvalidOperationException("Not connected!");

            while (true)
            {
                try
                {
                    return await _tlTransport.Call(func);
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


        public bool IsUserAuthorized() => _session.TlUser != null;

        public async Task<string> SendCodeRequest(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw new ArgumentNullException(nameof(phoneNumber));

            var resp = await Call(new SendCode(
                phoneNumber: phoneNumber,
                apiId: _apiId, apiHash:
                _apiHash,
                allowFlashcall: false,
                currentNumber: None
            ));
            return resp.Match(identity).PhoneCodeHash;
        }

        public async Task<User> MakeAuth(string phoneNumber, string phoneCodeHash, string code)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw new ArgumentNullException(nameof(phoneNumber));

            if (string.IsNullOrWhiteSpace(phoneCodeHash))
                throw new ArgumentNullException(nameof(phoneCodeHash));

            if (string.IsNullOrWhiteSpace(code))
                throw new ArgumentNullException(nameof(code));

            var resp = await Call(new SignIn(phoneNumber: phoneNumber, phoneCodeHash: phoneCodeHash, phoneCode: code));
            var user = resp.Match(identity).User;

            OnUserAuthenticated(user);
            return user;
        }

        public async Task<Password> GetPasswordSetting()
        {
            return await Call(new GetPassword());
        }

        public async Task<User> MakeAuthWithPassword(Password password, string passwordStr)
        {
            var passwordBytes = Encoding.UTF8.GetBytes(passwordStr);
            var currentSalt = password.Match(
                tag: x => x.CurrentSalt.ToArray(),
                noTag: _ => throw new ArgumentException("no password", nameof(password))
            ).ToArray();
            var rv = currentSalt.Concat(passwordBytes).Concat(currentSalt);

            var hash = new SHA256Managed();
            var passwordHash = hash.ComputeHash(rv.ToArray());

            var request = new CheckPassword(passwordHash: passwordHash.ToArr());

            var res = await Call(request);

            OnUserAuthenticated(res.Match(identity).User);

            return (res.Match(identity).User);
        }

        public async Task<User> SignUp(string phoneNumber, string phoneCodeHash, string code, string firstName, string lastName)
        {
            var res = await Call(new SignUp(
                phoneNumber: phoneNumber,
                phoneCode: code,
                phoneCodeHash: phoneCodeHash,
                firstName: firstName,
                lastName: lastName
            ));
            var user = res.Match(identity).User;

            OnUserAuthenticated(user);
            return user;
        }


        public async Task<Contacts> GetContacts()
        {
            if (!IsUserAuthorized())
                throw new InvalidOperationException("Authorize user first!");

            return await Call(new GetContacts(hash: ""));
        }

        public async Task<UpdatesType> SendMessage(InputPeer peer, string message)
        {
            if (!IsUserAuthorized())
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

        public async Task<bool> SendTyping(InputPeer peer)
        {
            var req = new SetTyping(
                action: (SendMessageAction) new SendMessageAction.TypingTag(),
                peer: peer
            );
            return await Call<bool>(req);
        }

        public async Task<Dialogs> GetUserDialogs()
        {
            var peer = (InputPeer) new InputPeer.SelfTag();
            return await Call(
                new GetDialogs(offsetDate: 0, offsetPeer: peer, limit: 100, excludePinned: false, offsetId: 0/*, hash: 0*/)
            );
        }

        public async Task<UpdatesType> SendUploadedPhoto(InputPeer peer, InputFile file) =>
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

        public async Task<File> GetFile(InputFileLocation location, int filePartSize, int offset = 0) =>
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
            if (!IsUserAuthorized())
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
        public async Task<Found> SearchUser(string q, int limit = 10) => await Call(new Search(
            q: q,
            limit: limit
        ));

        void OnUserAuthenticated(User tlUser)
        {
            _session.TlUser = tlUser;
            _session.SessionExpires = int.MaxValue;

            _session.Save();
        }

        public bool IsConnected => _tcpTransport != null && _tcpTransport.IsConnected;

        public void Dispose()
        {
            if (_tcpTransport == null) return;
            _tcpTransport.Dispose();
            _tcpTransport = null;
        }
    }
}
