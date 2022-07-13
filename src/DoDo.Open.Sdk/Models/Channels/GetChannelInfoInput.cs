using System.Text.Json.Serialization;

namespace DoDo.Open.Sdk.Models.Channels;

public record GetChannelInfoInput
{
    /// <summary>
    ///     频道号
    /// </summary>
    [JsonPropertyName("channelId")]
    public string ChannelId { get; set; }
}
