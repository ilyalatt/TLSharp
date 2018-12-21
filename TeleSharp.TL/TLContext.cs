using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TeleSharp.TL
{
    public static class TLContext
    {
        static readonly Dictionary<int, Type> Types;

        static TLContext()
        {
            Types = new Dictionary<int, Type>();
            Types = (from t in Assembly.GetExecutingAssembly().GetTypes()
                     where t.IsClass && t.Namespace.StartsWith("TeleSharp.TL")
                     where t.IsSubclassOf(typeof(TLObject))
                     where t.GetCustomAttribute(typeof(TLObjectAttribute)) != null
                     select t).ToDictionary(x => ((TLObjectAttribute)x.GetCustomAttribute(typeof(TLObjectAttribute))).Constructor, x => x);
        }

        public static Type GetType(int constructor)
        {
            return Types[constructor];
        }
    }
}
