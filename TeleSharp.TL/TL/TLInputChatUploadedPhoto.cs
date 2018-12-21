using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleSharp.TL;
namespace TeleSharp.TL
{
	[TLObject(-1809496270)]
    public class TLInputChatUploadedPhoto : TLAbsInputChatPhoto
    {
        public override int Constructor
        {
            get
            {
                return -1809496270;
            }
        }

             public TLAbsInputFile File {get;set;}
     public TLAbsInputPhotoCrop Crop {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            File = (TLAbsInputFile)ObjectUtils.DeserializeObject(br);
Crop = (TLAbsInputPhotoCrop)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(File,bw);
ObjectUtils.SerializeObject(Crop,bw);

        }
    }
}
