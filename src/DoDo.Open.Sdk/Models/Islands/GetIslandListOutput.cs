using Newtonsoft.Json;

namespace DoDo.Open.Sdk.Models.Islands
{
    public class GetIslandListOutput
    {
        /// <summary>
        /// 群号
        /// </summary>
        [JsonProperty("islandId")]
        public string IslandId { get; set; }

        /// <summary>
        /// 群名称
        /// </summary>
        [JsonProperty("islandName")]
        public string IslandName { get; set; }

        /// <summary>
        /// 群头像
        /// </summary>
        [JsonProperty("coverUrl")]
        public string CoverUrl { get; set; }

        /// <summary>
        /// 群总人数
        /// </summary>
        [JsonProperty("memberCount")]
        public int MemberCount { get; set; }

        /// <summary>
        /// 群在线人数
        /// </summary>
        [JsonProperty("onlineMemberCount")]
        public int OnlineMemberCount { get; set; }

        /// <summary>
        /// 系统消息频道ID
        /// </summary>
        [JsonProperty("systemChannelId")]
        public string SystemChannelId { get; set; }

        /// <summary>
        /// 默认访问频道ID
        /// </summary>
        [JsonProperty("defaultChannelId")]
        public string DefaultChannelId { get; set; }
    }
}
