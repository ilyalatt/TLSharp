using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleSharp.TL;
namespace TeleSharp.TL
{
	[TLObject(767900285)]
    public class TLInputMediaUploadedPhoto : TLAbsInputMedia
    {
        public override int Constructor
        {
            get
            {
                return 767900285;
            }
        }

             public TLAbsInputFile File {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            File = (TLAbsInputFile)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(File,bw);

        }
    }
}
