using DoDo.Open.Sdk.Models.Events;
using DoDo.Open.Sdk.Models.Messages;

namespace DoDo.Open.Sdk.Services;

/// <summary>
///     事件处理服务
/// </summary>
public interface IEventProcessService
{
    /// <summary>
    ///     连接成功
    /// </summary>
    /// <param name="message"></param>
    void OnConnected(string message);

    /// <summary>
    ///     连接断开
    /// </summary>
    /// <param name="message"></param>
    void OnDisconnected(string message);

    /// <summary>
    ///     断线重连
    /// </summary>
    /// <param name="message"></param>
    void OnReconnected(string message);

    /// <summary>
    ///     异常反馈
    /// </summary>
    /// <param name="message"></param>
    void OnException(string message);

    /// <summary>
    ///     消息接收
    /// </summary>
    /// <param name="message"></param>
    void Received(string message);

    /// <summary>
    ///     个人消息事件
    /// </summary>
    /// <param name="input"></param>
    void PersonalMessageEvent<T>(EventSubjectOutput<EventSubjectDataBusiness<EventBodyPersonalMessage<T>>> input)
        where T : MessageBodyBase;

    /// <summary>
    ///     频道消息事件
    /// </summary>
    /// <param name="input"></param>
    void ChannelMessageEvent<T>(EventSubjectOutput<EventSubjectDataBusiness<EventBodyChannelMessage<T>>> input)
        where T : MessageBodyBase;

    /// <summary>
    ///     消息反应事件
    /// </summary>
    /// <param name="input"></param>
    void MessageReactionEvent(EventSubjectOutput<EventSubjectDataBusiness<EventBodyMessageReaction>> input);

    /// <summary>
    ///     成员加入事件
    /// </summary>
    /// <param name="input"></param>
    void MemberJoinEvent(EventSubjectOutput<EventSubjectDataBusiness<EventBodyMemberJoin>> input);

    /// <summary>
    ///     成员退出事件
    /// </summary>
    /// <param name="input"></param>
    void MemberLeaveEvent(EventSubjectOutput<EventSubjectDataBusiness<EventBodyMemberLeave>> input);
}
