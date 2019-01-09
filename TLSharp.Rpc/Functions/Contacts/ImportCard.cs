using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Contacts
{
    public sealed class ImportCard : Record<ImportCard>, ITlFunc<T.User>
    {
        public Arr<int> ExportCard { get; }
        
        public ImportCard(
            Some<Arr<int>> exportCard
        ) {
            ExportCard = exportCard;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x4fe196fe);
            Write(ExportCard, bw, WriteVector<int>(WriteInt));
        }
        
        T.User ITlFunc<T.User>.DeserializeResult(BinaryReader br) =>
            Read(br, T.User.Deserialize);
    }
}