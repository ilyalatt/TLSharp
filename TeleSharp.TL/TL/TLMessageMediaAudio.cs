using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleSharp.TL;
namespace TeleSharp.TL
{
	[TLObject(-961117440)]
    public class TLMessageMediaAudio : TLAbsMessageMedia
    {
        public override int Constructor
        {
            get
            {
                return -961117440;
            }
        }

             public TLAbsAudio Audio {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Audio = (TLAbsAudio)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Audio,bw);

        }
    }
}
