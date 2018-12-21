using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleSharp.TL;
namespace TeleSharp.TL.Auth
{
	[TLObject(-155815004)]
    public class TLAuthorization : TLObject
    {
        public override int Constructor
        {
            get
            {
                return -155815004;
            }
        }

             public int Expires {get;set;}
     public TLAbsUser User {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Expires = br.ReadInt32();
User = (TLAbsUser)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(Expires);
ObjectUtils.SerializeObject(User,bw);

        }
    }
}
