using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleSharp.TL;
namespace TeleSharp.TL
{
	[TLObject(-1895411046)]
    public class TLUpdateNewAuthorization : TLAbsUpdate
    {
        public override int Constructor
        {
            get
            {
                return -1895411046;
            }
        }

             public long AuthKeyId {get;set;}
     public int Date {get;set;}
     public string Device {get;set;}
     public string Location {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            AuthKeyId = br.ReadInt64();
Date = br.ReadInt32();
Device = StringUtil.Deserialize(br);
Location = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(AuthKeyId);
bw.Write(Date);
StringUtil.Serialize(Device,bw);
StringUtil.Serialize(Location,bw);

        }
    }
}
