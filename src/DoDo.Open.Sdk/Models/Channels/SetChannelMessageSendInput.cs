using System;
using DoDo.Open.Sdk.Models.Messages;
namespace DoDo.Open.Sdk.Models.Channels
{
    public class SetChannelMessageSendInput<T>
    where T : MessageBodyBase
    {
        /// <summary>
        /// 频道ID
        /// </summary>
        public string ChannelId { get; set; }

        /// <summary>
        /// 消息类型，1：文字消息，2：图片消息，3：视频消息，6：卡片消息
        /// </summary>
        public int MessageType
        {
            get
            {
                if (MessageBody is MessageBodyText)
                {
                    return MessageTypeConst.Text;
                }
                else if (MessageBody is MessageBodyPicture)
                {
                    return MessageTypeConst.Picture;
                }
                else if (MessageBody is MessageBodyVideo)
                {
                    return MessageTypeConst.Video;
                }
                else if (MessageBody is MessageBodyCard)
                {
                    return MessageTypeConst.Card;
                }

                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// 消息内容
        /// </summary>
        public T MessageBody { get; set; }

        /// <summary>
        /// 引用消息ID
        /// </summary>
        public string ReferencedMessageId { get; set; }

        /// <summary>
        /// DoDoID，非必传，如果传了，则给该成员发送频道私信
        /// </summary>
        public string DodoSourceId { get; set; }
    }
}
