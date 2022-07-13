using System.Text.Json.Serialization;

namespace DoDo.Open.Sdk.Models.WebSockets;

public record GetWebSocketConnectionOutput
{
    /// <summary>
    ///     连接节点
    /// </summary>
    [JsonPropertyName("endpoint")]
    public string Endpoint { get; set; }
}