using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleSharp.TL;
namespace TeleSharp.TL.Messages
{
	[TLObject(-1547149962)]
    public class TLRequestSendMedia : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -1547149962;
            }
        }

                public TLAbsInputPeer Peer {get;set;}
        public TLAbsInputMedia Media {get;set;}
        public long RandomId {get;set;}
        public Messages.TLAbsStatedMessage Response{ get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Peer = (TLAbsInputPeer)ObjectUtils.DeserializeObject(br);
Media = (TLAbsInputMedia)ObjectUtils.DeserializeObject(br);
RandomId = br.ReadInt64();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Peer,bw);
ObjectUtils.SerializeObject(Media,bw);
bw.Write(RandomId);

        }
		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (Messages.TLAbsStatedMessage)ObjectUtils.DeserializeObject(br);

		}
    }
}
