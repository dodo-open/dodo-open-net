using DoDo.Open.Sdk.Models.Messages;

namespace DoDo.Open.Sdk.Models.Events
{
    public class EventBodyChannelBase : EventBodyBase
    {
        /// <summary>
        /// 来源群ID
        /// </summary>
        public string IslandSourceId { get; set; }

        /// <summary>
        /// 来源频道ID
        /// </summary>
        public string ChannelId { get; set; }

        /// <summary>
        /// 来源DoDoID
        /// </summary>
        public string DodoSourceId { get; set; }

        /// <summary>
        /// 个人信息
        /// </summary>
        public MessageModelPersonal Personal { get; set; }

        /// <summary>
        /// 成员信息
        /// </summary>
        public MessageModelMember Member { get; set; }
    }
}
