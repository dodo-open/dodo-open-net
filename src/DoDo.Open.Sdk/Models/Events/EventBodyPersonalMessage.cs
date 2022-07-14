using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoDo.Open.Sdk.Models.Messages;
using Newtonsoft.Json;

namespace DoDo.Open.Sdk.Models.Events
{
    public class EventBodyPersonalMessage<T> : EventBodyBase
        where T : MessageBodyBase
    {
        /// <summary>
        /// 来源DoDo号
        /// </summary>
        [JsonProperty("dodoId")]
        public string DodoId { get; set; }

        /// <summary>
        /// 个人信息
        /// </summary>
        [JsonProperty("personal")]
        public MessageModelPersonal Personal { get; set; }

        /// <summary>
        /// 消息ID
        /// </summary>
        [JsonProperty("messageId")]
        public string MessageId { get; set; }

        /// <summary>
        /// 消息类型，1：文字消息，2：图片消息，3：视频消息
        /// </summary>
        [JsonProperty("messageType")]
        public int MessageType { get; set; }

        /// <summary>
        /// 消息内容
        /// </summary>
        [JsonProperty("messageBody")]
        public T MessageBody { get; set; }
    }
}
