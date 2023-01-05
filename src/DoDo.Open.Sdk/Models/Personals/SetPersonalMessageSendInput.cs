using System;
using DoDo.Open.Sdk.Consts;
using DoDo.Open.Sdk.Models.Messages;
namespace DoDo.Open.Sdk.Models.Personals
{
    public class SetPersonalMessageSendInput<T>
        where T : MessageBodyBase
    {
        /// <summary>
        /// 来源群ID
        /// </summary>
        public string IslandSourceId { get; set; }

        /// <summary>
        /// DoDoID
        /// </summary>
        public string DodoSourceId { get; set; }

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
