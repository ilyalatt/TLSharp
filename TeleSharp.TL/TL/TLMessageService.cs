using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleSharp.TL;
namespace TeleSharp.TL
{
	[TLObject(495384334)]
    public class TLMessageService : TLAbsMessage
    {
        public override int Constructor
        {
            get
            {
                return 495384334;
            }
        }

             public int Flags {get;set;}
     public int Id {get;set;}
     public int FromId {get;set;}
     public TLAbsPeer ToId {get;set;}
     public int Date {get;set;}
     public TLAbsMessageAction Action {get;set;}


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
Action = (TLAbsMessageAction)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(Flags);
bw.Write(Id);
bw.Write(FromId);
ObjectUtils.SerializeObject(ToId,bw);
bw.Write(Date);
ObjectUtils.SerializeObject(Action,bw);

        }
    }
}
