using System;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using DoDo.Open.Sdk.Models.Events;
using DoDo.Open.Sdk.Models.Messages;
using DoDo.Open.Sdk.Models.WebSockets;
using DoDo.Open.Sdk.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DoDo.Open.Sdk.Services;

/// <inheritdoc />
public class OpenEventService : IOpenEventService
{
    private readonly IEventProcessService _eventProcessService;
    private readonly ILogger<OpenEventService> _logger;
    private readonly IOpenApiService _openApiService;
    private readonly IOptions<OpenEventOptions> _openEventOptions;
    private ClientWebSocket _clientWebSocket;

    /// <summary>
    ///     开放事件服务构造函数
    /// </summary>
    /// <param name="openApiService"></param>
    /// <param name="eventProcessService"></param>
    /// <param name="openEventOptions"></param>
    /// <param name="logger"></param>
    public OpenEventService(
        IOpenApiService openApiService,
        IEventProcessService eventProcessService,
        IOptions<OpenEventOptions> openEventOptions,
        ILogger<OpenEventService> logger = null)
    {
        _openApiService = openApiService;
        _eventProcessService = eventProcessService;
        _openEventOptions = openEventOptions;
        _logger = logger;
    }

    /// <inheritdoc />
    public async Task ReceiveAsync()
    {
        try
        {
            GetWebSocketConnectionOutput getWebSocketConnectionOutput = null;

            for (var i = 0; i < 3; i++)
            {
                getWebSocketConnectionOutput = await
                    _openApiService.GetWebSocketConnection(new GetWebSocketConnectionInput());

                if (getWebSocketConnectionOutput == null)
                {
                    await Task.Delay(3000 * i);
                    continue;
                }

                break;
            }

            if (getWebSocketConnectionOutput == null)
            {
                try
                {
                    _eventProcessService.OnDisconnected("获取WebSocket连接失败");
                }
                catch (Exception ex)
                {
                    try
                    {
                        _eventProcessService.OnException(ex.Message);
                    }
                    catch (Exception)
                    {
                        // ignored
                    }
                }

                return;
            }

            _logger.LogInformation("WebSocket 开始连接：{WsEndpoint}", getWebSocketConnectionOutput.Endpoint);


            for (var i = 0; i < 3; i++)
            {
                try
                {
                    _clientWebSocket = new ClientWebSocket();
                    await _clientWebSocket.ConnectAsync(new Uri(getWebSocketConnectionOutput.Endpoint),
                        CancellationToken.None);
                    try
                    {
                        _eventProcessService.OnConnected("连接成功");
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            _eventProcessService.OnException(ex.Message);
                        }
                        catch (Exception)
                        {
                            // ignored
                        }
                    }
                }
                catch (Exception)
                {
                    await Task.Delay(3000 * i);
                    continue;
                }

                break;
            }

            if (_clientWebSocket.State != WebSocketState.Open)
            {
                try
                {
                    _eventProcessService.OnDisconnected("WebSocket连接失败");
                }
                catch (Exception ex)
                {
                    try
                    {
                        _eventProcessService.OnException(ex.Message);
                    }
                    catch (Exception)
                    {
                        // ignored
                    }
                }

                return;
            }

            while (_clientWebSocket.CloseStatus != WebSocketCloseStatus.NormalClosure)
            {
                try
                {
                    var buffer = new ArraySegment<byte>(new byte[20480]);
                    var receive = await _clientWebSocket.ReceiveAsync(buffer, CancellationToken.None);

                    if (buffer.Array != null)
                    {
                        try
                        {
                            var json = Encoding.UTF8.GetString(buffer.Array, 0, receive.Count);
                            if (string.IsNullOrWhiteSpace(json))
                            {
                                continue;
                            }

                            if (_openEventOptions.Value.IsAsync)
                            {
                                await Task.Factory.StartNew(() =>
                                {
                                    try
                                    {
                                        MessageReceived(json);
                                    }
                                    catch (Exception ex)
                                    {
                                        try
                                        {
                                            _eventProcessService.OnException(ex.Message);
                                        }
                                        catch (Exception)
                                        {
                                            // ignored
                                        }
                                    }
                                });
                            }
                            else
                            {
                                MessageReceived(json);
                            }
                        }
                        catch (Exception ex)
                        {
                            try
                            {
                                _eventProcessService.OnException(ex.Message);
                            }
                            catch (Exception)
                            {
                                // ignored
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    try
                    {
                        _eventProcessService.OnDisconnected(e.Message);
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            _eventProcessService.OnException(ex.Message);
                        }
                        catch (Exception)
                        {
                            // ignored
                        }
                    }

                    if (_openEventOptions.Value.IsReconnect)
                    {
                        var reconnectCount = 0;

                        while (_clientWebSocket.CloseStatus != WebSocketCloseStatus.NormalClosure)
                        {
                            try
                            {
                                if (_clientWebSocket.State != WebSocketState.Open)
                                {
                                    _clientWebSocket = new ClientWebSocket();
                                    await _clientWebSocket.ConnectAsync(new Uri(getWebSocketConnectionOutput.Endpoint),
                                        CancellationToken.None);
                                    try
                                    {
                                        _eventProcessService.OnConnected("连接成功");
                                    }
                                    catch (Exception ex)
                                    {
                                        try
                                        {
                                            _eventProcessService.OnException(ex.Message);
                                        }
                                        catch (Exception)
                                        {
                                            // ignored
                                        }
                                    }
                                }

                                break;
                            }
                            catch (Exception)
                            {
                                try
                                {
                                    _eventProcessService.OnReconnected("断线重连中");
                                }
                                catch (Exception ex)
                                {
                                    try
                                    {
                                        _eventProcessService.OnException(ex.Message);
                                    }
                                    catch (Exception)
                                    {
                                        // ignored
                                    }
                                }

                                if (reconnectCount < 300)
                                {
                                    reconnectCount += 5;
                                }

                                await Task.Delay(1000 * reconnectCount);
                            }
                        }
                    }
                    else
                    {
                        return;
                    }
                }
            }

            if (_clientWebSocket.CloseStatus == WebSocketCloseStatus.NormalClosure)
            {
                try
                {
                    _eventProcessService.OnDisconnected("停止接收");
                }
                catch (Exception ex)
                {
                    try
                    {
                        _eventProcessService.OnException(ex.Message);
                    }
                    catch (Exception)
                    {
                        // ignored
                    }
                }
            }
        }
        catch (Exception ex)
        {
            try
            {
                _eventProcessService.OnException(ex.Message);
            }
            catch (Exception)
            {
                // ignored
            }
        }
    }

    /// <inheritdoc />
    public async Task StopReceiveAsync()
    {
        if (_clientWebSocket != null && _clientWebSocket.State != WebSocketState.Closed)
        {
            await _clientWebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "", CancellationToken.None);
        }
    }

