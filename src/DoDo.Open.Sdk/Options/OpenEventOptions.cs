﻿namespace DoDo.Open.Sdk.Options;

public record OpenEventOptions
{
    /// <summary>
    ///     是否断线重连
    /// </summary>
    public bool IsReconnect { get; set; }

    /// <summary>
    ///     是否异步处理
    /// </summary>
    public bool IsAsync { get; set; }
}
