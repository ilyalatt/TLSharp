using System;
using System.IO;
using System.Threading.Tasks;
using LanguageExt;
using Newtonsoft.Json;
using TLSharp;

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

            await tg.ConnectAsync();
            Console.WriteLine("Connected");
            while (!tg.IsUserAuthorized())
            {
                var codeHash = await tg.SendCodeRequestAsync(cfg.Phone);
                Console.WriteLine("Enter the telegram code");
                var code = Console.ReadLine();
                try
                {
                    await tg.MakeAuthAsync(cfg.Phone, codeHash, code);
                }
                catch (CloudPasswordNeededException)
                {
                    var pwd = await tg.GetPasswordSetting();
                    await tg.MakeAuthWithPasswordAsync(pwd, cfg.Password);
                }
            }

            Console.WriteLine("Login completed");
            await Task.Delay(-1);
        }
    }
}
