using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleSharp.TL;
namespace TeleSharp.TL
{
	[TLObject(-1563278704)]
    public class TLMessageMediaVideo : TLAbsMessageMedia
    {
        public override int Constructor
        {
            get
            {
                return -1563278704;
            }
        }

             public TLAbsVideo Video {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Video = (TLAbsVideo)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Video,bw);

        }
    }
}
