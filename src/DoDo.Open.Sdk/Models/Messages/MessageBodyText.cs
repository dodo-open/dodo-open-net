using System.Text.Json.Serialization;

namespace DoDo.Open.Sdk.Models.Messages;

public record MessageBodyText : MessageBodyBase
{
    /// <summary>
    ///     文本内容
    /// </summary>
    [JsonPropertyName("content")]
    public string Content { get; set; }
}