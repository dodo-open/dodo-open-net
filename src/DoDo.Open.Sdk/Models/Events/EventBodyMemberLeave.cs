using DoDo.Open.Sdk.Models.Messages;
namespace DoDo.Open.Sdk.Models.Events
{
    public class EventBodyMemberLeave : EventBodyBase
    {
        /// <summary>
        /// 来源群ID
        /// </summary>
        public string IslandSourceId { get; set; }

        /// <summary>
        /// 来源DoDoID
        /// </summary>
        public string DodoSourceId { get; set; }

        /// <summary>
        /// 个人信息
        /// </summary>
        public MessageModelPersonal Personal { get; set; }

        /// <summary>
        /// 退出类型，1：主动，2：被踢
        /// </summary>
        public int LeaveType { get; set; }

        /// <summary>
        /// 操作者DoDoID（执行踢出操作的人）
        /// </summary>
        public string OperateDodoSourceId { get; set; }

        /// <summary>
        /// 变动时间
        /// </summary>
        public string ModifyTime { get; set; }
    }
}
