using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DoDo.Open.Sdk.Models.Members;

public record GetMemberListOutput
{
    /// <summary>
    ///     最大ID值
    /// </summary>
    public long MaxId { get; set; }

    /// <summary>
    ///     成员列表
    /// </summary>
    public List<GetMemberListItem> List { get; set; }
}

public record GetMemberListItem
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
    ///     DoDo昵称
    /// </summary>
    [JsonPropertyName("personalNickName")]
    public string PersonalNickName { get; set; }

    /// <summary>
    ///     头像
    /// </summary>
    [JsonPropertyName("avatarUrl")]
    public string AvatarUrl { get; set; }

    /// <summary>
    ///     加群时间
    /// </summary>
    [JsonPropertyName("joinTime")]
    public string JoinTime { get; set; }

    /// <summary>
    ///     性别，-1：保密，0：女，1：男
    /// </summary>
    [JsonPropertyName("sex")]
    public int Sex { get; set; }

    /// <summary>
    ///     等级
    /// </summary>
    [JsonPropertyName("level")]
    public int Level { get; set; }

    /// <summary>
    ///     是否机器人
    /// </summary>
    [JsonPropertyName("isBot")]
    public int IsBot { get; set; }

    /// <summary>
    ///     在线设备
    /// </summary>
    [JsonPropertyName("onlineDevice")]
    public int OnlineDevice { get; set; }

    /// <summary>
    ///     在线状态
    /// </summary>
    [JsonPropertyName("onlineStatus")]
    public int OnlineStatus { get; set; }
}