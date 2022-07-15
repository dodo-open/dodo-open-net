using System.Text.Json.Serialization;

namespace DoDo.Open.Sdk.Models.Channels
{
    public class SetChannelMessageWithdrawInput
    {
        /// <summary>
        /// 消息ID
        /// </summary>
        [JsonPropertyName("messageId")]
        public string MessageId { get; set; }

        /// <summary>
        /// 撤回理由
        /// </summary>
        [JsonPropertyName("reason")]
        public string Reason { get; set; }
    }
}
