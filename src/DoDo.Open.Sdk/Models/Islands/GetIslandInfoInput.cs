using System.Text.Json.Serialization;

namespace DoDo.Open.Sdk.Models.Islands
{
    public class GetIslandInfoInput
    {
        /// <summary>
        /// 群号
        /// </summary>
        [JsonPropertyName("islandId")]
        public string IslandId { get; set; }
    }
}
