using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleSharp.TL;
namespace TeleSharp.TL
{
	[TLObject(-1456734682)]
    public class TLUpdateDeleteMessages : TLAbsUpdate
    {
        public override int Constructor
        {
            get
            {
                return -1456734682;
            }
        }

             public TLVector<int> Messages {get;set;}
     public int Pts {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Messages = (TLVector<int>)ObjectUtils.DeserializeVector<int>(br);
Pts = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Messages,bw);
bw.Write(Pts);

        }
    }
}
