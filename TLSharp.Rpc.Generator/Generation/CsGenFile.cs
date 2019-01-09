using LanguageExt;

namespace TLSharp.Rpc.Generator.Generation
{
    class CsGenFile
    {
        public readonly string Namespace;
        public readonly string Name;
        public readonly string Content;

        public CsGenFile(Some<string> ns, Some<string> name, Some<string> content)
        {
            Namespace = ns;
            Name = name;
            Content = content;
        }
    }
}
