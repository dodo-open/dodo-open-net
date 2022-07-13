using System.Text.Json.Serialization;

namespace DoDo.Open.Sdk.Models.Members;

public record GetMemberListInput
{
    /// <summary>
    ///     群号
    /// </summary>
    [JsonPropertyName("islandId")]
    public string IslandId { get; set; }

    /// <summary>
    ///     页大小
    /// </summary>
    [JsonPropertyName("pageSize")]
    public int PageSize { get; set; }

    /// <summary>
    ///     上一页最大ID值，为提升分页查询性能，需要传入上一页查询记录中的最大ID值，首页请传0
    /// </summary>
    [JsonPropertyName("maxId")]
    public int MaxId { get; set; }
}