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
        /// 默认频道标识，0：是，1：否
        /// </summary>
        [JsonProperty("defaultFlag")]
        public int DefaultFlag { get; set; }
    }
}
