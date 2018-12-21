using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleSharp.TL;
namespace TeleSharp.TL.Photos
{
	[TLObject(-720397176)]
    public class TLRequestUploadProfilePhoto : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -720397176;
            }
        }

                public TLAbsInputFile File {get;set;}
        public string Caption {get;set;}
        public TLAbsInputGeoPoint GeoPoint {get;set;}
        public TLAbsInputPhotoCrop Crop {get;set;}
        public Photos.TLPhoto Response{ get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            File = (TLAbsInputFile)ObjectUtils.DeserializeObject(br);
Caption = StringUtil.Deserialize(br);
GeoPoint = (TLAbsInputGeoPoint)ObjectUtils.DeserializeObject(br);
Crop = (TLAbsInputPhotoCrop)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(File,bw);
StringUtil.Serialize(Caption,bw);
ObjectUtils.SerializeObject(GeoPoint,bw);
ObjectUtils.SerializeObject(Crop,bw);

        }
		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (Photos.TLPhoto)ObjectUtils.DeserializeObject(br);

		}
    }
}
