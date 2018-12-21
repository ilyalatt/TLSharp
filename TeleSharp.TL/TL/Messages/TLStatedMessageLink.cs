using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleSharp.TL;
namespace TeleSharp.TL.Messages
{
	[TLObject(-1448138623)]
    public class TLStatedMessageLink : TLAbsStatedMessage
    {
        public override int Constructor
        {
            get
            {
                return -1448138623;
            }
        }

             public TLAbsMessage Message {get;set;}
     public TLVector<TLAbsChat> Chats {get;set;}
     public TLVector<TLAbsUser> Users {get;set;}
     public TLVector<Contacts.TLAbsLink> Links {get;set;}
     public int Pts {get;set;}
     public int Seq {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Message = (TLAbsMessage)ObjectUtils.DeserializeObject(br);
Chats = (TLVector<TLAbsChat>)ObjectUtils.DeserializeVector<TLAbsChat>(br);
Users = (TLVector<TLAbsUser>)ObjectUtils.DeserializeVector<TLAbsUser>(br);
Links = (TLVector<Contacts.TLAbsLink>)ObjectUtils.DeserializeVector<Contacts.TLAbsLink>(br);
Pts = br.ReadInt32();
Seq = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Message,bw);
ObjectUtils.SerializeObject(Chats,bw);
ObjectUtils.SerializeObject(Users,bw);
ObjectUtils.SerializeObject(Links,bw);
bw.Write(Pts);
bw.Write(Seq);

        }
    }
}
