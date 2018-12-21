using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleSharp.TL;
namespace TeleSharp.TL.Messages
{
	[TLObject(-1010447069)]
    public class TLRequestDeleteChatUser : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -1010447069;
            }
        }

                public int ChatId {get;set;}
        public TLAbsInputUser UserId {get;set;}
        public Messages.TLAbsStatedMessage Response{ get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            ChatId = br.ReadInt32();
UserId = (TLAbsInputUser)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(ChatId);
ObjectUtils.SerializeObject(UserId,bw);

        }
		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (Messages.TLAbsStatedMessage)ObjectUtils.DeserializeObject(br);

		}
    }
}
