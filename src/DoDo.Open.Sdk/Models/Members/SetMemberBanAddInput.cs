using System.Text.Json.Serialization;

namespace DoDo.Open.Sdk.Models.Members
{
    public class SetMemberBanAddInput
    {
        /// <summary>
        /// 群号
        /// </summary>
        [JsonPropertyName("islandId")]
        public string IslandId { get; set; }

        /// <summary>
        /// DoDo号
        /// </summary>
        [JsonPropertyName("dodoId")]
        public string DodoId { get; set; }

        /// <summary>
        /// 通知频道ID
        /// </summary>
        [JsonPropertyName("noticeChannelId")]
        public string NoticeChannelId { get; set; }

        /// <summary>
        /// 封禁理由
        /// </summary>
        [JsonPropertyName("reason")]
        public string Reason { get; set; }
    }
}
