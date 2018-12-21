using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleSharp.TL;
namespace TeleSharp.TL
{
	[TLObject(-1726817601)]
    public class TLInputMediaUploadedThumbVideo : TLAbsInputMedia
    {
        public override int Constructor
        {
            get
            {
                return -1726817601;
            }
        }

             public TLAbsInputFile File {get;set;}
     public TLAbsInputFile Thumb {get;set;}
     public int Duration {get;set;}
     public int W {get;set;}
     public int H {get;set;}
     public string MimeType {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            File = (TLAbsInputFile)ObjectUtils.DeserializeObject(br);
Thumb = (TLAbsInputFile)ObjectUtils.DeserializeObject(br);
Duration = br.ReadInt32();
W = br.ReadInt32();
H = br.ReadInt32();
MimeType = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(File,bw);
ObjectUtils.SerializeObject(Thumb,bw);
bw.Write(Duration);
bw.Write(W);
bw.Write(H);
StringUtil.Serialize(MimeType,bw);

        }
    }
}
