using DoDo.Open.Sdk.Models.Messages;
namespace DoDo.Open.Sdk.Models.Channels
{
    public class SetChannelMessageEditInput<T>
        where T : MessageBodyBase
    {
        /// <summary>
        /// 预更新消息ID
        /// </summary>
        public string MessageId { get; set; }

        /// <summary>
        /// 消息类型，1：文字消息，目前仅支持编辑文字消息
        /// </summary>
        public int MessageType => MessageTypeConst.Text;

        /// <summary>
        /// 消息内容
        /// </summary>
        public T MessageBody { get; set; }
    }
}
