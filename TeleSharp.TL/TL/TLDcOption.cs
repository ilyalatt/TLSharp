using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleSharp.TL;
namespace TeleSharp.TL
{
	[TLObject(784507964)]
    public class TLDcOption : TLObject
    {
        public override int Constructor
        {
            get
            {
                return 784507964;
            }
        }

             public int Id {get;set;}
     public string Hostname {get;set;}
     public string IpAddress {get;set;}
     public int Port {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Id = br.ReadInt32();
Hostname = StringUtil.Deserialize(br);
IpAddress = StringUtil.Deserialize(br);
Port = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(Id);
StringUtil.Serialize(Hostname,bw);
StringUtil.Serialize(IpAddress,bw);
bw.Write(Port);

        }
    }
}
