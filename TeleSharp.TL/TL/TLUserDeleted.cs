using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleSharp.TL;
namespace TeleSharp.TL
{
	[TLObject(-704549510)]
    public class TLUserDeleted : TLAbsUser
    {
        public override int Constructor
        {
            get
            {
                return -704549510;
            }
        }

             public int Id {get;set;}
     public string FirstName {get;set;}
     public string LastName {get;set;}
     public string Username {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Id = br.ReadInt32();
FirstName = StringUtil.Deserialize(br);
LastName = StringUtil.Deserialize(br);
Username = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(Id);
StringUtil.Serialize(FirstName,bw);
StringUtil.Serialize(LastName,bw);
StringUtil.Serialize(Username,bw);

        }
    }
}
