namespace DoDo.Open.Sdk.Options;

public record OpenApiOptions
{
    /// <summary>
    ///     接口地址
    /// </summary>
    public string BaseApi { get; set; }

    /// <summary>
    ///     机器人唯一标识
    /// </summary>
    public string ClientId { get; set; }

    /// <summary>
    ///     机器人鉴权Token
    /// </summary>
    public string Token { get; set; }
}
