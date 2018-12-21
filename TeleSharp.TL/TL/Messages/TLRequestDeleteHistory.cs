using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleSharp.TL;
namespace TeleSharp.TL.Messages
{
	[TLObject(-185009311)]
    public class TLRequestDeleteHistory : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -185009311;
            }
        }

                public TLAbsInputPeer Peer {get;set;}
        public int Offset {get;set;}
        public Messages.TLAffectedHistory Response{ get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Peer = (TLAbsInputPeer)ObjectUtils.DeserializeObject(br);
Offset = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Peer,bw);
bw.Write(Offset);

        }
		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (Messages.TLAffectedHistory)ObjectUtils.DeserializeObject(br);

		}
    }
}
