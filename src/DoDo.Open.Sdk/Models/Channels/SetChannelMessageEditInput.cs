using DoDo.Open.Sdk.Models.Messages;
using Newtonsoft.Json;

namespace DoDo.Open.Sdk.Models.Channels
{
    public class SetChannelMessageEditInput<T>
        where T : MessageBodyBase
    {
        /// <summary>
        /// 预更新消息ID
        /// </summary>
        [JsonProperty("messageId")]
        public string MessageId { get; set; }

        /// <summary>
        /// 消息类型，1：文本消息，目前仅支持更新文本消息
        /// </summary>
        [JsonProperty("messageType")]
        public int MessageType => MessageTypeConst.Text;

        /// <summary>
        /// 消息内容
        /// </summary>
        [JsonProperty("messageBody")]
        public T MessageBody { get; set; }
    }
}
