using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleSharp.TL;
namespace TeleSharp.TL
{
	[TLObject(1494273227)]
    public class TLDocumentAttributeVideo : TLAbsDocumentAttribute
    {
        public override int Constructor
        {
            get
            {
                return 1494273227;
            }
        }

             public int Duration {get;set;}
     public int W {get;set;}
     public int H {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Duration = br.ReadInt32();
W = br.ReadInt32();
H = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(Duration);
bw.Write(W);
bw.Write(H);

        }
    }
}
