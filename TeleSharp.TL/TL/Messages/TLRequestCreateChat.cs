using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleSharp.TL;
namespace TeleSharp.TL.Messages
{
	[TLObject(1100847854)]
    public class TLRequestCreateChat : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 1100847854;
            }
        }

                public TLVector<TLAbsInputUser> Users {get;set;}
        public string Title {get;set;}
        public Messages.TLAbsStatedMessage Response{ get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Users = (TLVector<TLAbsInputUser>)ObjectUtils.DeserializeVector<TLAbsInputUser>(br);
Title = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Users,bw);
StringUtil.Serialize(Title,bw);

        }
		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (Messages.TLAbsStatedMessage)ObjectUtils.DeserializeObject(br);

		}
    }
}
