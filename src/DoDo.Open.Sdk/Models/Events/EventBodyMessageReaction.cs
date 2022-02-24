using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoDo.Open.Sdk.Models.Messages;
using Newtonsoft.Json;

namespace DoDo.Open.Sdk.Models.Events
{
    public class EventBodyMessageReaction
    {
        /// <summary>
        /// 来源群号
        /// </summary>
        [JsonProperty("islandId")]
        public string IslandId { get; set; }

        /// <summary>
        /// 来源频道号
        /// </summary>
        [JsonProperty("channelId")]
        public string ChannelId { get; set; }

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
        /// 成员信息
        /// </summary>
        [JsonProperty("member")]
        public MessageModelMember Member { get; set; }

        /// <summary>
        /// 反应目标
        /// </summary>
        [JsonProperty("reactionTarget")]
        public MessageReactionTarget ReactionTarget { get; set; }

        /// <summary>
        /// 反应表情
        /// </summary>
        [JsonProperty("reactionEmoji")]
        public MessageEmoji ReactionEmoji { get; set; }

    }
}
