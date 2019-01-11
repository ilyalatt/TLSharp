using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class GetDialogUnreadMarks : ITlFunc<Arr<T.DialogPeer>>, IEquatable<GetDialogUnreadMarks>, IComparable<GetDialogUnreadMarks>, IComparable
    {

        
        public GetDialogUnreadMarks(

        ) {

        }
        
        
        Unit CmpTuple =>
            Unit.Default;

        public bool Equals(GetDialogUnreadMarks other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is GetDialogUnreadMarks x && Equals(x);
        public static bool operator ==(GetDialogUnreadMarks x, GetDialogUnreadMarks y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetDialogUnreadMarks x, GetDialogUnreadMarks y) => !(x == y);

        public int CompareTo(GetDialogUnreadMarks other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is GetDialogUnreadMarks x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetDialogUnreadMarks x, GetDialogUnreadMarks y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetDialogUnreadMarks x, GetDialogUnreadMarks y) => x.CompareTo(y) < 0;
        public static bool operator >(GetDialogUnreadMarks x, GetDialogUnreadMarks y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetDialogUnreadMarks x, GetDialogUnreadMarks y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"()";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x22e24e22);

        }
        
        Arr<T.DialogPeer> ITlFunc<Arr<T.DialogPeer>>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadVector(T.DialogPeer.Deserialize));
    }
}