namespace DoDo.Open.Sdk.Models.Members
{
    public class GetMemberInfoOutput
    {
        /// <summary>
        /// 群号
        /// </summary>
        public string IslandId { get; set; }

        /// <summary>
        /// DoDo号
        /// </summary>
        public string DodoId { get; set; }

        /// <summary>
        /// 群昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// DoDo昵称
        /// </summary>
        public string PersonalNickName { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        public string AvatarUrl { get; set; }

        /// <summary>
        /// 加群时间
        /// </summary>
        public string JoinTime { get; set; }

        /// <summary>
        /// 性别，-1：保密，0：女，1：男
        /// </summary>
        public int Sex { get; set; }

        /// <summary>
        /// 等级
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// 是否机器人
        /// </summary>
        public int IsBot { get; set; }

        /// <summary>
        /// 在线设备
        /// </summary>
        public int OnlineDevice { get; set; }

        /// <summary>
        /// 在线状态
        /// </summary>
        public int OnlineStatus { get; set; }
    }
}
