using System.Collections.Generic;
using Newtonsoft.Json;

namespace TeleSharp.Generator
{
    class Method
    {
        public int Id { get; set; }
        [JsonProperty("method")]
        public string MethodName { get; set; }
        public List<Param> Params { get; set; }
        public string Type { get; set; }
    }

    class Param
    {
        public string Name { get; set; }
        public string Type { get; set; }
    }

    class Constructor
    {
        public int Id { get; set; }
        public string Predicate { get; set; }
        public List<Param> Params { get; set; }
        public string Type { get; set; }
    }

    class Schema
    {
        public List<Constructor> Constructors { get; set; }
        public List<Method> Methods { get; set; }
    }
}
