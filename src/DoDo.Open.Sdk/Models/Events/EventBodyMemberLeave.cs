using System.Text.Json.Serialization;
using DoDo.Open.Sdk.Models.Messages;

namespace DoDo.Open.Sdk.Models.Events;

public record EventBodyMemberLeave
{
    /// <summary>
    ///     来源群号
    /// </summary>
    [JsonPropertyName("islandId")]
    public string IslandId { get; set; }

    /// <summary>
    ///     来源DoDo号
    /// </summary>
    [JsonPropertyName("dodoId")]
    public string DodoId { get; set; }

    /// <summary>
    ///     个人信息
    /// </summary>
    [JsonPropertyName("personal")]
    public MessageModelPersonal Personal { get; set; }

    /// <summary>
    ///     退出类型，1：主动，2：被踢
    /// </summary>
    [JsonPropertyName("leaveType")]
    public int LeaveType { get; set; }

    /// <summary>
    ///     操作者DoDo号（执行踢出操作的人）
    /// </summary>
    [JsonPropertyName("operateDoDoId")]
    public string OperateDoDoId { get; set; }

    /// <summary>
    ///     变动时间
    /// </summary>
    [JsonPropertyName("modifyTime")]
    public string ModifyTime { get; set; }
}