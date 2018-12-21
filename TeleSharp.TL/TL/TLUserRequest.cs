using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleSharp.TL;
namespace TeleSharp.TL
{
	[TLObject(-640891665)]
    public class TLUserRequest : TLAbsUser
    {
        public override int Constructor
        {
            get
            {
                return -640891665;
            }
        }

             public int Id {get;set;}
     public string FirstName {get;set;}
     public string LastName {get;set;}
     public string Username {get;set;}
     public long AccessHash {get;set;}
     public string Phone {get;set;}
     public TLAbsUserProfilePhoto Photo {get;set;}
     public TLAbsUserStatus Status {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Id = br.ReadInt32();
FirstName = StringUtil.Deserialize(br);
LastName = StringUtil.Deserialize(br);
Username = StringUtil.Deserialize(br);
AccessHash = br.ReadInt64();
Phone = StringUtil.Deserialize(br);
Photo = (TLAbsUserProfilePhoto)ObjectUtils.DeserializeObject(br);
Status = (TLAbsUserStatus)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(Id);
StringUtil.Serialize(FirstName,bw);
StringUtil.Serialize(LastName,bw);
StringUtil.Serialize(Username,bw);
bw.Write(AccessHash);
StringUtil.Serialize(Phone,bw);
ObjectUtils.SerializeObject(Photo,bw);
ObjectUtils.SerializeObject(Status,bw);

        }
    }
}
