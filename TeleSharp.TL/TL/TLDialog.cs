using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleSharp.TL;
namespace TeleSharp.TL
{
	[TLObject(-1422222932)]
    public class TLDialog : TLObject
    {
        public override int Constructor
        {
            get
            {
                return -1422222932;
            }
        }

             public TLAbsPeer Peer {get;set;}
     public int TopMessage {get;set;}
     public int UnreadCount {get;set;}
     public TLAbsPeerNotifySettings NotifySettings {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Peer = (TLAbsPeer)ObjectUtils.DeserializeObject(br);
TopMessage = br.ReadInt32();
UnreadCount = br.ReadInt32();
NotifySettings = (TLAbsPeerNotifySettings)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Peer,bw);
bw.Write(TopMessage);
bw.Write(UnreadCount);
ObjectUtils.SerializeObject(NotifySettings,bw);

        }
    }
}
