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
        public string SystemLangCode { get; }
        public string LangPack { get; }
        public string LangCode { get; }
        public Option<T.InputClientProxy> Proxy { get; }
        public TFunc Query { get; }
        
        public InitConnection(
            int apiId,
            Some<string> deviceModel,
            Some<string> systemVersion,
            Some<string> appVersion,
            Some<string> systemLangCode,
            Some<string> langPack,
            Some<string> langCode,
            Option<T.InputClientProxy> proxy,
            Some<TFunc> query
        ) {
            ApiId = apiId;
            DeviceModel = deviceModel;
            SystemVersion = systemVersion;
            AppVersion = appVersion;
            SystemLangCode = systemLangCode;
            LangPack = langPack;
            LangCode = langCode;
            Proxy = proxy;
            Query = query;
        }
        
        

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x785188b8);
            Write(MaskBit(0, Proxy), bw, WriteInt);
            Write(ApiId, bw, WriteInt);
            Write(DeviceModel, bw, WriteString);
            Write(SystemVersion, bw, WriteString);
            Write(AppVersion, bw, WriteString);
            Write(SystemLangCode, bw, WriteString);
            Write(LangPack, bw, WriteString);
            Write(LangCode, bw, WriteString);
            Write(Proxy, bw, WriteOption<T.InputClientProxy>(WriteSerializable));
            Write(Query, bw, WriteSerializable);
        }
        
        TFuncRes ITlFunc<TFuncRes>.DeserializeResult(BinaryReader br) =>
            Query.DeserializeResult(br);
    }
}