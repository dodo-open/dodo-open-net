using System.Text.Json.Serialization;
using DoDo.Open.Sdk.Models.Messages;

namespace DoDo.Open.Sdk.Models.Channels;

public record SetChannelMessageReactionInput
{
    /// <summary>
    ///     反应对象
    /// </summary>
    [JsonPropertyName("reactionTarget")]
    public MessageModelReactionTarget ReactionTarget { get; set; }

    /// <summary>
    ///     反应表情
    /// </summary>
    [JsonPropertyName("reactionEmoji")]
    public MessageModelEmoji ReactionEmoji { get; set; }

    /// <summary>
    ///     反应类型，0：删除，1：新增
    /// </summary>
    [JsonPropertyName("reactionType")]
    public int ReactionType { get; set; }
}