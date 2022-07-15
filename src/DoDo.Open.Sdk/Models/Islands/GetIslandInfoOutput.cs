using System.Text.Json.Serialization;

namespace DoDo.Open.Sdk.Models.Islands
{
    public class GetIslandInfoOutput
    {
        /// <summary>
        /// 群号
        /// </summary>
        [JsonPropertyName("islandId")]
        public string IslandId { get; set; }

        /// <summary>
        /// 群名称
        /// </summary>
        [JsonPropertyName("islandName")]
        public string IslandName { get; set; }

        /// <summary>
        /// 群头像
        /// </summary>
        [JsonPropertyName("coverUrl")]
        public string CoverUrl { get; set; }

        /// <summary>
        /// 群总人数
        /// </summary>
        [JsonPropertyName("memberCount")]
        public int MemberCount { get; set; }

        /// <summary>
        /// 群在线人数
        /// </summary>
        [JsonPropertyName("onlineMemberCount")]
        public int OnlineMemberCount { get; set; }

        /// <summary>
        /// 群描述
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// 系统消息频道ID
        /// </summary>
        [JsonPropertyName("systemChannelId")]
        public string SystemChannelId { get; set; }

        /// <summary>
        /// 默认访问频道ID
        /// </summary>
        [JsonPropertyName("defaultChannelId")]
        public string DefaultChannelId { get; set; }
    }
}
