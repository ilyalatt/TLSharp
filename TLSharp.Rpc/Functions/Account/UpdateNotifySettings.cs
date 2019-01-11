using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Account
{
    public sealed class UpdateNotifySettings : ITlFunc<bool>, IEquatable<UpdateNotifySettings>, IComparable<UpdateNotifySettings>, IComparable
    {
        public T.InputNotifyPeer Peer { get; }
        public T.InputPeerNotifySettings Settings { get; }
        
        public UpdateNotifySettings(
            Some<T.InputNotifyPeer> peer,
            Some<T.InputPeerNotifySettings> settings
        ) {
            Peer = peer;
            Settings = settings;
        }
        
        
        (T.InputNotifyPeer, T.InputPeerNotifySettings) CmpTuple =>
            (Peer, Settings);

        public bool Equals(UpdateNotifySettings other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is UpdateNotifySettings x && Equals(x);
        public static bool operator ==(UpdateNotifySettings x, UpdateNotifySettings y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(UpdateNotifySettings x, UpdateNotifySettings y) => !(x == y);

        public int CompareTo(UpdateNotifySettings other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is UpdateNotifySettings x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(UpdateNotifySettings x, UpdateNotifySettings y) => x.CompareTo(y) <= 0;
        public static bool operator <(UpdateNotifySettings x, UpdateNotifySettings y) => x.CompareTo(y) < 0;
        public static bool operator >(UpdateNotifySettings x, UpdateNotifySettings y) => x.CompareTo(y) > 0;
        public static bool operator >=(UpdateNotifySettings x, UpdateNotifySettings y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Peer: {Peer}, Settings: {Settings})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x84be5b93);
            Write(Peer, bw, WriteSerializable);
            Write(Settings, bw, WriteSerializable);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}