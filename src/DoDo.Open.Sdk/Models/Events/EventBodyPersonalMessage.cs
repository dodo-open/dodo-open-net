using System.Text.Json.Serialization;
using DoDo.Open.Sdk.Models.Messages;

namespace DoDo.Open.Sdk.Models.Events;

public record EventBodyPersonalMessage<T> : EventBodyBase
    where T : MessageBodyBase
{
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
    ///     消息ID
    /// </summary>
    [JsonPropertyName("messageId")]
    public string MessageId { get; set; }

    /// <summary>
    ///     消息类型，1：文本消息，2：图片消息，3：视频消息
    /// </summary>
    [JsonPropertyName("messageType")]
    public int MessageType { get; set; }

    /// <summary>
    ///     消息内容
    /// </summary>
    [JsonPropertyName("messageBody")]
    public T MessageBody { get; set; }
}
