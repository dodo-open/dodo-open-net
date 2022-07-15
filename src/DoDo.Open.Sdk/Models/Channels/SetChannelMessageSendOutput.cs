using System.Text.Json.Serialization;

namespace DoDo.Open.Sdk.Models.Channels
{
    public class SetChannelMessageSendOutput
    {
        /// <summary>
        /// 消息ID
        /// </summary>
        [JsonPropertyName("messageId")]
        public string MessageId { get; set; }
    }
}
