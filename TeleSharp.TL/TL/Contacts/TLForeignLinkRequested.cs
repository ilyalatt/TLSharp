using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleSharp.TL;
namespace TeleSharp.TL.Contacts
{
	[TLObject(-1484775609)]
    public class TLForeignLinkRequested : TLAbsForeignLink
    {
        public override int Constructor
        {
            get
            {
                return -1484775609;
            }
        }

             public bool HasPhone {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            HasPhone = BoolUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            BoolUtil.Serialize(HasPhone,bw);

        }
    }
}
