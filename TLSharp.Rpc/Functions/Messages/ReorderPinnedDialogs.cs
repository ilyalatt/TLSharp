using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class ReorderPinnedDialogs : Record<ReorderPinnedDialogs>, ITlFunc<bool>
    {
        public bool Force { get; }
        public Arr<T.InputPeer> Order { get; }
        
        public ReorderPinnedDialogs(
            bool force,
            Some<Arr<T.InputPeer>> order
        ) {
            Force = force;
            Order = order;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x959ff644);
            Write(MaskBit(0, Force), bw, WriteInt);
            Write(Order, bw, WriteVector<T.InputPeer>(WriteSerializable));
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}