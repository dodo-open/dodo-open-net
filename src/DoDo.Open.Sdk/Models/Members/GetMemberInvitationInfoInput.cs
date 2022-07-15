using System.Text.Json.Serialization;

namespace DoDo.Open.Sdk.Models.Members
{
    public  class GetMemberInvitationInfoInput
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
    }
}
