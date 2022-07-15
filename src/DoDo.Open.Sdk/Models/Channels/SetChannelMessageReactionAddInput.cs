using DoDo.Open.Sdk.Models.Messages;
using System.Text.Json.Serialization;

namespace DoDo.Open.Sdk.Models.Channels
{
    public class SetChannelMessageReactionAddInput
    {
        /// <summary>
        /// 消息ID
        /// </summary>
        [JsonPropertyName("messageId")]
        public string MessageId { get; set; }

        /// <summary>
        /// 反应表情
        /// </summary>
        [JsonPropertyName("emoji")]
        public MessageModelEmoji ReactionEmoji { get; set; }
    }
}
