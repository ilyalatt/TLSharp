using System;
using System.IO;

namespace TeleSharp.TL
{
    public class TLObjectAttribute : Attribute
    {
        public int Constructor { get; private set; }
        
        public TLObjectAttribute(int constructor)
        {
            this.Constructor = constructor;
        }
    }

    public abstract class TLObject
    {
        public abstract int Constructor { get; }
        public abstract void SerializeBody(BinaryWriter bw);
        public abstract void DeserializeBody(BinaryReader br);
        public byte[] Serialize()
        {
            using (var m = new MemoryStream())
            using (var bw = new BinaryWriter(m))
            {
                Serialize(bw);
                bw.Close();
                m.Close();
                return m.ToArray();
            }
        }
        public void Serialize(BinaryWriter writer)
        {
            writer.Write(Constructor);
            SerializeBody(writer);
        }
        public void Deserialize(BinaryReader reader)
        {
            var constructorId = reader.ReadInt32();
            if (constructorId != Constructor)
                throw new InvalidDataException("Constructor Invalid");
            DeserializeBody(reader);
        }
    }
}
