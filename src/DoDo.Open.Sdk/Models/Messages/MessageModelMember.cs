using System.Text.Json.Serialization;

namespace DoDo.Open.Sdk.Models.Messages;

public record MessageModelMember
{
    /// <summary>
    ///     群昵称
    /// </summary>
    [JsonPropertyName("nickName")]
    public string NickName { get; set; }

    /// <summary>
    ///     等级
    /// </summary>
    [JsonPropertyName("level")]
    public int Level { get; set; }

    /// <summary>
    ///     在群时间
    /// </summary>
    [JsonPropertyName("joinTime")]
    public string JoinTime { get; set; }
}
