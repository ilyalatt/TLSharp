using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class ForwardMessages : Record<ForwardMessages>, ITlFunc<T.UpdatesType>
    {
        public bool Silent { get; }
        public bool Background { get; }
        public bool WithMyScore { get; }
        public T.InputPeer FromPeer { get; }
        public Arr<int> Id { get; }
        public Arr<long> RandomId { get; }
        public T.InputPeer ToPeer { get; }
        
        public ForwardMessages(
            bool silent,
            bool background,
            bool withMyScore,
            Some<T.InputPeer> fromPeer,
            Some<Arr<int>> id,
            Some<Arr<long>> randomId,
            Some<T.InputPeer> toPeer
        ) {
            Silent = silent;
            Background = background;
            WithMyScore = withMyScore;
            FromPeer = fromPeer;
            Id = id;
            RandomId = randomId;
            ToPeer = toPeer;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x708e0195);
            Write(MaskBit(5, Silent) | MaskBit(6, Background) | MaskBit(8, WithMyScore), bw, WriteInt);
            Write(FromPeer, bw, WriteSerializable);
            Write(Id, bw, WriteVector<int>(WriteInt));
            Write(RandomId, bw, WriteVector<long>(WriteLong));
            Write(ToPeer, bw, WriteSerializable);
        }
        
        T.UpdatesType ITlFunc<T.UpdatesType>.DeserializeResult(BinaryReader br) =>
            Read(br, T.UpdatesType.Deserialize);
    }
}