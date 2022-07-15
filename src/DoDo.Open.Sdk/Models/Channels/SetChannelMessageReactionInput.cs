using DoDo.Open.Sdk.Models.Messages;
using System.Text.Json.Serialization;

namespace DoDo.Open.Sdk.Models.Channels
{
    public class SetChannelMessageReactionInput
    {
        /// <summary>
        /// 反应对象
        /// </summary>
        [JsonPropertyName("reactionTarget")]
        public MessageModelReactionTarget ReactionTarget { get; set; }

        /// <summary>
        /// 反应表情
        /// </summary>
        [JsonPropertyName("reactionEmoji")]
        public MessageModelEmoji ReactionEmoji { get; set; }

        /// <summary>
        /// 反应类型，0：删除，1：新增
        /// </summary>
        [JsonPropertyName("reactionType")]
        public int ReactionType { get; set; }
    }
}
