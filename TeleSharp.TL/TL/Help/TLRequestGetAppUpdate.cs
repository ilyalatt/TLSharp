using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleSharp.TL;
namespace TeleSharp.TL.Help
{
	[TLObject(-938300290)]
    public class TLRequestGetAppUpdate : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -938300290;
            }
        }

                public string DeviceModel {get;set;}
        public string SystemVersion {get;set;}
        public string AppVersion {get;set;}
        public string LangCode {get;set;}
        public Help.TLAbsAppUpdate Response{ get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            DeviceModel = StringUtil.Deserialize(br);
SystemVersion = StringUtil.Deserialize(br);
AppVersion = StringUtil.Deserialize(br);
LangCode = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            StringUtil.Serialize(DeviceModel,bw);
StringUtil.Serialize(SystemVersion,bw);
StringUtil.Serialize(AppVersion,bw);
StringUtil.Serialize(LangCode,bw);

        }
		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (Help.TLAbsAppUpdate)ObjectUtils.DeserializeObject(br);

		}
    }
}
