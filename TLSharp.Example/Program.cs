using System;
using System.IO;
using System.Threading.Tasks;
using LanguageExt;
using Newtonsoft.Json;
using TLSharp.Rpc.Functions;
using static LanguageExt.Prelude;

namespace TLSharp.Example
{
    class Config
    {
        public int ApiId { get; set; }
        public string ApiHash { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
    }

    static class Program
    {
        static async Task SignIn(TelegramClient tg, Config cfg)
        {
            if (tg.IsAuthenticated())
            {
                Console.WriteLine("Authenticated");
                return;
            }

            while (!tg.IsAuthenticated())
            {
                try
                {
                    var codeHash = await tg.SendCodeRequest(cfg.Phone);
                    Console.WriteLine("Enter the telegram code");
                    var code = Console.ReadLine();
                    await tg.MakeAuth(cfg.Phone, codeHash, code);
                }
                catch (TlPasswordNeededException)
                {
                    var pwdSettings = await tg.GetPasswordSetting();
                    var pwd = pwdSettings.Match(
                        noTag: _ => throw new Exception("WTF"),
                        tag: identity
                    );
                    await tg.MakeAuthWithPassword(pwd, cfg.Password);
                }
            }

            Console.WriteLine("Authentication completed");
        }

        static async Task Main()
        {
            var cfg = await File.ReadAllTextAsync("config.json").Map(JsonConvert.DeserializeObject<Config>);
            using (var tg = await TelegramClient.Connect(cfg.ApiId, cfg.ApiHash))
            {
                await SignIn(tg, cfg);
                var chats = await tg.GetUserDialogs();
            }
        }
    }
}
