using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Help
{
    public sealed class SaveAppLog : Record<SaveAppLog>, ITlFunc<bool>
    {
        public Arr<T.InputAppEvent> Events { get; }
        
        public SaveAppLog(
            Some<Arr<T.InputAppEvent>> events
        ) {
            Events = events;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x6f02f748);
            Write(Events, bw, WriteVector<T.InputAppEvent>(WriteSerializable));
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}