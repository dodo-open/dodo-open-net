using DoDo.Open.Sdk.Models.Events;
using DoDo.Open.Sdk.Models.Messages;
using DoDo.Open.Sdk.Services;
using Microsoft.Extensions.Logging;

namespace DoDo.Open.Client;

public class EventProcessor : IEventProcessService
{
    private readonly ILogger<EventProcessor> _logger;

    public EventProcessor(ILogger<EventProcessor> logger)
    {
        _logger = logger;
    }

    public void OnConnected(string message)
    {
        _logger.LogInformation("OnConnected: {Message}", message);
    }

    public void OnDisconnected(string message)
    {
        _logger.LogInformation("OnDisconnected: {Message}", message);
    }

    public void OnReconnected(string message)
    {
        _logger.LogInformation("OnReconnected: {Message}", message);
    }

    public void OnException(string message)
    {
        _logger.LogError("OnException: {Message}", message);
    }

    public void Received(string message)
    {
        _logger.LogInformation("OnMessage: {Message}", message);
    }

    public void PersonalMessageEvent<T>(EventSubjectOutput<EventSubjectDataBusiness<EventBodyPersonalMessage<T>>> input) where T : MessageBodyBase
    {
        _logger.LogInformation("PersonalMessageEvent: {Message}", input);
    }

    public void ChannelMessageEvent<T>(EventSubjectOutput<EventSubjectDataBusiness<EventBodyChannelMessage<T>>> input) where T : MessageBodyBase
    {
        _logger.LogInformation("ChannelMessageEvent: {Message}", input);
    }

    public void MessageReactionEvent(EventSubjectOutput<EventSubjectDataBusiness<EventBodyMessageReaction>> input)
    {
        _logger.LogInformation("MessageReactionEvent: {Message}", input);
    }

    public void MemberJoinEvent(EventSubjectOutput<EventSubjectDataBusiness<EventBodyMemberJoin>> input)
    {
        _logger.LogInformation("MemberJoinEvent: {Message}", input);
    }

    public void MemberLeaveEvent(EventSubjectOutput<EventSubjectDataBusiness<EventBodyMemberLeave>> input)
    {
        _logger.LogInformation("MemberLeaveEvent: {Message}", input);
    }
}
