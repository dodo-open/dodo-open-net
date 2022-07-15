using System.Text.Json.Serialization;

namespace DoDo.Open.Sdk.Models.Channels
{
    public class GetChannelListOutput
    {
        /// <summary>
        /// 频道ID
        /// </summary>
        [JsonPropertyName("channelId")]
        public string ChannelId { get; set; }

        /// <summary>
        /// 频道名称
        /// </summary>
        [JsonPropertyName("channelName")]
        public string ChannelName { get; set; }

        /// <summary>
        /// 频道类型，1：文字频道，2：语音频道，4：帖子频道，5：链接频道，6：资料频道
        /// </summary>
        [JsonPropertyName("channelType")]
        public int ChannelType { get; set; }

        /// <summary>
        /// 默认频道标识，0：是，1：否
        /// </summary>
        [JsonPropertyName("defaultFlag")]
        public int DefaultFlag { get; set; }

        /// <summary>
        /// 分组ID
        /// </summary>
        [JsonPropertyName("groupId")]
        public string GroupId { get; set; }

        /// <summary>
        /// 分组名称
        /// </summary>
        [JsonPropertyName("groupName")]
        public string GroupName { get; set; }
    }
}
