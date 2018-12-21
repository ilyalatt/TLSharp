using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleSharp.TL;
namespace TeleSharp.TL.Messages
{
	[TLObject(-1438922648)]
    public class TLRequestGetAllStickers : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -1438922648;
            }
        }

                public string Hash {get;set;}
        public Messages.TLAbsAllStickers Response{ get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Hash = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            StringUtil.Serialize(Hash,bw);

        }
		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (Messages.TLAbsAllStickers)ObjectUtils.DeserializeObject(br);

		}
    }
}
