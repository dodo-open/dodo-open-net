using System.Text.Json;
using DoDo.Open.Sdk.Models.Events;
using DoDo.Open.Sdk.Models.Messages;

namespace DoDo.Open.Sdk.Services;

/// <summary>
///     事件处理服务
/// </summary>
public abstract class EventProcessService
{
    /// <summary>
    ///     连接成功
    /// </summary>
    /// <param name="message"></param>
    public abstract void Connected(string message);

    /// <summary>
    ///     连接断开
    /// </summary>
    /// <param name="message"></param>
    public abstract void Disconnected(string message);

    /// <summary>
    ///     断线重连
    /// </summary>
    /// <param name="message"></param>
    public abstract void Reconnected(string message);

    /// <summary>
    ///     异常反馈
    /// </summary>
    /// <param name="message"></param>
    public abstract void Exception(string message);

    /// <summary>
    ///     消息接收 - 内部
    /// </summary>
    /// <param name="message"></param>
    internal virtual void ReceivedInternal(string message)
    {
        Received(message);

        var eventSubjectResult = JsonSerializer.Deserialize<EventSubjectOutput<EventSubjectDataBase>>(message);
        if (eventSubjectResult == null) return;

        if (eventSubjectResult.Type != EventSubjectDataTypeConst.Business)
        {
            return;
        }

        var eventSubjectDataResult = JsonSerializer.Deserialize<EventSubjectOutput<EventSubjectDataBusiness<EventBodyBase>>>(message);
        if (eventSubjectDataResult == null) return;

        if (eventSubjectDataResult.Data.EventType == EventTypeConst.PersonalMessage)
        {
            var eventBodyResult = JsonSerializer.Deserialize<
                    EventSubjectOutput<EventSubjectDataBusiness<EventBodyPersonalMessage<MessageBodyBase>>>>(
                    message);
            if (eventBodyResult == null) return;

            var eventBody = eventBodyResult.Data.EventBody;

            if (eventBody.MessageType == MessageTypeConst.Text)
            {
                var messageResult =
                    JsonSerializer.Deserialize<
                        EventSubjectOutput<
                            EventSubjectDataBusiness<EventBodyPersonalMessage<MessageBodyText>>>>(message);
                if (messageResult == null) return;
                PersonalMessageEvent(messageResult);
            }
            else if (eventBody.MessageType == MessageTypeConst.Picture)
            {
                var messageResult =
                    JsonSerializer.Deserialize<
                        EventSubjectOutput<EventSubjectDataBusiness<
                            EventBodyPersonalMessage<MessageBodyPicture>>>>(message);
                if (messageResult == null) return;
                PersonalMessageEvent(messageResult);
            }
            else if (eventBody.MessageType == MessageTypeConst.Video)
            {
                var messageResult =
                    JsonSerializer.Deserialize<
                        EventSubjectOutput<
                            EventSubjectDataBusiness<EventBodyPersonalMessage<MessageBodyVideo>>>>(message);
                if (messageResult == null) return;
                PersonalMessageEvent(messageResult);
            }
        }
        else if (eventSubjectDataResult.Data.EventType == EventTypeConst.ChannelMessage)
        {
            var eventBodyResult =
                JsonSerializer.Deserialize<
                    EventSubjectOutput<EventSubjectDataBusiness<EventBodyChannelMessage<MessageBodyBase>>>>(
                    message);
            if (eventBodyResult == null) return;

            var eventBody = eventBodyResult.Data.EventBody;

            if (eventBody.MessageType == MessageTypeConst.Text)
            {
                var messageResult =
                    JsonSerializer.Deserialize<
                        EventSubjectOutput<EventSubjectDataBusiness<EventBodyChannelMessage<MessageBodyText>>>>(
                        message);
                if (messageResult == null) return;
                ChannelMessageEvent(messageResult);
            }
            else if (eventBody.MessageType == MessageTypeConst.Picture)
            {
                var messageResult =
                    JsonSerializer.Deserialize<
                        EventSubjectOutput<
                            EventSubjectDataBusiness<EventBodyChannelMessage<MessageBodyPicture>>>>(message);
                if (messageResult == null) return;
                ChannelMessageEvent(messageResult);
            }
            else if (eventBody.MessageType == MessageTypeConst.Video)
            {
                var messageResult =
                    JsonSerializer.Deserialize<
                        EventSubjectOutput<
                            EventSubjectDataBusiness<EventBodyChannelMessage<MessageBodyVideo>>>>(message);
                if (messageResult == null) return;
                ChannelMessageEvent(messageResult);
            }
            else if (eventBody.MessageType == MessageTypeConst.File)
            {
                var messageResult =
                    JsonSerializer.Deserialize<
                        EventSubjectOutput<EventSubjectDataBusiness<EventBodyChannelMessage<MessageBodyFile>>>>(
                        message);
                if (messageResult == null) return;
                ChannelMessageEvent(messageResult);
            }
        }
        else if (eventSubjectDataResult.Data.EventType == EventTypeConst.MessageReaction)
        {
            var eventBodyResult =
                JsonSerializer.Deserialize<EventSubjectOutput<EventSubjectDataBusiness<EventBodyMessageReaction>>>(
                    message);
            if (eventBodyResult == null) return;
            MessageReactionEvent(eventBodyResult);
        }
        else if (eventSubjectDataResult.Data.EventType == EventTypeConst.MemberJoin)
        {
            var eventBodyResult =
                JsonSerializer.Deserialize<EventSubjectOutput<EventSubjectDataBusiness<EventBodyMemberJoin>>>(
                    message);
            if (eventBodyResult == null) return;
            MemberJoinEvent(eventBodyResult);
        }
        else if (eventSubjectDataResult.Data.EventType == EventTypeConst.MemberLeave)
        {
            var eventBodyResult =
                JsonSerializer.Deserialize<EventSubjectOutput<EventSubjectDataBusiness<EventBodyMemberLeave>>>(
                    message);
            if (eventBodyResult == null) return;
            MemberLeaveEvent(eventBodyResult);
        }
    }

    /// <summary>
    ///     消息接收
    /// </summary>
    /// <param name="message"></param>
    public virtual void Received(string message)
    {
    }

    /// <summary>
    ///     个人消息事件
    /// </summary>
    /// <param name="input"></param>
    public virtual void PersonalMessageEvent<T>(
        EventSubjectOutput<EventSubjectDataBusiness<EventBodyPersonalMessage<T>>> input)
        where T : MessageBodyBase
    {
    }

    /// <summary>
    ///     频道消息事件
    /// </summary>
    /// <param name="input"></param>
    public virtual void ChannelMessageEvent<T>(
        EventSubjectOutput<EventSubjectDataBusiness<EventBodyChannelMessage<T>>> input)
        where T : MessageBodyBase
    {
    }

    /// <summary>
    ///     消息反应事件
    /// </summary>
    /// <param name="input"></param>
    public virtual void MessageReactionEvent(
        EventSubjectOutput<EventSubjectDataBusiness<EventBodyMessageReaction>> input)
    {
    }

    /// <summary>
    ///     成员加入事件
    /// </summary>
    /// <param name="input"></param>
    public virtual void MemberJoinEvent(EventSubjectOutput<EventSubjectDataBusiness<EventBodyMemberJoin>> input)
    {
    }

    /// <summary>
    ///     成员退出事件
    /// </summary>
    /// <param name="input"></param>
    public virtual void MemberLeaveEvent(EventSubjectOutput<EventSubjectDataBusiness<EventBodyMemberLeave>> input)
    {
    }
}
