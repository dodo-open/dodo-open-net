namespace DoDo.Open.Sdk.Models.Channels
{
    public class SetChannelAddInput
    {
        /// <summary>
        /// 群号
        /// </summary>
        public string IslandId { get; set; }

        /// <summary>
        /// 频道名称
        /// </summary>
        public string ChannelName { get; set; }

        /// <summary>
        /// 频道类型，1：文字频道，2：语音频道，4：帖子频道
        /// </summary>
        public int ChannelType { get; set; }

        /// <summary>
        /// 分组ID
        /// </summary>
        public string GroupId { get; set; }
    }
}
