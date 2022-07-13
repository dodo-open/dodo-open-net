using System.Text.Json.Serialization;

namespace DoDo.Open.Sdk.Models.Resources;

public record SetResourcePictureUploadOutput
{
    /// <summary>
    ///     图片链接
    /// </summary>
    [JsonPropertyName("url")]
    public string Url { get; set; }

    /// <summary>
    ///     图片宽度
    /// </summary>
    [JsonPropertyName("width")]
    public int? Width { get; set; }

    /// <summary>
    ///     图片高度
    /// </summary>
    [JsonPropertyName("height")]
    public int? Height { get; set; }
}
