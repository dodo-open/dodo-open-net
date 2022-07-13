using System.Text.Json.Serialization;

namespace DoDo.Open.Sdk.Models.Messages;

public record MessageModelReactionTarget
{
    /// <summary>
    ///     对象类型，0：消息
    /// </summary>
    [JsonPropertyName("type")]
    public int Type { get; set; }

    /// <summary>
    ///     对象ID，若对象类型为0，则代表消息ID
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; }
}
