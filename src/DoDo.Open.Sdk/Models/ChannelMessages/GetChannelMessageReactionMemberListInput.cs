using DoDo.Open.Sdk.Models.Messages;

namespace DoDo.Open.Sdk.Models.ChannelMessages
{
    public class GetChannelMessageReactionMemberListInput : OpenApiPageInput
    {
        /// <summary>
        /// 消息ID
        /// </summary>
        public string MessageId { get; set; }

        /// <summary>
        /// 反应表情
        /// </summary>
        public MessageModelEmoji Emoji { get; set; }
    }
}
