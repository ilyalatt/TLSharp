using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleSharp.TL;
namespace TeleSharp.TL
{
	[TLObject(1369737882)]
    public class TLUpdateContactLink : TLAbsUpdate
    {
        public override int Constructor
        {
            get
            {
                return 1369737882;
            }
        }

             public int UserId {get;set;}
     public Contacts.TLAbsMyLink MyLink {get;set;}
     public Contacts.TLAbsForeignLink ForeignLink {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            UserId = br.ReadInt32();
MyLink = (Contacts.TLAbsMyLink)ObjectUtils.DeserializeObject(br);
ForeignLink = (Contacts.TLAbsForeignLink)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(UserId);
ObjectUtils.SerializeObject(MyLink,bw);
ObjectUtils.SerializeObject(ForeignLink,bw);

        }
    }
}
