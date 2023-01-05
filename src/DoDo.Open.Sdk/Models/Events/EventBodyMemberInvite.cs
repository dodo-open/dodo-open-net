using DoDo.Open.Sdk.Models.Messages;
namespace DoDo.Open.Sdk.Models.Events
{
    public class EventBodyMemberInvite : EventBodyBase
    {
        /// <summary>
        /// 来源群ID
        /// </summary>
        public string IslandSourceId { get; set; }

        /// <summary>
        /// 邀请人DoDoID
        /// </summary>
        public string DodoSourceId { get; set; }

        /// <summary>
        /// 邀请人群昵称
        /// </summary>
        public string DodoIslandNickName { get; set; }

        /// <summary>
        /// 被邀请人DoDoID
        /// </summary>
        public string ToDodoSourceId { get; set; }

        /// <summary>
        /// 被邀请人群昵称
        /// </summary>
        public string ToDodoIslandNickName { get; set; }
    }
}
