using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleSharp.TL;
namespace TeleSharp.TL.Messages
{
	[TLObject(-1262720843)]
    public class TLRequestEditChatTitle : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -1262720843;
            }
        }

                public int ChatId {get;set;}
        public string Title {get;set;}
        public Messages.TLAbsStatedMessage Response{ get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            ChatId = br.ReadInt32();
Title = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(ChatId);
StringUtil.Serialize(Title,bw);

        }
		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (Messages.TLAbsStatedMessage)ObjectUtils.DeserializeObject(br);

		}
    }
}
