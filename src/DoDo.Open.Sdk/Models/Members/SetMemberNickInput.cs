using System.Text.Json.Serialization;

namespace DoDo.Open.Sdk.Models.Members
{
    public class SetMemberNickInput
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
        /// 群昵称
        /// </summary>
        [JsonPropertyName("nickName")]
        public string NickName { get; set; }
    }
}
