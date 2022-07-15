using System.Text.Json.Serialization;

namespace DoDo.Open.Sdk.Models.Messages
{
    public class MessageModelReference
    {
        /// <summary>
        /// 被回复消息ID
        /// </summary>
        [JsonPropertyName("messageId")]
        public string MessageId { get; set; }

        /// <summary>
        /// 被回复者DoDo号
        /// </summary>
        [JsonPropertyName("dodoId")]
        public string DodoId { get; set; }

        /// <summary>
        /// 被回复者群昵称
        /// </summary>
        [JsonPropertyName("nickName")]
        public string NickName { get; set; }
    }
}
