using DoDo.Open.Sdk.Models.Messages;
using Newtonsoft.Json;

namespace DoDo.Open.Sdk.Models.Channels
{
    public class SendChannelMessageInput<T>
    where T : MessageBase
    {
        /// <summary>
        /// 频道号
        /// </summary>
        [JsonProperty("channelId")]
        public string ChannelId { get; set; }

        /// <summary>
        /// 消息类型，1：文本消息，2：图片消息，3：视频消息
        /// </summary>
        [JsonProperty("messageType")]
        public int MessageType
        {
            get
            {
                if (MessageBody is MessagePicture)
                {
                    return MessageTypeConst.Picture;
                }
                else if (MessageBody is MessageVideo)
                {
                    return MessageTypeConst.Video;
                }

                return MessageTypeConst.Text;
            }
        }

        /// <summary>
        /// 消息内容
        /// </summary>
        [JsonProperty("messageBody")]
        public T MessageBody { get; set; }

        /// <summary>
        /// 引用消息ID
        /// </summary>
        [JsonProperty("referencedMessageId")]
        public string ReferencedMessageId { get; set; }
    }
}
