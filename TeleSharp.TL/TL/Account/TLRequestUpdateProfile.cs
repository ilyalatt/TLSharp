using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleSharp.TL;
namespace TeleSharp.TL.Account
{
	[TLObject(-259486360)]
    public class TLRequestUpdateProfile : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -259486360;
            }
        }

                public string FirstName {get;set;}
        public string LastName {get;set;}
        public TLAbsUser Response{ get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            FirstName = StringUtil.Deserialize(br);
LastName = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            StringUtil.Serialize(FirstName,bw);
StringUtil.Serialize(LastName,bw);

        }
		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (TLAbsUser)ObjectUtils.DeserializeObject(br);

		}
    }
}
