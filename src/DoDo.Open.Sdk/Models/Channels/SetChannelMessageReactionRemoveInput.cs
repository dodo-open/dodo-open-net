using System;
using System.Collections.Generic;
using System.Text;
using DoDo.Open.Sdk.Models.Messages;
using Newtonsoft.Json;

namespace DoDo.Open.Sdk.Models.Channels
{
    public class SetChannelMessageReactionRemoveInput
    {
        /// <summary>
        /// 消息ID
        /// </summary>
        [JsonProperty("messageId")]
        public string MessageId { get; set; }

        /// <summary>
        /// 反应表情
        /// </summary>
        [JsonProperty("emoji")]
        public MessageModelEmoji ReactionEmoji { get; set; }

        /// <summary>
        /// DoDo号，不传或传空时表示移除机器人自身的反应
        /// </summary>
        [JsonProperty("dodoId")]
        public string DoDoId { get; set; }
    }
}
