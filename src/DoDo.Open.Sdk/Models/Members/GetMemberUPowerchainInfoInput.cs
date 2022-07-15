using System.Text.Json.Serialization;

namespace DoDo.Open.Sdk.Models.Members
{
    public class GetMemberUPowerchainInfoInput
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
        /// 发行商
        /// </summary>
        [JsonPropertyName("issuer")]
        public string Issuer { get; set; }

        /// <summary>
        /// 系列
        /// </summary>
        [JsonPropertyName("series")]
        public string Series { get; set; }
    }
}
