namespace DoDo.Open.Sdk.Models.Channels
{
    public class GetChannelInfoOutput
    {
        /// <summary>
        /// 频道ID
        /// </summary>
        public string ChannelId { get; set; }

        /// <summary>
        /// 频道名称
        /// </summary>
        public string ChannelName { get; set; }

        /// <summary>
        /// 频道类型，1：文字频道，2：语音频道，4：帖子频道，5：链接频道，6：资料频道
        /// </summary>
        public int ChannelType { get; set; }

        /// <summary>
        /// 默认频道标识，0：是，1：否
        /// </summary>
        public int DefaultFlag { get; set; }

        /// <summary>
        /// 所属群ID
        /// </summary>
        public string IslandSourceId { get; set; }

        /// <summary>
        /// 分组ID
        /// </summary>
        public string GroupId { get; set; }

        /// <summary>
        /// 分组名称
        /// </summary>
        public string GroupName { get; set; }
    }
}
