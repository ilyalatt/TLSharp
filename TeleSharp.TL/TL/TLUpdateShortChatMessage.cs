using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleSharp.TL;
namespace TeleSharp.TL
{
	[TLObject(724548942)]
    public class TLUpdateShortChatMessage : TLAbsUpdates
    {
        public override int Constructor
        {
            get
            {
                return 724548942;
            }
        }

             public int Id {get;set;}
     public int FromId {get;set;}
     public int ChatId {get;set;}
     public string Message {get;set;}
     public int Pts {get;set;}
     public int Date {get;set;}
     public int Seq {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Id = br.ReadInt32();
FromId = br.ReadInt32();
ChatId = br.ReadInt32();
Message = StringUtil.Deserialize(br);
Pts = br.ReadInt32();
Date = br.ReadInt32();
Seq = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(Id);
bw.Write(FromId);
bw.Write(ChatId);
StringUtil.Serialize(Message,bw);
bw.Write(Pts);
bw.Write(Date);
bw.Write(Seq);

        }
    }
}
