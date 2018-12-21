using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleSharp.TL;
namespace TeleSharp.TL
{
	[TLObject(-1690012891)]
    public class TLInputPeerForeign : TLAbsInputPeer
    {
        public override int Constructor
        {
            get
            {
                return -1690012891;
            }
        }

             public int UserId {get;set;}
     public long AccessHash {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            UserId = br.ReadInt32();
AccessHash = br.ReadInt64();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(UserId);
bw.Write(AccessHash);

        }
    }
}
