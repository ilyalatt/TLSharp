using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleSharp.TL;
namespace TeleSharp.TL.Messages
{
	[TLObject(1289620139)]
    public class TLRequestSendMessage : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 1289620139;
            }
        }

                public TLAbsInputPeer Peer {get;set;}
        public string Message {get;set;}
        public long RandomId {get;set;}
        public Messages.TLAbsSentMessage Response{ get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Peer = (TLAbsInputPeer)ObjectUtils.DeserializeObject(br);
Message = StringUtil.Deserialize(br);
RandomId = br.ReadInt64();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Peer,bw);
StringUtil.Serialize(Message,bw);
bw.Write(RandomId);

        }
		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (Messages.TLAbsSentMessage)ObjectUtils.DeserializeObject(br);

		}
    }
}
