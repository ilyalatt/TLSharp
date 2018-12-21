using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleSharp.TL;
namespace TeleSharp.TL.Contacts
{
	[TLObject(-322001931)]
    public class TLLink : TLAbsLink
    {
        public override int Constructor
        {
            get
            {
                return -322001931;
            }
        }

             public Contacts.TLAbsMyLink MyLink {get;set;}
     public Contacts.TLAbsForeignLink ForeignLink {get;set;}
     public TLAbsUser User {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            MyLink = (Contacts.TLAbsMyLink)ObjectUtils.DeserializeObject(br);
ForeignLink = (Contacts.TLAbsForeignLink)ObjectUtils.DeserializeObject(br);
User = (TLAbsUser)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(MyLink,bw);
ObjectUtils.SerializeObject(ForeignLink,bw);
ObjectUtils.SerializeObject(User,bw);

        }
    }
}
