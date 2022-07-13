using System.Text.Json.Serialization;

namespace DoDo.Open.Sdk.Models.Messages;

public record MessageModelEmoji
{
    /// <summary>
    ///     表情类型，1：Emoji
    /// </summary>
    [JsonPropertyName("type")]
    public int Type { get; set; }

    /// <summary>
    ///     表情ID
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; }
}
