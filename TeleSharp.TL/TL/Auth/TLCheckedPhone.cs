using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleSharp.TL;
namespace TeleSharp.TL.Auth
{
	[TLObject(-486486981)]
    public class TLCheckedPhone : TLObject
    {
        public override int Constructor
        {
            get
            {
                return -486486981;
            }
        }

             public bool PhoneRegistered {get;set;}
     public bool PhoneInvited {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            PhoneRegistered = BoolUtil.Deserialize(br);
PhoneInvited = BoolUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            BoolUtil.Serialize(PhoneRegistered,bw);
BoolUtil.Serialize(PhoneInvited,bw);

        }
    }
}
