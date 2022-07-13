using System.Text.Json.Serialization;

namespace DoDo.Open.Sdk.Models.Islands;

public record GetIslandInfoInput
{
    /// <summary>
    ///     群号
    /// </summary>
    [JsonPropertyName("islandId")]
    public string IslandId { get; set; }
}
