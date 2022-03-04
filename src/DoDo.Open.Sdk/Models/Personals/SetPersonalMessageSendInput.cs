﻿using DoDo.Open.Sdk.Models.Messages;
using Newtonsoft.Json;

namespace DoDo.Open.Sdk.Models.Personals
{
    public class SetPersonalMessageSendInput<T>
        where T : MessageBodyBase
    {
        /// <summary>
        /// DoDo号
        /// </summary>
        [JsonProperty("dodoId")]
        public string DoDoId { get; set; }

        /// <summary>
        /// 消息类型，1：文本消息，2：图片消息，3：视频消息
        /// </summary>
        [JsonProperty("messageType")]
        public int MessageType
        {
            get
            {
                if (MessageBody is MessageBodyPicture)
                {
                    return MessageTypeConst.Picture;
                }
                else if (MessageBody is MessageBodyVideo)
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
    }
}
