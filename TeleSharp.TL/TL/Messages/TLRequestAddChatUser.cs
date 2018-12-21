using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleSharp.TL;
namespace TeleSharp.TL.Messages
{
	[TLObject(787082910)]
    public class TLRequestAddChatUser : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 787082910;
            }
        }

                public int ChatId {get;set;}
        public TLAbsInputUser UserId {get;set;}
        public int FwdLimit {get;set;}
        public Messages.TLAbsStatedMessage Response{ get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            ChatId = br.ReadInt32();
UserId = (TLAbsInputUser)ObjectUtils.DeserializeObject(br);
FwdLimit = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(ChatId);
ObjectUtils.SerializeObject(UserId,bw);
bw.Write(FwdLimit);

        }
		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (Messages.TLAbsStatedMessage)ObjectUtils.DeserializeObject(br);

		}
    }
}
