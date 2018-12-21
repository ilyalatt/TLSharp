using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleSharp.TL;
namespace TeleSharp.TL
{
	[TLObject(-1610888)]
    public class TLInputMediaUploadedDocument : TLAbsInputMedia
    {
        public override int Constructor
        {
            get
            {
                return -1610888;
            }
        }

             public TLAbsInputFile File {get;set;}
     public string MimeType {get;set;}
     public TLVector<TLAbsDocumentAttribute> Attributes {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            File = (TLAbsInputFile)ObjectUtils.DeserializeObject(br);
MimeType = StringUtil.Deserialize(br);
Attributes = (TLVector<TLAbsDocumentAttribute>)ObjectUtils.DeserializeVector<TLAbsDocumentAttribute>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(File,bw);
StringUtil.Serialize(MimeType,bw);
ObjectUtils.SerializeObject(Attributes,bw);

        }
    }
}
