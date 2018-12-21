using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleSharp.TL;
namespace TeleSharp.TL
{
	[TLObject(-945003370)]
    public class TLAudio : TLAbsAudio
    {
        public override int Constructor
        {
            get
            {
                return -945003370;
            }
        }

             public long Id {get;set;}
     public long AccessHash {get;set;}
     public int UserId {get;set;}
     public int Date {get;set;}
     public int Duration {get;set;}
     public string MimeType {get;set;}
     public int Size {get;set;}
     public int DcId {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Id = br.ReadInt64();
AccessHash = br.ReadInt64();
UserId = br.ReadInt32();
Date = br.ReadInt32();
Duration = br.ReadInt32();
MimeType = StringUtil.Deserialize(br);
Size = br.ReadInt32();
DcId = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(Id);
bw.Write(AccessHash);
bw.Write(UserId);
bw.Write(Date);
bw.Write(Duration);
StringUtil.Serialize(MimeType,bw);
bw.Write(Size);
bw.Write(DcId);

        }
    }
}
