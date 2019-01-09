using LanguageExt;
using TLSharp.Rpc.Generator.TlScheme;
using StringHashSet = System.Collections.Generic.HashSet<string>;

namespace TLSharp.Rpc.Generator.Generation
{
    static class TlSchemePatcher
    {
        static Arg SetBytesType(Arg arg) => new Arg(
            name: arg.Name,
            type: TlType.OfPrimitive(PrimitiveType.Bytes),
            kind: arg.Kind
        );

        static Signature ChangeStringToByteArgs(Signature signature) => new Signature(
            name: signature.Name,
            typeNumber: signature.TypeNumber,
            args: signature.Args.Map(x => x.Type == TlType.OfPrimitive(PrimitiveType.String) ? SetBytesType(x) : x),
            resultType: signature.ResultType
        );

        static readonly StringHashSet StringToBytes = new StringHashSet
        {
            // types
            "resPQ",
            "p_q_inner_data",
            "server_DH_params_fail",
            "server_DH_params_ok",
            "server_DH_inner_data",
            "client_DH_inner_data",

            // functions
            "req_DH_params",
            "set_client_DH_params"
        };

        static Signature PatchStringToBytes(Signature signature) =>
            signature.Name.Apply(StringToBytes.Contains) ? ChangeStringToByteArgs(signature) : signature;

        static Signature Patch(Signature signature) =>
            signature.Apply(PatchStringToBytes);


        static Scheme Patch(Scheme scheme) => new Scheme(
            types: scheme.Types.Map(Patch),
            functions: scheme.Functions.Map(Patch),
            layerVersion: scheme.LayerVersion
        );

        public static Scheme Patch(Some<Scheme> scheme) => Patch(scheme.Value);
    }
}
