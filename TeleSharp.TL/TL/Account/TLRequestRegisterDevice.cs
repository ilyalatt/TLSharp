using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleSharp.TL;
namespace TeleSharp.TL.Account
{
	[TLObject(1147957548)]
    public class TLRequestRegisterDevice : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 1147957548;
            }
        }

                public int TokenType {get;set;}
        public string Token {get;set;}
        public string DeviceModel {get;set;}
        public string SystemVersion {get;set;}
        public string AppVersion {get;set;}
        public bool AppSandbox {get;set;}
        public string LangCode {get;set;}
        public bool Response{ get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            TokenType = br.ReadInt32();
Token = StringUtil.Deserialize(br);
DeviceModel = StringUtil.Deserialize(br);
SystemVersion = StringUtil.Deserialize(br);
AppVersion = StringUtil.Deserialize(br);
AppSandbox = BoolUtil.Deserialize(br);
LangCode = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(TokenType);
StringUtil.Serialize(Token,bw);
StringUtil.Serialize(DeviceModel,bw);
StringUtil.Serialize(SystemVersion,bw);
StringUtil.Serialize(AppVersion,bw);
BoolUtil.Serialize(AppSandbox,bw);
StringUtil.Serialize(LangCode,bw);

        }
		public override void DeserializeResponse(BinaryReader br)
		{
			Response = BoolUtil.Deserialize(br);

		}
    }
}
