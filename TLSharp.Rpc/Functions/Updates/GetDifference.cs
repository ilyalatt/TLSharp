using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Updates
{
    public sealed class GetDifference : Record<GetDifference>, ITlFunc<T.Updates.Difference>
    {
        public int Pts { get; }
        public Option<int> PtsTotalLimit { get; }
        public int Date { get; }
        public int Qts { get; }
        
        public GetDifference(
            int pts,
            Option<int> ptsTotalLimit,
            int date,
            int qts
        ) {
            Pts = pts;
            PtsTotalLimit = ptsTotalLimit;
            Date = date;
            Qts = qts;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x25939651);
            Write(MaskBit(0, PtsTotalLimit), bw, WriteInt);
            Write(Pts, bw, WriteInt);
            Write(PtsTotalLimit, bw, WriteOption<int>(WriteInt));
            Write(Date, bw, WriteInt);
            Write(Qts, bw, WriteInt);
        }
        
        T.Updates.Difference ITlFunc<T.Updates.Difference>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Updates.Difference.Deserialize);
    }
}