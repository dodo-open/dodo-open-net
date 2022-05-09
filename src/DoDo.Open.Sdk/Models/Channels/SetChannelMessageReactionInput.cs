using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoDo.Open.Sdk.Models.Messages;
using Newtonsoft.Json;

namespace DoDo.Open.Sdk.Models.Channels
{
    public class SetChannelMessageReactionInput
    {
        /// <summary>
        /// 反应对象
        /// </summary>
        [JsonProperty("reactionTarget")]
        public MessageModelReactionTarget ReactionTarget { get; set; }

        /// <summary>
        /// 反应表情
        /// </summary>
        [JsonProperty("reactionEmoji")]
        public MessageModelEmoji ReactionEmoji { get; set; }

        /// <summary>
        /// 反应类型，0：删除，1：新增
        /// </summary>
        [JsonProperty("reactionType")]
        public int ReactionType { get; set; }
    }
}
