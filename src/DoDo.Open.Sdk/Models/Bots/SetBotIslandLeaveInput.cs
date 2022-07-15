using System.Text.Json.Serialization;

namespace DoDo.Open.Sdk.Models.Bots
{
    public class SetBotIslandLeaveInput
    {
        /// <summary>
        /// 群号
        /// </summary>
        [JsonPropertyName("islandId")]
        public string IslandId { get; set; }
    }
}
