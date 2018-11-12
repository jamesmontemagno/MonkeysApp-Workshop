using Newtonsoft.Json;
namespace MonkeyApp.Model
{
    public class Monkey
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [Microsoft.WindowsAzure.MobileServices.Version]
        public string Version { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Details { get; set; }
        public string Image { get; set; }
        public int Population { get; set; }
    }
}
