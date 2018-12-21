using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleSharp.TL;
namespace TeleSharp.TL
{
	[TLObject(1997575642)]
    public class TLUserFull : TLObject
    {
        public override int Constructor
        {
            get
            {
                return 1997575642;
            }
        }

             public TLAbsUser User {get;set;}
     public Contacts.TLAbsLink Link {get;set;}
     public TLAbsPhoto ProfilePhoto {get;set;}
     public TLAbsPeerNotifySettings NotifySettings {get;set;}
     public bool Blocked {get;set;}
     public string RealFirstName {get;set;}
     public string RealLastName {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            User = (TLAbsUser)ObjectUtils.DeserializeObject(br);
Link = (Contacts.TLAbsLink)ObjectUtils.DeserializeObject(br);
ProfilePhoto = (TLAbsPhoto)ObjectUtils.DeserializeObject(br);
NotifySettings = (TLAbsPeerNotifySettings)ObjectUtils.DeserializeObject(br);
Blocked = BoolUtil.Deserialize(br);
RealFirstName = StringUtil.Deserialize(br);
RealLastName = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(User,bw);
ObjectUtils.SerializeObject(Link,bw);
ObjectUtils.SerializeObject(ProfilePhoto,bw);
ObjectUtils.SerializeObject(NotifySettings,bw);
BoolUtil.Serialize(Blocked,bw);
StringUtil.Serialize(RealFirstName,bw);
StringUtil.Serialize(RealLastName,bw);

        }
    }
}
