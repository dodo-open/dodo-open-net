using System;
using DoDo.Open.Sdk.Models.Messages;
namespace DoDo.Open.Sdk.Models.Personals
{
    public class SetPersonalMessageSendInput<T>
        where T : MessageBodyBase
    {
        /// <summary>
        /// DoDo号
        /// </summary>
        public string DodoId { get; set; }

        /// <summary>
        /// 消息类型，1：文字消息，2：图片消息，3：视频消息
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

                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// 消息内容
        /// </summary>
        public T MessageBody { get; set; }
    }
}
