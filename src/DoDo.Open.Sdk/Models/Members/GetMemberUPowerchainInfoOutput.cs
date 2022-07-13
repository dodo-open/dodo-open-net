using System.Text.Json.Serialization;

namespace DoDo.Open.Sdk.Models.Members;

public record GetMemberUPowerchainInfoOutput
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
    ///     是否拥有该发行方的NFT，0：否，1：是
    /// </summary>
    [JsonPropertyName("isHaveIssuer")]
    public int IsHaveIssuer { get; set; }

    /// <summary>
    ///     是否拥有该系列的NFT，0：否，1：是
    /// </summary>
    [JsonPropertyName("isHaveSeries")]
    public int IsHaveSeries { get; set; }

    /// <summary>
    ///     拥有的该系列下NFT数量
    /// </summary>
    [JsonPropertyName("nftCount")]
    public int NftCount { get; set; }
}
