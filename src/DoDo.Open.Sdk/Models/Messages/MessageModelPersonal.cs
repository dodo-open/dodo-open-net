using System.Text.Json.Serialization;

namespace DoDo.Open.Sdk.Models.Messages;

public record MessageModelPersonal
{
    /// <summary>
    ///     DoDo昵称
    /// </summary>
    [JsonPropertyName("nickName")]
    public string NickName { get; set; }

    /// <summary>
    ///     个人头像
    /// </summary>
    [JsonPropertyName("avatarUrl")]
    public string AvatarUrl { get; set; }

    /// <summary>
    ///     个人性别，-1：保密，0：女，1：男
    /// </summary>
    [JsonPropertyName("sex")]
    public int Sex { get; set; }
}