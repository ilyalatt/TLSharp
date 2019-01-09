using System;
using System.IO;
using System.Threading.Tasks;
using LanguageExt;

namespace TLSharp.Rpc.Generator.Generation
{
    static class FileSync
    {
        const string BaseNamespace = "TLSharp.Rpc";
        const string BasePath = "../" + BaseNamespace;

        public static Task Sync(Some<CsGenFile> someFile)
        {
            if (!Directory.Exists(BasePath)) throw new Exception("WTF");

            var file = someFile.Value;
            if (!file.Namespace.StartsWith(BaseNamespace)) throw new Exception("WTF");
            var fileSubDir = file.Namespace.Substring(BaseNamespace.Length).TrimStart('.').Replace(".", "/");
            var filePathDir = Path.Combine(BasePath, fileSubDir);
            var filePath = Path.Combine(filePathDir, file.Name + ".cs");

            if (!Directory.Exists(filePathDir)) Directory.CreateDirectory(filePathDir);
            return File.WriteAllTextAsync(filePath, file.Content);
        }
    }
}
