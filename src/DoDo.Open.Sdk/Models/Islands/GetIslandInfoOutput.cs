namespace DoDo.Open.Sdk.Models.Islands
{
    public class GetIslandInfoOutput
    {
        /// <summary>
        /// 群ID
        /// </summary>
        public string IslandSourceId { get; set; }

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
        /// 群描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 默认访问频道ID
        /// </summary>
        public string DefaultChannelId { get; set; }

        /// <summary>
        /// 系统消息频道ID
        /// </summary>
        public string SystemChannelId { get; set; }

        /// <summary>
        /// 群主DoDoID
        /// </summary>
        public string OwnerDodoSourceId { get; set; }
    }
}
