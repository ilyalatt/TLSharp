using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleSharp.TL;
namespace TeleSharp.TL
{
	[TLObject(942527460)]
    public class TLUpdateServiceNotification : TLAbsUpdate
    {
        public override int Constructor
        {
            get
            {
                return 942527460;
            }
        }

             public string Type {get;set;}
     public string Message {get;set;}
     public TLAbsMessageMedia Media {get;set;}
     public bool Popup {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Type = StringUtil.Deserialize(br);
Message = StringUtil.Deserialize(br);
Media = (TLAbsMessageMedia)ObjectUtils.DeserializeObject(br);
Popup = BoolUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            StringUtil.Serialize(Type,bw);
StringUtil.Serialize(Message,bw);
ObjectUtils.SerializeObject(Media,bw);
BoolUtil.Serialize(Popup,bw);

        }
    }
}
