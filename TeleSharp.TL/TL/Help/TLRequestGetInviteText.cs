using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleSharp.TL;
namespace TeleSharp.TL.Help
{
	[TLObject(-1532407418)]
    public class TLRequestGetInviteText : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -1532407418;
            }
        }

                public string LangCode {get;set;}
        public Help.TLInviteText Response{ get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            LangCode = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            StringUtil.Serialize(LangCode,bw);

        }
		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (Help.TLInviteText)ObjectUtils.DeserializeObject(br);

		}
    }
}
