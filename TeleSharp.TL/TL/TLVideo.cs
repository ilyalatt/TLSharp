using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleSharp.TL;
namespace TeleSharp.TL
{
	[TLObject(948937617)]
    public class TLVideo : TLAbsVideo
    {
        public override int Constructor
        {
            get
            {
                return 948937617;
            }
        }

             public long Id {get;set;}
     public long AccessHash {get;set;}
     public int UserId {get;set;}
     public int Date {get;set;}
     public string Caption {get;set;}
     public int Duration {get;set;}
     public string MimeType {get;set;}
     public int Size {get;set;}
     public TLAbsPhotoSize Thumb {get;set;}
     public int DcId {get;set;}
     public int W {get;set;}
     public int H {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Id = br.ReadInt64();
AccessHash = br.ReadInt64();
UserId = br.ReadInt32();
Date = br.ReadInt32();
Caption = StringUtil.Deserialize(br);
Duration = br.ReadInt32();
MimeType = StringUtil.Deserialize(br);
Size = br.ReadInt32();
Thumb = (TLAbsPhotoSize)ObjectUtils.DeserializeObject(br);
DcId = br.ReadInt32();
W = br.ReadInt32();
H = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(Id);
bw.Write(AccessHash);
bw.Write(UserId);
bw.Write(Date);
StringUtil.Serialize(Caption,bw);
bw.Write(Duration);
StringUtil.Serialize(MimeType,bw);
bw.Write(Size);
ObjectUtils.SerializeObject(Thumb,bw);
bw.Write(DcId);
bw.Write(W);
bw.Write(H);

        }
    }
}
