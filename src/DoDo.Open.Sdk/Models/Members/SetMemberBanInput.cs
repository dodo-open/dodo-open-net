using System.Text.Json.Serialization;

namespace DoDo.Open.Sdk.Models.Members;

public record SetMemberBanInput
{
    /// <summary>
    ///     群号
    /// </summary>
    [JsonPropertyName("islandId")]
    public string IslandId { get; set; }

    /// <summary>
    ///     DoDo号
    /// </summary>
    [JsonPropertyName("dodoId")]
    public string DoDoId { get; set; }

    /// <summary>
    ///     禁言时长（秒），最长7天
    /// </summary>
    [JsonPropertyName("duration")]
    public int Duration { get; set; }

    /// <summary>
    ///     禁言原因
    /// </summary>
    [JsonPropertyName("reason")]
    public string Reason { get; set; }
}
