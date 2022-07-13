using System.Text.Json.Serialization;

namespace DoDo.Open.Sdk.Models.Members;

public record GetMemberNftStatusOutput
{
    /// <summary>
    ///     是否已绑定该数藏平台，0：否，1：是
    /// </summary>
    [JsonPropertyName("isBandPlatform")]
    public int IsBandPlatform { get; set; }

    /// <summary>
    ///     是否拥有该发行方的NFT，0：否，1：是
    /// </summary>
    [JsonPropertyName("isHaveIssuer")]
    public int IsHaveIssuer { get; set; }

    /// <summary>
    ///     是否拥有该系列的NFT，0：否，1：是
    /// </summary>
    [JsonPropertyName("isHaveSeries")]
    public int IsHaveSeries { get; set; }
}
