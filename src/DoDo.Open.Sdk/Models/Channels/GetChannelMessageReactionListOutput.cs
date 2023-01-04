using DoDo.Open.Sdk.Models.Messages;

namespace DoDo.Open.Sdk.Models.Channels
{
    public class GetChannelMessageReactionListOutput
    {
        /// <summary>
        /// 反应表情
        /// </summary>
        public MessageModelEmoji Emoji { get; set; }

        /// <summary>
        /// 反应数量
        /// </summary>
        public long Count { get; set; }
    }
}
