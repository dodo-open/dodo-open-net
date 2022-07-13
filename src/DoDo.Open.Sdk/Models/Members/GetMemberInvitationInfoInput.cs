using System.Text.Json.Serialization;

namespace DoDo.Open.Sdk.Models.Members;

public record GetMemberInvitationInfoInput
{
    /// <summary>
    ///     群号
    /// </summary>
    [JsonPropertyName("islandId")]
    public string IslandId { get; set; }

    /// <summary>
    ///     DoDo号
    /// </summary>
    [JsonPropertyName("dodoId")]
    public string DoDoId { get; set; }
}