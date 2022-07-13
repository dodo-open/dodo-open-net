using System.Text.Json.Serialization;
using DoDo.Open.Sdk.Models.Messages;

namespace DoDo.Open.Sdk.Models.Events;

public record EventBodyChannelMessage<T> : EventBodyBase
    where T : MessageBodyBase
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
    ///     个人信息
    /// </summary>
    [JsonPropertyName("personal")]
    public MessageModelPersonal Personal { get; set; }

    /// <summary>
    ///     成员信息
    /// </summary>
    [JsonPropertyName("member")]
    public MessageModelMember Member { get; set; }

    /// <summary>
    ///     回复信息
    /// </summary>
    [JsonPropertyName("reference")]
    public MessageModelReference Reference { get; set; }

    /// <summary>
    ///     消息ID
    /// </summary>
    [JsonPropertyName("messageId")]
    public string MessageId { get; set; }

    /// <summary>
    ///     消息类型，1：文本消息，2：图片消息，3：视频消息，5：文件消息
    /// </summary>
    [JsonPropertyName("messageType")]
    public int MessageType { get; set; }

    /// <summary>
    ///     消息内容
    /// </summary>
    [JsonPropertyName("messageBody")]
    public T MessageBody { get; set; }
}