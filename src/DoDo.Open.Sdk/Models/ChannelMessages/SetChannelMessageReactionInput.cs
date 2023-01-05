using DoDo.Open.Sdk.Models.Messages;
namespace DoDo.Open.Sdk.Models.ChannelMessages
{
    public class SetChannelMessageReactionInput
    {
        /// <summary>
        /// 反应对象
        /// </summary>
        public MessageModelReactionTarget ReactionTarget { get; set; }

        /// <summary>
        /// 反应表情
        /// </summary>
        public MessageModelEmoji ReactionEmoji { get; set; }

        /// <summary>
        /// 反应类型，0：删除，1：新增
        /// </summary>
        public int ReactionType { get; set; }
    }
}
