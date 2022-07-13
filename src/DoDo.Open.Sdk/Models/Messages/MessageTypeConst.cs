namespace DoDo.Open.Sdk.Models.Messages;

public record MessageTypeConst
{
    /// <summary>
    ///     文字消息
    /// </summary>
    public static int Text = 1;

    /// <summary>
    ///     图片消息
    /// </summary>
    public static int Picture = 2;

    /// <summary>
    ///     视频消息
    /// </summary>
    public static int Video = 3;

    /// <summary>
    ///     文件消息
    /// </summary>
    public static int File = 5;
}
