using System.Text.Json.Serialization;

namespace DoDo.Open.Sdk.Models.Bots;

public record GetBotInfoOutput
{
    /// <summary>
    ///     机器人唯一标识
    /// </summary>
    [JsonPropertyName("clientId")]
    public string ClientId { get; set; }

    /// <summary>
    ///     机器人DoDo号
    /// </summary>
    [JsonPropertyName("dodoId")]
    public string DodoId { get; set; }

    /// <summary>
    ///     机器人昵称
    /// </summary>
    [JsonPropertyName("nickName")]
    public string NickName { get; set; }

    /// <summary>
    ///     机器人头像
    /// </summary>
    [JsonPropertyName("avatarUrl")]
    public string AvatarUrl { get; set; }
}
