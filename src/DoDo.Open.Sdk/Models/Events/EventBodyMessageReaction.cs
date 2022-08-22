using DoDo.Open.Sdk.Models.Messages;
namespace DoDo.Open.Sdk.Models.Events
{
    public class EventBodyMessageReaction : EventBodyBase
    {
        /// <summary>
        /// 来源群号
        /// </summary>
        public string IslandId { get; set; }

        /// <summary>
        /// 来源频道ID
        /// </summary>
        public string ChannelId { get; set; }

        /// <summary>
        /// 来源DoDo号
        /// </summary>
        public string DodoId { get; set; }

        /// <summary>
        /// 来源消息ID
        /// </summary>
        public string MessageId { get; set; }

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
