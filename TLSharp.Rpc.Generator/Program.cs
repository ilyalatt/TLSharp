using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using LanguageExt;
using LanguageExt.SomeHelp;
using TLSharp.Rpc.Generator.Generation;
using TLSharp.Rpc.Generator.TlScheme;

namespace TLSharp.Rpc.Generator
{
    static class Program
    {
        const string SchemeUrl = "https://raw.githubusercontent.com/telegramdesktop/tdesktop/dev/Telegram/Resources/scheme.tl";
        static string DownloadLatestTlScheme()
        {
            return File.ReadAllText("scheme.tl");
            // return new WebClient().DownloadString(SchemeUrl);
        }

        static async Task Main()
        {
            var rawScheme = DownloadLatestTlScheme();
            var scheme = TlSchemeParser.Parse(rawScheme)
                .Apply(SomeExt.ToSome).Apply(TlSchemePatcher.Patch)
                .Apply(SomeExt.ToSome).Apply(TlSchemeNormalizer.Normalize);
            var files = CsGen.GenTypes(scheme).Concat(CsGen.GenFunctions(scheme)).Concat(new[] { CsGen.GenSchemeInfo(scheme) });
            foreach (var file in files.AsParallel().WithDegreeOfParallelism(Environment.ProcessorCount)) await FileSync.Sync(file);
        }
    }
}
