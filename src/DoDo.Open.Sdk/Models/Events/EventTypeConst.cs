namespace DoDo.Open.Sdk.Models.Events;

public record EventTypeConst
{
    /// <summary>
    ///     个人消息事件
    /// </summary>
    public static string PersonalMessage = "1001";

    /// <summary>
    ///     频道消息事件
    /// </summary>
    public static string ChannelMessage = "2001";

    /// <summary>
    ///     消息反应事件
    /// </summary>
    public static string MessageReaction = "3001";

    /// <summary>
    ///     成员加入事件
    /// </summary>
    public static string MemberJoin = "4001";

    /// <summary>
    ///     成员退出事件
    /// </summary>
    public static string MemberLeave = "4002";
}