using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleSharp.TL;
namespace TeleSharp.TL
{
	[TLObject(85215461)]
    public class TLDocumentAttributeAudio : TLAbsDocumentAttribute
    {
        public override int Constructor
        {
            get
            {
                return 85215461;
            }
        }

             public int Duration {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Duration = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(Duration);

        }
    }
}
