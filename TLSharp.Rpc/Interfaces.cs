using System.IO;

namespace TLSharp.Rpc
{
    public interface ITlSerializable
    {
        void Serialize(BinaryWriter bw);
    }

    interface ITlTypeTag : ITlSerializable
    {
        uint TypeNumber { get; }
    }

    interface ITlType : ITlSerializable { }

    public interface ITlFunc<out TRes> : ITlSerializable
    {
        TRes DeserializeResult(BinaryReader br);
    }
}
