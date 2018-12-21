using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleSharp.TL;
namespace TeleSharp.TL.Photos
{
	[TLObject(-285902432)]
    public class TLRequestUpdateProfilePhoto : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -285902432;
            }
        }

                public TLAbsInputPhoto Id {get;set;}
        public TLAbsInputPhotoCrop Crop {get;set;}
        public TLAbsUserProfilePhoto Response{ get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Id = (TLAbsInputPhoto)ObjectUtils.DeserializeObject(br);
Crop = (TLAbsInputPhotoCrop)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Id,bw);
ObjectUtils.SerializeObject(Crop,bw);

        }
		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (TLAbsUserProfilePhoto)ObjectUtils.DeserializeObject(br);

		}
    }
}
