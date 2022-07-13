using System.Text.Json.Serialization;

namespace DoDo.Open.Sdk.Models.Personals;

public record SetPersonalMessageSendOutput
{
    /// <summary>
    ///     消息ID
    /// </summary>
    [JsonPropertyName("messageId")]
    public string MessageId { get; set; }
}