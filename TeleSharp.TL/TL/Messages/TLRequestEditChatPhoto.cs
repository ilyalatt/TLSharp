using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleSharp.TL;
namespace TeleSharp.TL.Messages
{
	[TLObject(-662601187)]
    public class TLRequestEditChatPhoto : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -662601187;
            }
        }

                public int ChatId {get;set;}
        public TLAbsInputChatPhoto Photo {get;set;}
        public Messages.TLAbsStatedMessage Response{ get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            ChatId = br.ReadInt32();
Photo = (TLAbsInputChatPhoto)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(ChatId);
ObjectUtils.SerializeObject(Photo,bw);

        }
		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (Messages.TLAbsStatedMessage)ObjectUtils.DeserializeObject(br);

		}
    }
}
