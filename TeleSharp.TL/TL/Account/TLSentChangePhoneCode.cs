using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleSharp.TL;
namespace TeleSharp.TL.Account
{
	[TLObject(-1527411636)]
    public class TLSentChangePhoneCode : TLObject
    {
        public override int Constructor
        {
            get
            {
                return -1527411636;
            }
        }

             public string PhoneCodeHash {get;set;}
     public int SendCallTimeout {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            PhoneCodeHash = StringUtil.Deserialize(br);
SendCallTimeout = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            StringUtil.Serialize(PhoneCodeHash,bw);
bw.Write(SendCallTimeout);

        }
    }
}
