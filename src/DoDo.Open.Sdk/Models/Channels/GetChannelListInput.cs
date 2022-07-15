using System.Text.Json.Serialization;

namespace DoDo.Open.Sdk.Models.Channels
{
    public class GetChannelListInput
    {
        /// <summary>
        /// 群号
        /// </summary>
        [JsonPropertyName("islandId")]
        public string IslandId { get; set; }
    }
}
