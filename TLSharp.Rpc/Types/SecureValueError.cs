using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class SecureValueError : ITlType, IEquatable<SecureValueError>, IComparable<SecureValueError>, IComparable
    {
        public sealed class DataTag : ITlTypeTag, IEquatable<DataTag>, IComparable<DataTag>, IComparable
        {
            internal const uint TypeNumber = 0xe8a40bd9;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly T.SecureValueType Type;
            public readonly Arr<byte> DataHash;
            public readonly string Field;
            public readonly string Text;
            
            public DataTag(
                Some<T.SecureValueType> type,
                Some<Arr<byte>> dataHash,
                Some<string> field,
                Some<string> text
            ) {
                Type = type;
                DataHash = dataHash;
                Field = field;
                Text = text;
            }
            
            (T.SecureValueType, Arr<byte>, string, string) CmpTuple =>
                (Type, DataHash, Field, Text);

            public bool Equals(DataTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is DataTag x && Equals(x);
            public static bool operator ==(DataTag x, DataTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(DataTag x, DataTag y) => !(x == y);

            public int CompareTo(DataTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is DataTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(DataTag x, DataTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(DataTag x, DataTag y) => x.CompareTo(y) < 0;
            public static bool operator >(DataTag x, DataTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(DataTag x, DataTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Type: {Type}, DataHash: {DataHash}, Field: {Field}, Text: {Text})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Type, bw, WriteSerializable);
                Write(DataHash, bw, WriteBytes);
                Write(Field, bw, WriteString);
                Write(Text, bw, WriteString);
            }
            
            internal static DataTag DeserializeTag(BinaryReader br)
            {
                var type = Read(br, T.SecureValueType.Deserialize);
                var dataHash = Read(br, ReadBytes);
                var field = Read(br, ReadString);
                var text = Read(br, ReadString);
                return new DataTag(type, dataHash, field, text);
            }
        }

        public sealed class FrontSideTag : ITlTypeTag, IEquatable<FrontSideTag>, IComparable<FrontSideTag>, IComparable
        {
            internal const uint TypeNumber = 0x00be3dfa;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly T.SecureValueType Type;
            public readonly Arr<byte> FileHash;
            public readonly string Text;
            
            public FrontSideTag(
                Some<T.SecureValueType> type,
                Some<Arr<byte>> fileHash,
                Some<string> text
            ) {
                Type = type;
                FileHash = fileHash;
                Text = text;
            }
            
            (T.SecureValueType, Arr<byte>, string) CmpTuple =>
                (Type, FileHash, Text);

            public bool Equals(FrontSideTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is FrontSideTag x && Equals(x);
            public static bool operator ==(FrontSideTag x, FrontSideTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(FrontSideTag x, FrontSideTag y) => !(x == y);

            public int CompareTo(FrontSideTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is FrontSideTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(FrontSideTag x, FrontSideTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(FrontSideTag x, FrontSideTag y) => x.CompareTo(y) < 0;
            public static bool operator >(FrontSideTag x, FrontSideTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(FrontSideTag x, FrontSideTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Type: {Type}, FileHash: {FileHash}, Text: {Text})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Type, bw, WriteSerializable);
                Write(FileHash, bw, WriteBytes);
                Write(Text, bw, WriteString);
            }
            
            internal static FrontSideTag DeserializeTag(BinaryReader br)
            {
                var type = Read(br, T.SecureValueType.Deserialize);
                var fileHash = Read(br, ReadBytes);
                var text = Read(br, ReadString);
                return new FrontSideTag(type, fileHash, text);
            }
        }

        public sealed class ReverseSideTag : ITlTypeTag, IEquatable<ReverseSideTag>, IComparable<ReverseSideTag>, IComparable
        {
            internal const uint TypeNumber = 0x868a2aa5;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly T.SecureValueType Type;
            public readonly Arr<byte> FileHash;
            public readonly string Text;
            
            public ReverseSideTag(
                Some<T.SecureValueType> type,
                Some<Arr<byte>> fileHash,
                Some<string> text
            ) {
                Type = type;
                FileHash = fileHash;
                Text = text;
            }
            
            (T.SecureValueType, Arr<byte>, string) CmpTuple =>
                (Type, FileHash, Text);

            public bool Equals(ReverseSideTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is ReverseSideTag x && Equals(x);
            public static bool operator ==(ReverseSideTag x, ReverseSideTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ReverseSideTag x, ReverseSideTag y) => !(x == y);

            public int CompareTo(ReverseSideTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is ReverseSideTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ReverseSideTag x, ReverseSideTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ReverseSideTag x, ReverseSideTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ReverseSideTag x, ReverseSideTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ReverseSideTag x, ReverseSideTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Type: {Type}, FileHash: {FileHash}, Text: {Text})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Type, bw, WriteSerializable);
                Write(FileHash, bw, WriteBytes);
                Write(Text, bw, WriteString);
            }
            
            internal static ReverseSideTag DeserializeTag(BinaryReader br)
            {
                var type = Read(br, T.SecureValueType.Deserialize);
                var fileHash = Read(br, ReadBytes);
                var text = Read(br, ReadString);
                return new ReverseSideTag(type, fileHash, text);
            }
        }

        public sealed class SelfieTag : ITlTypeTag, IEquatable<SelfieTag>, IComparable<SelfieTag>, IComparable
        {
            internal const uint TypeNumber = 0xe537ced6;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly T.SecureValueType Type;
            public readonly Arr<byte> FileHash;
            public readonly string Text;
            
            public SelfieTag(
                Some<T.SecureValueType> type,
                Some<Arr<byte>> fileHash,
                Some<string> text
            ) {
                Type = type;
                FileHash = fileHash;
                Text = text;
            }
            
            (T.SecureValueType, Arr<byte>, string) CmpTuple =>
                (Type, FileHash, Text);

            public bool Equals(SelfieTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is SelfieTag x && Equals(x);
            public static bool operator ==(SelfieTag x, SelfieTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(SelfieTag x, SelfieTag y) => !(x == y);

            public int CompareTo(SelfieTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is SelfieTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(SelfieTag x, SelfieTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(SelfieTag x, SelfieTag y) => x.CompareTo(y) < 0;
            public static bool operator >(SelfieTag x, SelfieTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(SelfieTag x, SelfieTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Type: {Type}, FileHash: {FileHash}, Text: {Text})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Type, bw, WriteSerializable);
                Write(FileHash, bw, WriteBytes);
                Write(Text, bw, WriteString);
            }
            
            internal static SelfieTag DeserializeTag(BinaryReader br)
            {
                var type = Read(br, T.SecureValueType.Deserialize);
                var fileHash = Read(br, ReadBytes);
                var text = Read(br, ReadString);
                return new SelfieTag(type, fileHash, text);
            }
        }

        public sealed class FileTag : ITlTypeTag, IEquatable<FileTag>, IComparable<FileTag>, IComparable
        {
            internal const uint TypeNumber = 0x7a700873;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly T.SecureValueType Type;
            public readonly Arr<byte> FileHash;
            public readonly string Text;
            
            public FileTag(
                Some<T.SecureValueType> type,
                Some<Arr<byte>> fileHash,
                Some<string> text
            ) {
                Type = type;
                FileHash = fileHash;
                Text = text;
            }
            
            (T.SecureValueType, Arr<byte>, string) CmpTuple =>
                (Type, FileHash, Text);

            public bool Equals(FileTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is FileTag x && Equals(x);
            public static bool operator ==(FileTag x, FileTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(FileTag x, FileTag y) => !(x == y);

            public int CompareTo(FileTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is FileTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(FileTag x, FileTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(FileTag x, FileTag y) => x.CompareTo(y) < 0;
            public static bool operator >(FileTag x, FileTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(FileTag x, FileTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Type: {Type}, FileHash: {FileHash}, Text: {Text})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Type, bw, WriteSerializable);
                Write(FileHash, bw, WriteBytes);
                Write(Text, bw, WriteString);
            }
            
            internal static FileTag DeserializeTag(BinaryReader br)
            {
                var type = Read(br, T.SecureValueType.Deserialize);
                var fileHash = Read(br, ReadBytes);
                var text = Read(br, ReadString);
                return new FileTag(type, fileHash, text);
            }
        }

        public sealed class FilesTag : ITlTypeTag, IEquatable<FilesTag>, IComparable<FilesTag>, IComparable
        {
            internal const uint TypeNumber = 0x666220e9;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly T.SecureValueType Type;
            public readonly Arr<Arr<byte>> FileHash;
            public readonly string Text;
            
            public FilesTag(
                Some<T.SecureValueType> type,
                Some<Arr<Arr<byte>>> fileHash,
                Some<string> text
            ) {
                Type = type;
                FileHash = fileHash;
                Text = text;
            }
            
            (T.SecureValueType, Arr<Arr<byte>>, string) CmpTuple =>
                (Type, FileHash, Text);

            public bool Equals(FilesTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is FilesTag x && Equals(x);
            public static bool operator ==(FilesTag x, FilesTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(FilesTag x, FilesTag y) => !(x == y);

            public int CompareTo(FilesTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is FilesTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(FilesTag x, FilesTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(FilesTag x, FilesTag y) => x.CompareTo(y) < 0;
            public static bool operator >(FilesTag x, FilesTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(FilesTag x, FilesTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Type: {Type}, FileHash: {FileHash}, Text: {Text})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Type, bw, WriteSerializable);
                Write(FileHash, bw, WriteVector<Arr<byte>>(WriteBytes));
                Write(Text, bw, WriteString);
            }
            
            internal static FilesTag DeserializeTag(BinaryReader br)
            {
                var type = Read(br, T.SecureValueType.Deserialize);
                var fileHash = Read(br, ReadVector(ReadBytes));
                var text = Read(br, ReadString);
                return new FilesTag(type, fileHash, text);
            }
        }

        readonly ITlTypeTag _tag;
        SecureValueError(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator SecureValueError(DataTag tag) => new SecureValueError(tag);
        public static explicit operator SecureValueError(FrontSideTag tag) => new SecureValueError(tag);
        public static explicit operator SecureValueError(ReverseSideTag tag) => new SecureValueError(tag);
        public static explicit operator SecureValueError(SelfieTag tag) => new SecureValueError(tag);
        public static explicit operator SecureValueError(FileTag tag) => new SecureValueError(tag);
        public static explicit operator SecureValueError(FilesTag tag) => new SecureValueError(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static SecureValueError Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case DataTag.TypeNumber: return (SecureValueError) DataTag.DeserializeTag(br);
                case FrontSideTag.TypeNumber: return (SecureValueError) FrontSideTag.DeserializeTag(br);
                case ReverseSideTag.TypeNumber: return (SecureValueError) ReverseSideTag.DeserializeTag(br);
                case SelfieTag.TypeNumber: return (SecureValueError) SelfieTag.DeserializeTag(br);
                case FileTag.TypeNumber: return (SecureValueError) FileTag.DeserializeTag(br);
                case FilesTag.TypeNumber: return (SecureValueError) FilesTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { DataTag.TypeNumber, FrontSideTag.TypeNumber, ReverseSideTag.TypeNumber, SelfieTag.TypeNumber, FileTag.TypeNumber, FilesTag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<DataTag, T> dataTag = null,
            Func<FrontSideTag, T> frontSideTag = null,
            Func<ReverseSideTag, T> reverseSideTag = null,
            Func<SelfieTag, T> selfieTag = null,
            Func<FileTag, T> fileTag = null,
            Func<FilesTag, T> filesTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case DataTag x when dataTag != null: return dataTag(x);
                case FrontSideTag x when frontSideTag != null: return frontSideTag(x);
                case ReverseSideTag x when reverseSideTag != null: return reverseSideTag(x);
                case SelfieTag x when selfieTag != null: return selfieTag(x);
                case FileTag x when fileTag != null: return fileTag(x);
                case FilesTag x when filesTag != null: return filesTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<DataTag, T> dataTag,
            Func<FrontSideTag, T> frontSideTag,
            Func<ReverseSideTag, T> reverseSideTag,
            Func<SelfieTag, T> selfieTag,
            Func<FileTag, T> fileTag,
            Func<FilesTag, T> filesTag
        ) => Match(
            () => throw new Exception("WTF"),
            dataTag ?? throw new ArgumentNullException(nameof(dataTag)),
            frontSideTag ?? throw new ArgumentNullException(nameof(frontSideTag)),
            reverseSideTag ?? throw new ArgumentNullException(nameof(reverseSideTag)),
            selfieTag ?? throw new ArgumentNullException(nameof(selfieTag)),
            fileTag ?? throw new ArgumentNullException(nameof(fileTag)),
            filesTag ?? throw new ArgumentNullException(nameof(filesTag))
        );

        int GetTagOrder()
        {
            switch (_tag)
            {
                case DataTag _: return 0;
                case FrontSideTag _: return 1;
                case ReverseSideTag _: return 2;
                case SelfieTag _: return 3;
                case FileTag _: return 4;
                case FilesTag _: return 5;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(SecureValueError other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is SecureValueError x && Equals(x);
        public static bool operator ==(SecureValueError x, SecureValueError y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(SecureValueError x, SecureValueError y) => !(x == y);

        public int CompareTo(SecureValueError other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is SecureValueError x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(SecureValueError x, SecureValueError y) => x.CompareTo(y) <= 0;
        public static bool operator <(SecureValueError x, SecureValueError y) => x.CompareTo(y) < 0;
        public static bool operator >(SecureValueError x, SecureValueError y) => x.CompareTo(y) > 0;
        public static bool operator >=(SecureValueError x, SecureValueError y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"SecureValueError.{_tag.GetType().Name}{_tag}";
    }
}