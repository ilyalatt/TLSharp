using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleSharp.TL;
namespace TeleSharp.TL.Auth
{
	[TLObject(1988976461)]
    public class TLRequestSendCode : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 1988976461;
            }
        }

                public string PhoneNumber {get;set;}
        public int SmsType {get;set;}
        public int ApiId {get;set;}
        public string ApiHash {get;set;}
        public string LangCode {get;set;}
        public Auth.TLAbsSentCode Response{ get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            PhoneNumber = StringUtil.Deserialize(br);
SmsType = br.ReadInt32();
ApiId = br.ReadInt32();
ApiHash = StringUtil.Deserialize(br);
LangCode = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            StringUtil.Serialize(PhoneNumber,bw);
bw.Write(SmsType);
bw.Write(ApiId);
StringUtil.Serialize(ApiHash,bw);
StringUtil.Serialize(LangCode,bw);

        }
		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (Auth.TLAbsSentCode)ObjectUtils.DeserializeObject(br);

		}
    }
}
