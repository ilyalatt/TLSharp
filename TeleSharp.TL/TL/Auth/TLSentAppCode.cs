using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleSharp.TL;
namespace TeleSharp.TL.Auth
{
	[TLObject(-484053553)]
    public class TLSentAppCode : TLAbsSentCode
    {
        public override int Constructor
        {
            get
            {
                return -484053553;
            }
        }

             public bool PhoneRegistered {get;set;}
     public string PhoneCodeHash {get;set;}
     public int SendCallTimeout {get;set;}
     public bool IsPassword {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            PhoneRegistered = BoolUtil.Deserialize(br);
PhoneCodeHash = StringUtil.Deserialize(br);
SendCallTimeout = br.ReadInt32();
IsPassword = BoolUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            BoolUtil.Serialize(PhoneRegistered,bw);
StringUtil.Serialize(PhoneCodeHash,bw);
bw.Write(SendCallTimeout);
BoolUtil.Serialize(IsPassword,bw);

        }
    }
}
