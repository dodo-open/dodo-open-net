using System.Text.Json.Serialization;

namespace DoDo.Open.Sdk.Models.Members;

public record GetMemberNftStatusInput
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

    /// <summary>
    ///     数藏平台，upower：高能链，ubanquan：优版权，metamask：Opensea
    /// </summary>
    [JsonPropertyName("platform")]
    public string Platform { get; set; }

    /// <summary>
    ///     发行商
    /// </summary>
    [JsonPropertyName("issuer")]
    public string Issuer { get; set; }

    /// <summary>
    ///     系列
    /// </summary>
    [JsonPropertyName("series")]
    public string Series { get; set; }
}