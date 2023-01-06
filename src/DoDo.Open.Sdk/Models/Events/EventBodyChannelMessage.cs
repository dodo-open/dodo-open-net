using DoDo.Open.Sdk.Models.Messages;
namespace DoDo.Open.Sdk.Models.Events
{
    public class EventBodyChannelMessage<T> : EventBodyChannelBase
    where T : MessageBodyBase
    {
        /// <summary>
        /// 消息ID
        /// </summary>
        public string MessageId { get; set; }

        /// <summary>
        /// 回复信息
        /// </summary>
        public MessageModelReference Reference { get; set; }

        /// <summary>
        /// 消息类型，1：文字消息，2：图片消息，3：视频消息，4：分享消息，5：文件消息，6：卡片消息，7：红包消息
        /// </summary>
        public int MessageType { get; set; }

        /// <summary>
        /// 消息内容
        /// </summary>
        public T MessageBody { get; set; }
    }
}
