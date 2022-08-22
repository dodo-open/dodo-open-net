using DoDo.Open.Sdk.Models.Messages;
namespace DoDo.Open.Sdk.Models.Events
{
    public class EventBodyMemberLeave : EventBodyBase
    {
        /// <summary>
        /// 来源群号
        /// </summary>
        public string IslandId { get; set; }

        /// <summary>
        /// 来源DoDo号
        /// </summary>
        public string DodoId { get; set; }

        /// <summary>
        /// 个人信息
        /// </summary>
        public MessageModelPersonal Personal { get; set; }

        /// <summary>
        /// 退出类型，1：主动，2：被踢
        /// </summary>
        public int LeaveType { get; set; }

        /// <summary>
        /// 操作者DoDo号（执行踢出操作的人）
        /// </summary>
        public string OperateDoDoId { get; set; }

        /// <summary>
        /// 变动时间
        /// </summary>
        public string ModifyTime { get; set; }
    }
}
