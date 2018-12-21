using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleSharp.TL;
namespace TeleSharp.TL
{
	[TLObject(1450613171)]
    public class TLMessage : TLAbsMessage
    {
        public override int Constructor
        {
            get
            {
                return 1450613171;
            }
        }

             public int Flags {get;set;}
     public int Id {get;set;}
     public int FromId {get;set;}
     public TLAbsPeer ToId {get;set;}
     public int Date {get;set;}
     public string Message {get;set;}
     public TLAbsMessageMedia Media {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
Id = br.ReadInt32();
FromId = br.ReadInt32();
ToId = (TLAbsPeer)ObjectUtils.DeserializeObject(br);
Date = br.ReadInt32();
Message = StringUtil.Deserialize(br);
Media = (TLAbsMessageMedia)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(Flags);
bw.Write(Id);
bw.Write(FromId);
ObjectUtils.SerializeObject(ToId,bw);
bw.Write(Date);
StringUtil.Serialize(Message,bw);
ObjectUtils.SerializeObject(Media,bw);

        }
    }
}
