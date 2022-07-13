using System.Text.Json.Serialization;

namespace DoDo.Open.Sdk.Models.Messages;

public record MessageBodyVideo : MessageBodyBase
{
    /// <summary>
    ///     视频链接
    /// </summary>
    [JsonPropertyName("url")]
    public string Url { get; set; }

    /// <summary>
    ///     封面链接
    /// </summary>
    [JsonPropertyName("coverUrl")]
    public string CoverUrl { get; set; }

    /// <summary>
    ///     视频时长
    /// </summary>
    [JsonPropertyName("duration")]
    public long? Duration { get; set; }

    /// <summary>
    ///     视频大小
    /// </summary>
    [JsonPropertyName("size")]
    public long? Size { get; set; }
}
