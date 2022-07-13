using System.Text.Json.Serialization;

namespace DoDo.Open.Sdk.Models.Events;

public record EventSubjectDataBusiness<T> : EventSubjectDataBase
{
    /// <summary>
    ///     事件ID
    /// </summary>
    [JsonPropertyName("eventId")]
    public string EventId { get; set; }

    /// <summary>
    ///     事件类型，1001：个人消息事件，2001：频道消息事件
    /// </summary>
    [JsonPropertyName("eventType")]
    public string EventType { get; set; }

    /// <summary>
    ///     事件内容，事件类型不同，内容也会不同
    /// </summary>
    [JsonPropertyName("eventBody")]
    public T EventBody { get; set; }

    /// <summary>
    ///     发送时间戳
    /// </summary>
    [JsonPropertyName("timestamp")]
    public long Timestamp { get; set; }
}
