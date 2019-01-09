using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using LanguageExt;
using TLSharp.Auth;
using TLSharp.Network;
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
        private MtProtoSender _sender;
        private TcpTransport _transport;
        private readonly string _apiHash;
        private readonly int _apiId;
        private readonly Session _session;
        private List<DcOption.Tag> _dcOptions;
        private readonly TcpClientConnectionHandler _handler;

        public TelegramClient(int apiId,
            string apiHash,
            ISessionStore store = null,
            string sessionUserId = "session",
            TcpClientConnectionHandler handler = null,
            IPEndPoint connectionAddress = null
        )
        {
            if (apiId == default(int))
                throw new MissingApiConfigurationException("API_ID");
            if (string.IsNullOrEmpty(apiHash))
                throw new MissingApiConfigurationException("API_HASH");

            if (store == null)
                store = new FileSessionStore();

            _apiHash = apiHash;
            _apiId = apiId;
            _handler = handler;

            _session =
                Session.TryLoad(store, sessionUserId) ?? (connectionAddress != null
                   ? Session.Create(store, sessionUserId, connectionAddress.Address.ToString(), connectionAddress.Port)
                   : Session.Create(store, sessionUserId)
                );

            _transport = new TcpTransport(_session.ServerAddress, _session.Port, _handler);
        }

        public async Task ConnectAsync(bool reconnect = false)
        {
            if (_session.AuthKey == null || reconnect)
            {
                var result = await Authenticator.DoAuthentication(_transport);
                _session.AuthKey = result.AuthKey;
                _session.TimeOffset = result.TimeOffset;
            }

            _sender = new MtProtoSender(_transport, _session);

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
            var cfg = await _sender.Call(invokeWithLayer);

            _dcOptions = cfg.Match(identity).DcOptions.Map(x => x.Match(identity)).ToList();
        }

        private async Task ReconnectToDcAsync(int dcId)
        {
            if (_dcOptions == null || !_dcOptions.Any())
                throw new InvalidOperationException($"Can't reconnect. Establish initial connection first.");

            ExportedAuthorization.Tag exported = null;
            if (_session.TlUser != null)
            {
                var exportAuthorization = new ExportAuthorization(dcId: dcId);
                var resp = await SendRequestAsync(exportAuthorization);
                exported = resp.Match(Prelude.identity);
            }

            var dc = _dcOptions.First(d => d.Id == dcId);
            Console.WriteLine(dc.ToString());

            _transport = new TcpTransport(dc.IpAddress, dc.Port, _handler);
            _session.ServerAddress = dc.IpAddress;
            _session.Port = dc.Port;

            await ConnectAsync(true);

            if (exported != null)
            {
                var importAuthorization = new ImportAuthorization(id: exported.Id, bytes: exported.Bytes);
                var resp = await SendRequestAsync(importAuthorization);
                var user = resp.Match(Prelude.identity).User;
                OnUserAuthenticated(user);
            }
        }

        private async Task<T> RequestWithDcMigration<T>(ITlFunc<T> func)
        {
            if (_sender == null)
                throw new InvalidOperationException("Not connected!");

            while(true)
            {
                try
                {
                    return await _sender.Call(func);
                }
                catch (DataCenterMigrationException e)
                {
                    await ReconnectToDcAsync(e.DC);
                }
            }
        }

        public bool IsUserAuthorized()
        {
            return _session.TlUser != null;
        }

        public async Task<string> SendCodeRequestAsync(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw new ArgumentNullException(nameof(phoneNumber));

            var resp = await RequestWithDcMigration(new SendCode(
                phoneNumber: phoneNumber,
                apiId: _apiId, apiHash:
                _apiHash,
                allowFlashcall: false,
                currentNumber: Prelude.None
            ));
            return resp.Match(Prelude.identity).PhoneCodeHash;
        }

        public async Task<User> MakeAuthAsync(string phoneNumber, string phoneCodeHash, string code)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw new ArgumentNullException(nameof(phoneNumber));

            if (string.IsNullOrWhiteSpace(phoneCodeHash))
                throw new ArgumentNullException(nameof(phoneCodeHash));

            if (string.IsNullOrWhiteSpace(code))
                throw new ArgumentNullException(nameof(code));

            var resp = await RequestWithDcMigration(new SignIn(phoneNumber: phoneNumber, phoneCodeHash: phoneCodeHash, phoneCode: code));
            var user = resp.Match(Prelude.identity).User;

            OnUserAuthenticated(user);
            return (user);
        }

        public async Task<Password> GetPasswordSetting()
        {
            return await RequestWithDcMigration(new GetPassword());
        }

        public async Task<User> MakeAuthWithPasswordAsync(Password password, string password_str)
        {
            var passwordBytes = Encoding.UTF8.GetBytes(password_str);
            var currentSalt = password.Match(
                tag: x => x.CurrentSalt.ToArray(),
                noTag: _ => throw new ArgumentException("no password", nameof(password))
            ).ToArray();
            var rv = currentSalt.Concat(passwordBytes).Concat(currentSalt);

            var hash = new SHA256Managed();
            var passwordHash = hash.ComputeHash(rv.ToArray());

            var request = new CheckPassword(passwordHash: passwordHash.ToArr());

            var res = await RequestWithDcMigration(request);

            OnUserAuthenticated(res.Match(Prelude.identity).User);

            return (res.Match(Prelude.identity).User);
        }

        public async Task<User> SignUpAsync(string phoneNumber, string phoneCodeHash, string code, string firstName, string lastName)
        {
            var res = await RequestWithDcMigration(new SignUp(
                phoneNumber: phoneNumber,
                phoneCode: code,
                phoneCodeHash: phoneCodeHash,
                firstName: firstName,
                lastName: lastName
            ));
            var user = res.Match(Prelude.identity).User;

            OnUserAuthenticated(user);
            return user;
        }

        public Task<T> SendRequestAsync<T>(ITlFunc<T> func) => RequestWithDcMigration(func);

        public async Task<Contacts> GetContactsAsync()
        {
            if (!IsUserAuthorized())
                throw new InvalidOperationException("Authorize user first!");

            return await SendRequestAsync(new GetContacts(hash: ""));
        }

        public async Task<UpdatesType> SendMessageAsync(InputPeer peer, string message)
        {
            if (!IsUserAuthorized())
                throw new InvalidOperationException("Authorize user first!");

            return await SendRequestAsync(new SendMessage(
               peer: peer,
               message: message,
               randomId: Helpers.GenerateRandomLong(),
               noWebpage: true,
               silent: false,
               background: false,
               clearDraft: false,
               replyToMsgId: Prelude.None,
               replyMarkup: Prelude.None,
               entities: Prelude.None
           ));
        }

        public async Task<bool> SendTypingAsync(InputPeer peer)
        {
            var req = new SetTyping(
                action: (SendMessageAction) new SendMessageAction.TypingTag(),
                peer: peer
            );
            return await SendRequestAsync<bool>(req);
        }

        public async Task<Dialogs> GetUserDialogsAsync()
        {
            var peer = (InputPeer) new InputPeer.SelfTag();
            return await SendRequestAsync(
                new GetDialogs(offsetDate: 0, offsetPeer: peer, limit: 100, excludePinned: false, offsetId: 0/*, hash: 0*/)
            );
        }

        public async Task<UpdatesType> SendUploadedPhoto(InputPeer peer, InputFile file) =>
            await SendRequestAsync(new SendMedia(
                randomId: Helpers.GenerateRandomLong(),
                background: false,
                clearDraft: false,
                media: (InputMedia) new InputMedia.UploadedPhotoTag(file: file, stickers: Prelude.None, caption: ""/*, ttlSeconds: None*/),
                peer: peer,
                //entities: None,
                replyToMsgId: Prelude.None,
                replyMarkup: Prelude.None,
                //message: "",
                silent: false
            ));

        public async Task<UpdatesType> SendUploadedDocument(
            Some<InputPeer> peer,
            Some<InputFile> file,
            Some<string> mimeType,
            Some<Arr<DocumentAttribute>> attributes
        ) =>
            await SendRequestAsync(new SendMedia(
                randomId: Helpers.GenerateRandomLong(),
                background: false,
                clearDraft: false,
                media: (InputMedia) new InputMedia.UploadedDocumentTag(
                    // nosoundVideo: false,
                    file: file,
                    mimeType: mimeType,
                    attributes: attributes,
                    // thumb: None,
                    stickers: Prelude.None,
                    caption: ""
                    // ttlSeconds: None
                ),
                peer: peer,
                silent: false,
                replyToMsgId: Prelude.None,
                replyMarkup: Prelude.None
                // entities: None,
                // message: ""
            ));

        public async Task<File> GetFile(InputFileLocation location, int filePartSize, int offset = 0) =>
            await SendRequestAsync(new GetFile(
                location: location,
                limit: filePartSize,
                offset: offset
            ));

        public async Task<Messages> GetHistoryAsync(
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

            return await SendRequestAsync(new GetHistory(
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
        public async Task<Found> SearchUserAsync(string q, int limit = 10) => await SendRequestAsync(new Search(
            q: q,
            limit: limit
        ));

        private void OnUserAuthenticated(User tlUser)
        {
            _session.TlUser = tlUser;
            _session.SessionExpires = int.MaxValue;

            _session.Save();
        }

        public bool IsConnected => _transport != null && _transport.IsConnected;

        public void Dispose()
        {
            if (_transport == null) return;
            _transport.Dispose();
            _transport = null;
        }
    }
}
