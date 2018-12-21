using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleSharp.TL;
namespace TeleSharp.TL.Messages
{
	[TLObject(-371504577)]
    public class TLSentMessageLink : TLAbsSentMessage
    {
        public override int Constructor
        {
            get
            {
                return -371504577;
            }
        }

             public int Id {get;set;}
     public int Date {get;set;}
     public int Pts {get;set;}
     public int Seq {get;set;}
     public TLVector<Contacts.TLAbsLink> Links {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Id = br.ReadInt32();
Date = br.ReadInt32();
Pts = br.ReadInt32();
Seq = br.ReadInt32();
Links = (TLVector<Contacts.TLAbsLink>)ObjectUtils.DeserializeVector<Contacts.TLAbsLink>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(Id);
bw.Write(Date);
bw.Write(Pts);
bw.Write(Seq);
ObjectUtils.SerializeObject(Links,bw);

        }
    }
}
