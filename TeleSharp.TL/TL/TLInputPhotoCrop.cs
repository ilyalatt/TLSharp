using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleSharp.TL;
namespace TeleSharp.TL
{
	[TLObject(-644787419)]
    public class TLInputPhotoCrop : TLAbsInputPhotoCrop
    {
        public override int Constructor
        {
            get
            {
                return -644787419;
            }
        }

             public double CropLeft {get;set;}
     public double CropTop {get;set;}
     public double CropWidth {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            CropLeft = br.ReadDouble();
CropTop = br.ReadDouble();
CropWidth = br.ReadDouble();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(CropLeft);
bw.Write(CropTop);
bw.Write(CropWidth);

        }
    }
}
