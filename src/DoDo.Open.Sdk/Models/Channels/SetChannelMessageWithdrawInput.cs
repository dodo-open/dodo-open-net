using System.Text.Json.Serialization;

namespace DoDo.Open.Sdk.Models.Channels;

public record SetChannelMessageWithdrawInput
{
    /// <summary>
    ///     消息ID
    /// </summary>
    [JsonPropertyName("messageId")]
    public string MessageId { get; set; }

    /// <summary>
    ///     撤回原因
    /// </summary>
    [JsonPropertyName("reason")]
    public string Reason { get; set; }
}
