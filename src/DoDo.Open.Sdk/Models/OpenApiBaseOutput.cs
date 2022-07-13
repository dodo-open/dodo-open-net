using System.Text.Json.Serialization;

namespace DoDo.Open.Sdk.Models;

public record OpenApiBaseOutput<T> : OpenApiBaseOutput
{
    /// <summary>
    ///     返回数据
    /// </summary>
    [JsonPropertyName("data")]
    public T Data { get; set; }
}

public record OpenApiBaseOutput
{
    /// <summary>
    ///     返回码
    /// </summary>
    [JsonPropertyName("status")]
    public int Status { get; set; }

    /// <summary>
    ///     返回信息
    /// </summary>
    [JsonPropertyName("message")]
    public string Message { get; set; }
}
