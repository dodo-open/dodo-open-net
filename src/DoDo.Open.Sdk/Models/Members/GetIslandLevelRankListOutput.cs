using System.Text.Json.Serialization;

namespace DoDo.Open.Sdk.Models.Members;

public record GetIslandLevelRankListOutput
{
    /// <summary>
    ///     DoDo号
    /// </summary>
    [JsonPropertyName("dodoId")]
    public string DodoId { get; set; }

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
    ///     排名，返回前100名
    /// </summary>
    [JsonPropertyName("rank")]
    public int Rank { get; set; }
}
