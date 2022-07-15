namespace DoDo.Open.Sdk.Models.Islands
{
    public class GetIslandListOutput
    {
        /// <summary>
        /// 群号
        /// </summary>
        public string IslandId { get; set; }

        /// <summary>
        /// 群名称
        /// </summary>
        public string IslandName { get; set; }

        /// <summary>
        /// 群头像
        /// </summary>
        public string CoverUrl { get; set; }

        /// <summary>
        /// 群总人数
        /// </summary>
        public int MemberCount { get; set; }

        /// <summary>
        /// 群在线人数
        /// </summary>
        public int OnlineMemberCount { get; set; }

        /// <summary>
        /// 系统消息频道ID
        /// </summary>
        public string SystemChannelId { get; set; }

        /// <summary>
        /// 默认访问频道ID
        /// </summary>
        public string DefaultChannelId { get; set; }
    }
}
