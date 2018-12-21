using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleSharp.TL;
namespace TeleSharp.TL
{
	[TLObject(-1293828344)]
    public class TLInputChatPhoto : TLAbsInputChatPhoto
    {
        public override int Constructor
        {
            get
            {
                return -1293828344;
            }
        }

             public TLAbsInputPhoto Id {get;set;}
     public TLAbsInputPhotoCrop Crop {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Id = (TLAbsInputPhoto)ObjectUtils.DeserializeObject(br);
Crop = (TLAbsInputPhotoCrop)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Id,bw);
ObjectUtils.SerializeObject(Crop,bw);

        }
    }
}
