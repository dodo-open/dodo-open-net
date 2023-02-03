using System.Text.Json.Serialization;

namespace DoDo.Open.Sdk.Models.WebHooks
{
    public class OpenWebHookInput
    {
        /// <summary>
        /// 机器人唯一标识
        /// </summary>
        [JsonPropertyName("clientId")]
        public string ClientId { get; set; }

        /// <summary>
        /// 消息Payload
        /// </summary>
        [JsonPropertyName("payload")]
        public string Payload { get; set; }
    }
}
