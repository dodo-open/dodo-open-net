using Newtonsoft.Json;

namespace DoDo.Open.Sdk.Models.Channels
{
    public class GetChannelListOutput
    {
        /// <summary>
        /// 频道号
        /// </summary>
        [JsonProperty("channelId")]
        public string ChannelId { get; set; }

        /// <summary>
        /// 频道名称
        /// </summary>
        [JsonProperty("channelName")]
        public string ChannelName { get; set; }

        /// <summary>
        /// 频道类型，1：文字频道，2：语音频道，3：帖子频道，4：链接频道
        /// </summary>
        [JsonProperty("channelType")]
        public int ChannelType { get; set; }

        /// <summary>
        /// 默认频道标识，0：是，1：否
        /// </summary>
        [JsonProperty("defaultFlag")]
        public int DefaultFlag { get; set; }

        /// <summary>
        /// 分组ID
        /// </summary>
        [JsonProperty("groupId")]
        public string GroupId { get; set; }

        /// <summary>
        /// 分组名称
        /// </summary>
        [JsonProperty("groupName")]
        public string GroupName { get; set; }
    }
}
