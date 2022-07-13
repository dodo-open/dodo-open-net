using System.Text.Json.Serialization;
using DoDo.Open.Sdk.Models.Messages;

namespace DoDo.Open.Sdk.Models.Events;

public record EventBodyMessageReaction
{
    /// <summary>
    ///     来源群号
    /// </summary>
    [JsonPropertyName("islandId")]
    public string IslandId { get; set; }

    /// <summary>
    ///     来源频道号
    /// </summary>
    [JsonPropertyName("channelId")]
    public string ChannelId { get; set; }

    /// <summary>
    ///     来源DoDo号
    /// </summary>
    [JsonPropertyName("dodoId")]
    public string DodoId { get; set; }

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