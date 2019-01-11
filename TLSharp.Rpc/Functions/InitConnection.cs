using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions
{
    sealed class InitConnection<TFunc, TFuncRes> : ITlFunc<TFuncRes> where TFunc : ITlFunc<TFuncRes>
    {
        public int ApiId { get; }
        public string DeviceModel { get; }
        public string SystemVersion { get; }
        public string AppVersion { get; }
        public string LangCode { get; }
        public TFunc Query { get; }
        
        public InitConnection(
            int apiId,
            Some<string> deviceModel,
            Some<string> systemVersion,
            Some<string> appVersion,
            Some<string> langCode,
            Some<TFunc> query
        ) {
            ApiId = apiId;
            DeviceModel = deviceModel;
            SystemVersion = systemVersion;
            AppVersion = appVersion;
            LangCode = langCode;
            Query = query;
        }
        
        

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x69796de9);
            Write(ApiId, bw, WriteInt);
            Write(DeviceModel, bw, WriteString);
            Write(SystemVersion, bw, WriteString);
            Write(AppVersion, bw, WriteString);
            Write(LangCode, bw, WriteString);
            Write(Query, bw, WriteSerializable);
        }
        
        TFuncRes ITlFunc<TFuncRes>.DeserializeResult(BinaryReader br) =>
            Query.DeserializeResult(br);
    }
}