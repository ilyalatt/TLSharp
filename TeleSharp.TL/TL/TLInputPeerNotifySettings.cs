using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleSharp.TL;
namespace TeleSharp.TL
{
	[TLObject(1185074840)]
    public class TLInputPeerNotifySettings : TLObject
    {
        public override int Constructor
        {
            get
            {
                return 1185074840;
            }
        }

             public int MuteUntil {get;set;}
     public string Sound {get;set;}
     public bool ShowPreviews {get;set;}
     public int EventsMask {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            MuteUntil = br.ReadInt32();
Sound = StringUtil.Deserialize(br);
ShowPreviews = BoolUtil.Deserialize(br);
EventsMask = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(MuteUntil);
StringUtil.Serialize(Sound,bw);
BoolUtil.Serialize(ShowPreviews,bw);
bw.Write(EventsMask);

        }
    }
}
