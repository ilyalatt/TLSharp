using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleSharp.TL;
namespace TeleSharp.TL.Messages
{
	[TLObject(-772484260)]
    public class TLSentMessage : TLAbsSentMessage
    {
        public override int Constructor
        {
            get
            {
                return -772484260;
            }
        }

             public int Id {get;set;}
     public int Date {get;set;}
     public int Pts {get;set;}
     public int Seq {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Id = br.ReadInt32();
Date = br.ReadInt32();
Pts = br.ReadInt32();
Seq = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(Id);
bw.Write(Date);
bw.Write(Pts);
bw.Write(Seq);

        }
    }
}
