using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleSharp.TL;
namespace TeleSharp.TL.Messages
{
	[TLObject(-287800122)]
    public class TLRequestReadHistory : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -287800122;
            }
        }

                public TLAbsInputPeer Peer {get;set;}
        public int MaxId {get;set;}
        public int Offset {get;set;}
        public bool ReadContents {get;set;}
        public Messages.TLAffectedHistory Response{ get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Peer = (TLAbsInputPeer)ObjectUtils.DeserializeObject(br);
MaxId = br.ReadInt32();
Offset = br.ReadInt32();
ReadContents = BoolUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Peer,bw);
bw.Write(MaxId);
bw.Write(Offset);
BoolUtil.Serialize(ReadContents,bw);

        }
		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (Messages.TLAffectedHistory)ObjectUtils.DeserializeObject(br);

		}
    }
}
