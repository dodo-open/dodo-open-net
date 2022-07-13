using System.Text.Json.Serialization;

namespace DoDo.Open.Sdk.Models.Members;

public record GetMemberInvitationInfoOutput
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
    ///     邀请人数
    /// </summary>
    [JsonPropertyName("invitationCount")]
    public int InvitationCount { get; set; }
}