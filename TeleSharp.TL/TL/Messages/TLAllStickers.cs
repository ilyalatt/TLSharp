using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleSharp.TL;
namespace TeleSharp.TL.Messages
{
	[TLObject(-588304126)]
    public class TLAllStickers : TLAbsAllStickers
    {
        public override int Constructor
        {
            get
            {
                return -588304126;
            }
        }

             public string Hash {get;set;}
     public TLVector<TLStickerPack> Packs {get;set;}
     public TLVector<TLAbsDocument> Documents {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Hash = StringUtil.Deserialize(br);
Packs = (TLVector<TLStickerPack>)ObjectUtils.DeserializeVector<TLStickerPack>(br);
Documents = (TLVector<TLAbsDocument>)ObjectUtils.DeserializeVector<TLAbsDocument>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            StringUtil.Serialize(Hash,bw);
ObjectUtils.SerializeObject(Packs,bw);
ObjectUtils.SerializeObject(Documents,bw);

        }
    }
}
