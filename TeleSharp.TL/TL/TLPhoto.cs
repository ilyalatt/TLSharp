using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleSharp.TL;
namespace TeleSharp.TL
{
	[TLObject(582313809)]
    public class TLPhoto : TLAbsPhoto
    {
        public override int Constructor
        {
            get
            {
                return 582313809;
            }
        }

             public long Id {get;set;}
     public long AccessHash {get;set;}
     public int UserId {get;set;}
     public int Date {get;set;}
     public string Caption {get;set;}
     public TLAbsGeoPoint Geo {get;set;}
     public TLVector<TLAbsPhotoSize> Sizes {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Id = br.ReadInt64();
AccessHash = br.ReadInt64();
UserId = br.ReadInt32();
Date = br.ReadInt32();
Caption = StringUtil.Deserialize(br);
Geo = (TLAbsGeoPoint)ObjectUtils.DeserializeObject(br);
Sizes = (TLVector<TLAbsPhotoSize>)ObjectUtils.DeserializeVector<TLAbsPhotoSize>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(Id);
bw.Write(AccessHash);
bw.Write(UserId);
bw.Write(Date);
StringUtil.Serialize(Caption,bw);
ObjectUtils.SerializeObject(Geo,bw);
ObjectUtils.SerializeObject(Sizes,bw);

        }
    }
}
