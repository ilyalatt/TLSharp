using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleSharp.TL;
namespace TeleSharp.TL.Messages
{
	[TLObject(-1834885329)]
    public class TLRequestGetHistory : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -1834885329;
            }
        }

                public TLAbsInputPeer Peer {get;set;}
        public int Offset {get;set;}
        public int MaxId {get;set;}
        public int Limit {get;set;}
        public Messages.TLAbsMessages Response{ get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Peer = (TLAbsInputPeer)ObjectUtils.DeserializeObject(br);
Offset = br.ReadInt32();
MaxId = br.ReadInt32();
Limit = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Peer,bw);
bw.Write(Offset);
bw.Write(MaxId);
bw.Write(Limit);

        }
		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (Messages.TLAbsMessages)ObjectUtils.DeserializeObject(br);

		}
    }
}
