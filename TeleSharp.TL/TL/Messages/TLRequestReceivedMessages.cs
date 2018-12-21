using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleSharp.TL;
namespace TeleSharp.TL.Messages
{
	[TLObject(682347368)]
    public class TLRequestReceivedMessages : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 682347368;
            }
        }

                public int MaxId {get;set;}
        public TLVector<int> Response{ get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            MaxId = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(MaxId);

        }
		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (TLVector<int>)ObjectUtils.DeserializeVector<int>(br);

		}
    }
}
