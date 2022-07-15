using DoDo.Open.Sdk.Models.Messages;
namespace DoDo.Open.Sdk.Models.Events
{
    public class EventBodyPersonalMessage<T> : EventBodyBase
        where T : MessageBodyBase
    {
        /// <summary>
        /// 来源DoDo号
        /// </summary>
        public string DodoId { get; set; }

        /// <summary>
        /// 个人信息
        /// </summary>
        public MessageModelPersonal Personal { get; set; }

        /// <summary>
        /// 消息ID
        /// </summary>
        public string MessageId { get; set; }

        /// <summary>
        /// 消息类型，1：文字消息，2：图片消息，3：视频消息
        /// </summary>
        public int MessageType { get; set; }

        /// <summary>
        /// 消息内容
        /// </summary>
        public T MessageBody { get; set; }
    }
}
