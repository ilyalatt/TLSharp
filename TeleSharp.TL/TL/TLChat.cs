using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleSharp.TL;
namespace TeleSharp.TL
{
	[TLObject(1855757255)]
    public class TLChat : TLAbsChat
    {
        public override int Constructor
        {
            get
            {
                return 1855757255;
            }
        }

             public int Id {get;set;}
     public string Title {get;set;}
     public TLAbsChatPhoto Photo {get;set;}
     public int ParticipantsCount {get;set;}
     public int Date {get;set;}
     public bool Left {get;set;}
     public int Version {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Id = br.ReadInt32();
Title = StringUtil.Deserialize(br);
Photo = (TLAbsChatPhoto)ObjectUtils.DeserializeObject(br);
ParticipantsCount = br.ReadInt32();
Date = br.ReadInt32();
Left = BoolUtil.Deserialize(br);
Version = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(Id);
StringUtil.Serialize(Title,bw);
ObjectUtils.SerializeObject(Photo,bw);
bw.Write(ParticipantsCount);
bw.Write(Date);
BoolUtil.Serialize(Left,bw);
bw.Write(Version);

        }
    }
}
