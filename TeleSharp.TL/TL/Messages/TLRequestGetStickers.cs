using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleSharp.TL;
namespace TeleSharp.TL.Messages
{
	[TLObject(-1373446075)]
    public class TLRequestGetStickers : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -1373446075;
            }
        }

                public string Emoticon {get;set;}
        public string Hash {get;set;}
        public Messages.TLAbsStickers Response{ get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Emoticon = StringUtil.Deserialize(br);
Hash = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            StringUtil.Serialize(Emoticon,bw);
StringUtil.Serialize(Hash,bw);

        }
		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (Messages.TLAbsStickers)ObjectUtils.DeserializeObject(br);

		}
    }
}
