using System.Text.Json.Serialization;

namespace DoDo.Open.Sdk.Models.Events;

public record EventSubjectOutput<T>
    where T : EventSubjectDataBase
{
    /// <summary>
    ///     数据类型，0：业务数据
    /// </summary>
    [JsonPropertyName("type")]
    public int Type { get; set; }

    /// <summary>
    ///     数据内容
    /// </summary>
    [JsonPropertyName("data")]
    public T Data { get; set; }
}