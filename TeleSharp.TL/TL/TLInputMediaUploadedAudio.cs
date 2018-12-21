using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleSharp.TL;
namespace TeleSharp.TL
{
	[TLObject(1313442987)]
    public class TLInputMediaUploadedAudio : TLAbsInputMedia
    {
        public override int Constructor
        {
            get
            {
                return 1313442987;
            }
        }

             public TLAbsInputFile File {get;set;}
     public int Duration {get;set;}
     public string MimeType {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            File = (TLAbsInputFile)ObjectUtils.DeserializeObject(br);
Duration = br.ReadInt32();
MimeType = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(File,bw);
bw.Write(Duration);
StringUtil.Serialize(MimeType,bw);

        }
    }
}
