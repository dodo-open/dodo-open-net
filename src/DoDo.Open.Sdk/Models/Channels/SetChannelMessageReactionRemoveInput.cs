using System.Text.Json.Serialization;
using DoDo.Open.Sdk.Models.Messages;

namespace DoDo.Open.Sdk.Models.Channels;

public record SetChannelMessageReactionRemoveInput
{
    /// <summary>
    ///     消息ID
    /// </summary>
    [JsonPropertyName("messageId")]
    public string MessageId { get; set; }

    /// <summary>
    ///     反应表情
    /// </summary>
    [JsonPropertyName("emoji")]
    public MessageModelEmoji ReactionEmoji { get; set; }

    /// <summary>
    ///     DoDo号，不传或传空时表示移除机器人自身的反应
    /// </summary>
    [JsonPropertyName("dodoId")]
    public string DoDoId { get; set; }
}