    private void MessageReceived(string message)
    {
        _eventProcessService.Received(message);

        var eventSubjectResult = JsonSerializer.Deserialize<EventSubjectOutput<EventSubjectDataBase>>(message);
        if (eventSubjectResult == null)
        {
            return;
        }

        if (eventSubjectResult.Type != EventSubjectDataTypeConst.Business)
        {
            return;
        }

        var eventSubjectDataResult =
            JsonSerializer.Deserialize<EventSubjectOutput<EventSubjectDataBusiness<EventBodyBase>>>(message);
        if (eventSubjectDataResult == null)
        {
            return;
        }

        if (eventSubjectDataResult.Data.EventType == EventTypeConst.PersonalMessage)
        {
            var eventBodyResult = JsonSerializer.Deserialize<
                EventSubjectOutput<EventSubjectDataBusiness<EventBodyPersonalMessage<MessageBodyBase>>>>(
                message);
            if (eventBodyResult == null)
            {
                return;
            }

            var eventBody = eventBodyResult.Data.EventBody;

            if (eventBody.MessageType == MessageTypeConst.Text)
            {
                var messageResult =
                    JsonSerializer.Deserialize<
                        EventSubjectOutput<
                            EventSubjectDataBusiness<EventBodyPersonalMessage<MessageBodyText>>>>(message);
                if (messageResult == null)
                {
                    return;
                }

                _eventProcessService.PersonalMessageEvent(messageResult);
            }
            else if (eventBody.MessageType == MessageTypeConst.Picture)
            {
                var messageResult =
                    JsonSerializer.Deserialize<
                        EventSubjectOutput<EventSubjectDataBusiness<
                            EventBodyPersonalMessage<MessageBodyPicture>>>>(message);
                if (messageResult == null)
                {
                    return;
                }

                _eventProcessService.PersonalMessageEvent(messageResult);
            }
            else if (eventBody.MessageType == MessageTypeConst.Video)
            {
                var messageResult =
                    JsonSerializer.Deserialize<
                        EventSubjectOutput<
                            EventSubjectDataBusiness<EventBodyPersonalMessage<MessageBodyVideo>>>>(message);
                if (messageResult == null)
                {
                    return;
                }

                _eventProcessService.PersonalMessageEvent(messageResult);
            }
        }
        else if (eventSubjectDataResult.Data.EventType == EventTypeConst.ChannelMessage)
        {
            var eventBodyResult =
                JsonSerializer.Deserialize<
                    EventSubjectOutput<EventSubjectDataBusiness<EventBodyChannelMessage<MessageBodyBase>>>>(
                    message);
            if (eventBodyResult == null)
            {
                return;
            }

            var eventBody = eventBodyResult.Data.EventBody;

            if (eventBody.MessageType == MessageTypeConst.Text)
            {
                var messageResult =
                    JsonSerializer.Deserialize<
                        EventSubjectOutput<EventSubjectDataBusiness<EventBodyChannelMessage<MessageBodyText>>>>(
                        message);
                if (messageResult == null)
                {
                    return;
                }

                _eventProcessService.ChannelMessageEvent(messageResult);
            }
            else if (eventBody.MessageType == MessageTypeConst.Picture)
            {
                var messageResult =
                    JsonSerializer.Deserialize<
                        EventSubjectOutput<
                            EventSubjectDataBusiness<EventBodyChannelMessage<MessageBodyPicture>>>>(message);
                if (messageResult == null)
                {
                    return;
                }

                _eventProcessService.ChannelMessageEvent(messageResult);
            }
            else if (eventBody.MessageType == MessageTypeConst.Video)
            {
                var messageResult =
                    JsonSerializer.Deserialize<
                        EventSubjectOutput<
                            EventSubjectDataBusiness<EventBodyChannelMessage<MessageBodyVideo>>>>(message);
                if (messageResult == null)
                {
                    return;
                }

                _eventProcessService.ChannelMessageEvent(messageResult);
            }
            else if (eventBody.MessageType == MessageTypeConst.File)
            {
                var messageResult =
                    JsonSerializer.Deserialize<
                        EventSubjectOutput<EventSubjectDataBusiness<EventBodyChannelMessage<MessageBodyFile>>>>(
                        message);
                if (messageResult == null)
                {
                    return;
                }

                _eventProcessService.ChannelMessageEvent(messageResult);
            }
        }
        else if (eventSubjectDataResult.Data.EventType == EventTypeConst.MessageReaction)
        {
            var eventBodyResult =
                JsonSerializer.Deserialize<EventSubjectOutput<EventSubjectDataBusiness<EventBodyMessageReaction>>>(
                    message);
            if (eventBodyResult == null)
            {
                return;
            }

            _eventProcessService.MessageReactionEvent(eventBodyResult);
        }
        else if (eventSubjectDataResult.Data.EventType == EventTypeConst.MemberJoin)
        {
            var eventBodyResult =
                JsonSerializer.Deserialize<EventSubjectOutput<EventSubjectDataBusiness<EventBodyMemberJoin>>>(
                    message);
            if (eventBodyResult == null)
            {
                return;
            }

            _eventProcessService.MemberJoinEvent(eventBodyResult);
        }
        else if (eventSubjectDataResult.Data.EventType == EventTypeConst.MemberLeave)
        {
            var eventBodyResult =
                JsonSerializer.Deserialize<EventSubjectOutput<EventSubjectDataBusiness<EventBodyMemberLeave>>>(
                    message);
            if (eventBodyResult == null)
            {
                return;
            }

            _eventProcessService.MemberLeaveEvent(eventBodyResult);
        }
    }
}
