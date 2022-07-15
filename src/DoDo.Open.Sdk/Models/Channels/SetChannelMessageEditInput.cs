using DoDo.Open.Sdk.Models.Messages;
using System.Text.Json.Serialization;

namespace DoDo.Open.Sdk.Models.Channels
{
    public class SetChannelMessageEditInput<T>
        where T : MessageBodyBase
    {
        /// <summary>
        /// 预更新消息ID
        /// </summary>
        [JsonPropertyName("messageId")]
        public string MessageId { get; set; }

        /// <summary>
        /// 消息类型，1：文字消息，目前仅支持编辑文字消息
        /// </summary>
        [JsonPropertyName("messageType")]
        public int MessageType => MessageTypeConst.Text;

        /// <summary>
        /// 消息内容
        /// </summary>
        [JsonPropertyName("messageBody")]
        public T MessageBody { get; set; }
    }
}
