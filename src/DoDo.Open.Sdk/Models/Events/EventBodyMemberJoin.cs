using System.Text.Json.Serialization;

namespace DoDo.Open.Sdk.Models.Events
{
    public class EventBodyMemberJoin
    {
        /// <summary>
        /// 来源群号
        /// </summary>
        [JsonPropertyName("islandId")]
        public string IslandId { get; set; }

        /// <summary>
        /// 来源DoDo号
        /// </summary>
        [JsonPropertyName("dodoId")]
        public string DodoId { get; set; }

        /// <summary>
        /// 变动时间
        /// </summary>
        [JsonPropertyName("modifyTime")]
        public string ModifyTime { get; set; }
    }
}
