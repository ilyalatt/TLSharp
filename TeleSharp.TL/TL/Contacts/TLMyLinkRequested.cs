using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleSharp.TL;
namespace TeleSharp.TL.Contacts
{
	[TLObject(1818882030)]
    public class TLMyLinkRequested : TLAbsMyLink
    {
        public override int Constructor
        {
            get
            {
                return 1818882030;
            }
        }

             public bool Contact {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Contact = BoolUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            BoolUtil.Serialize(Contact,bw);

        }
    }
}
