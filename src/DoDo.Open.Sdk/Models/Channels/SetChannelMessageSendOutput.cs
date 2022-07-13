using System.Text.Json.Serialization;

namespace DoDo.Open.Sdk.Models.Channels;

public record SetChannelMessageSendOutput
{
    /// <summary>
    ///     消息ID
    /// </summary>
    [JsonPropertyName("messageId")]
    public string MessageId { get; set; }
}