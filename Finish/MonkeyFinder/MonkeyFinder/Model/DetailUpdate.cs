using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MonkeyFinder
{
    public class DetailUpdate
    {
        [JsonProperty("newDetails")]
        public string NewDetails { get; set; }
    }
}
