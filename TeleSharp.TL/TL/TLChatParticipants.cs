using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleSharp.TL;
namespace TeleSharp.TL
{
	[TLObject(2017571861)]
    public class TLChatParticipants : TLAbsChatParticipants
    {
        public override int Constructor
        {
            get
            {
                return 2017571861;
            }
        }

             public int ChatId {get;set;}
     public int AdminId {get;set;}
     public TLVector<TLChatParticipant> Participants {get;set;}
     public int Version {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            ChatId = br.ReadInt32();
AdminId = br.ReadInt32();
Participants = (TLVector<TLChatParticipant>)ObjectUtils.DeserializeVector<TLChatParticipant>(br);
Version = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(ChatId);
bw.Write(AdminId);
ObjectUtils.SerializeObject(Participants,bw);
bw.Write(Version);

        }
    }
}
