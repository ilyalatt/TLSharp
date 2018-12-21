using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleSharp.TL;
namespace TeleSharp.TL
{
	[TLObject(2108568544)]
    public class TLConfig : TLObject
    {
        public override int Constructor
        {
            get
            {
                return 2108568544;
            }
        }

             public int Date {get;set;}
     public int Expires {get;set;}
     public bool TestMode {get;set;}
     public int ThisDc {get;set;}
     public TLVector<TLDcOption> DcOptions {get;set;}
     public int ChatBigSize {get;set;}
     public int ChatSizeMax {get;set;}
     public int BroadcastSizeMax {get;set;}
     public TLVector<TLDisabledFeature> DisabledFeatures {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Date = br.ReadInt32();
Expires = br.ReadInt32();
TestMode = BoolUtil.Deserialize(br);
ThisDc = br.ReadInt32();
DcOptions = (TLVector<TLDcOption>)ObjectUtils.DeserializeVector<TLDcOption>(br);
ChatBigSize = br.ReadInt32();
ChatSizeMax = br.ReadInt32();
BroadcastSizeMax = br.ReadInt32();
DisabledFeatures = (TLVector<TLDisabledFeature>)ObjectUtils.DeserializeVector<TLDisabledFeature>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(Date);
bw.Write(Expires);
BoolUtil.Serialize(TestMode,bw);
bw.Write(ThisDc);
ObjectUtils.SerializeObject(DcOptions,bw);
bw.Write(ChatBigSize);
bw.Write(ChatSizeMax);
bw.Write(BroadcastSizeMax);
ObjectUtils.SerializeObject(DisabledFeatures,bw);

        }
    }
}
