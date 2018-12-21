using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleSharp.TL;
namespace TeleSharp.TL.Messages
{
	[TLObject(-1210173710)]
    public class TLAffectedHistory : TLObject
    {
        public override int Constructor
        {
            get
            {
                return -1210173710;
            }
        }

             public int Pts {get;set;}
     public int Seq {get;set;}
     public int Offset {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Pts = br.ReadInt32();
Seq = br.ReadInt32();
Offset = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(Pts);
bw.Write(Seq);
bw.Write(Offset);

        }
    }
}
