using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleSharp.TL;
namespace TeleSharp.TL.Contacts
{
	[TLObject(90570766)]
    public class TLFound : TLObject
    {
        public override int Constructor
        {
            get
            {
                return 90570766;
            }
        }

             public TLVector<TLContactFound> Results {get;set;}
     public TLVector<TLAbsUser> Users {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Results = (TLVector<TLContactFound>)ObjectUtils.DeserializeVector<TLContactFound>(br);
Users = (TLVector<TLAbsUser>)ObjectUtils.DeserializeVector<TLAbsUser>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Results,bw);
ObjectUtils.SerializeObject(Users,bw);

        }
    }
}
