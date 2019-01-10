using System;
using System.IO;
using System.Threading.Tasks;
using LanguageExt;
using Newtonsoft.Json;
using TLSharp;
using TLSharp.Rpc;
using TLSharp.Rpc.Functions;

namespace TLSharp.Example
{
    class Config
    {
        public int ApiId { get; set; }
        public string ApiHash { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
    }

    class Program
    {
        static async Task Main()
        {
            var cfg = await File.ReadAllTextAsync("config.json").Map(JsonConvert.DeserializeObject<Config>);
            var tg = new TelegramClient(cfg.ApiId, cfg.ApiHash);

            await tg.Connect();
            Console.WriteLine("Connected");
            while (!tg.IsUserAuthorized())
            {
                var codeHash = await tg.SendCodeRequest(cfg.Phone);
                Console.WriteLine("Enter the telegram code");
                var code = Console.ReadLine();
                try
                {
                    await tg.MakeAuth(cfg.Phone, codeHash, code);
                }
                catch (TlPasswordNeededException)
                {
                    var pwd = await tg.GetPasswordSetting();
                    await tg.MakeAuthWithPassword(pwd, cfg.Password);
                }
            }

            Console.WriteLine("Login completed");

            await Task.Delay(1500);
            await tg.Call(new Ping(2344254363452));

            tg.Dispose();
        }
    }
}
