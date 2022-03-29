using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DoDo.Open.Sdk.Models.Messages
{
    public class MessageModelReference
    {
        /// <summary>
        /// 被回复消息ID
        /// </summary>
        [JsonProperty("messageId")]
        public string MessageId { get; set; }

        /// <summary>
        /// 被回复者DoDo号
        /// </summary>
        [JsonProperty("dodoId")]
        public string DodoId { get; set; }

        /// <summary>
        /// 被回复者在群昵称
        /// </summary>
        [JsonProperty("nickName")]
        public string NickName { get; set; }
    }
}
