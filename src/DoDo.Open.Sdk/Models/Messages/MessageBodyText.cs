using System.Text.Json.Serialization;

namespace DoDo.Open.Sdk.Models.Messages
{
    public class MessageBodyText: MessageBodyBase
    {
        /// <summary>
        /// 文字内容
        /// </summary>
        [JsonPropertyName("content")]
        public string Content { get; set; }
    }
}
