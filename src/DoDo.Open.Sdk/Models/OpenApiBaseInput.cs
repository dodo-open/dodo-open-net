using Newtonsoft.Json;

namespace DoDo.Open.Sdk.Models
{
    public class OpenApiBaseInput
    {
        /// <summary>
        /// 机器人唯一标识
        /// </summary>
        [JsonProperty("clientId")]
        public string ClientId { get; set; }
    }
}
