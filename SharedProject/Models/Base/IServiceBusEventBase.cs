using Newtonsoft.Json;

namespace SharedProject.Models.Base
{
    public interface IServiceBusEventBase
    {
        [JsonIgnore]
        public string Topic { get; }

        [JsonIgnore]
        public string Subject { get; }
    }
}
