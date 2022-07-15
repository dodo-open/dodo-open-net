using System.Text.Json.Serialization;

namespace DoDo.Open.Sdk.Models
{
    public class OpenApiBaseInput
    {
        /// <summary>
        /// 机器人唯一标识
        /// </summary>
        [JsonPropertyName("clientId")]
        public string ClientId { get; set; }
    }
}
