using System.Text.Json.Serialization;

namespace DoDo.Open.Sdk.Models.Roles;

public record GetRoleListOutput
{
    /// <summary>
    ///     身份组ID
    /// </summary>
    [JsonPropertyName("roleId")]
    public string RoleId { get; set; }

    /// <summary>
    ///     身份组名称
    /// </summary>
    [JsonPropertyName("roleName")]
    public string RoleName { get; set; }

    /// <summary>
    ///     身份组颜色
    /// </summary>
    [JsonPropertyName("roleColor")]
    public string RoleColor { get; set; }

    /// <summary>
    ///     位置
    /// </summary>
    [JsonPropertyName("position")]
    public int Position { get; set; }

    /// <summary>
    ///     权限值
    /// </summary>
    [JsonPropertyName("permission")]
    public string Permission { get; set; }
}