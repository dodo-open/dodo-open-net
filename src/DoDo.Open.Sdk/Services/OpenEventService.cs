using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DoDo.Open.Sdk.Models;
using DoDo.Open.Sdk.Models.WebSockets;

namespace DoDo.Open.Sdk.Services;

/// <summary>
///     开放事件服务
/// </summary>
public class OpenEventService
{
    private readonly EventProcessService _eventProcessService;
    private readonly OpenApiService _openApiService;
    private readonly OpenEventOptions _openEventOptions;
    private ClientWebSocket _clientWebSocket;

    public OpenEventService(OpenApiService openApiService, EventProcessService eventProcessService,
        OpenEventOptions openEventOptions)
    {
        _openApiService = openApiService;
        _eventProcessService = eventProcessService;
        _openEventOptions = openEventOptions;
    }

    /// <summary>
    ///     接收事件消息
    /// </summary>
    /// <returns></returns>
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
                    _eventProcessService.Disconnected("获取WebSocket连接失败");
                }
                catch (Exception ex)
                {
                    try
                    {
                        _eventProcessService.Exception(ex.Message);
                    }
                    catch (Exception)
                    {
                        // ignored
                    }
                }

                return;
            }

            Console.WriteLine($"开始连接：{getWebSocketConnectionOutput.Endpoint}");


            for (var i = 0; i < 3; i++)
            {
                try
                {
                    _clientWebSocket = new ClientWebSocket();
                    await _clientWebSocket.ConnectAsync(new Uri(getWebSocketConnectionOutput.Endpoint),
                        CancellationToken.None);
                    try
                    {
                        _eventProcessService.Connected("连接成功");
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            _eventProcessService.Exception(ex.Message);
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
                    _eventProcessService.Disconnected("WebSocket连接失败");
                }
                catch (Exception ex)
                {
                    try
                    {
                        _eventProcessService.Exception(ex.Message);
                    }
                    catch (Exception)
                    {
                        // ignored
                    }
                }

                return;
            }

            while (_clientWebSocket.CloseStatus != WebSocketCloseStatus.NormalClosure)
                try
                {
                    var buffer = new ArraySegment<byte>(new byte[20480]);
                    var receive = await _clientWebSocket.ReceiveAsync(buffer, CancellationToken.None);

                    if (buffer.Array != null)
                        try
                        {
                            var json = Encoding.UTF8.GetString(buffer.Array, 0, receive.Count);
                            if (string.IsNullOrWhiteSpace(json))
                            {
                                continue;
                            }
                            if (_openEventOptions.IsAsync)
                                await Task.Factory.StartNew(() =>
                                {
                                    try
                                    {
                                        _eventProcessService.ReceivedInternal(json);
                                    }
                                    catch (Exception ex)
                                    {
                                        try
                                        {
                                            _eventProcessService.Exception(ex.Message);
                                        }
                                        catch (Exception)
                                        {
                                            // ignored
                                        }
                                    }
                                });
                            else
                            {
                                _eventProcessService.ReceivedInternal(json);
                            }
                        }
                        catch (Exception ex)
                        {
                            try
                            {
                                _eventProcessService.Exception(ex.Message);
                            }
                            catch (Exception)
                            {
                                // ignored
                            }
                        }
                }
                catch (Exception e)
                {
                    try
                    {
                        _eventProcessService.Disconnected(e.Message);
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            _eventProcessService.Exception(ex.Message);
                        }
                        catch (Exception)
                        {
                            // ignored
                        }
                    }

                    if (_openEventOptions.IsReconnect)
                    {
                        var reconnectCount = 0;

                        while (_clientWebSocket.CloseStatus != WebSocketCloseStatus.NormalClosure)
                            try
                            {
                                if (_clientWebSocket.State != WebSocketState.Open)
                                {
                                    _clientWebSocket = new ClientWebSocket();
                                    await _clientWebSocket.ConnectAsync(new Uri(getWebSocketConnectionOutput.Endpoint),
                                        CancellationToken.None);
                                    try
                                    {
                                        _eventProcessService.Connected("连接成功");
                                    }
                                    catch (Exception ex)
                                    {
                                        try
                                        {
                                            _eventProcessService.Exception(ex.Message);
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
                                    _eventProcessService.Reconnected("断线重连中");
                                }
                                catch (Exception ex)
                                {
                                    try
                                    {
                                        _eventProcessService.Exception(ex.Message);
                                    }
                                    catch (Exception)
                                    {
                                        // ignored
                                    }
                                }

                                if (reconnectCount < 300) reconnectCount += 5;
                                await Task.Delay(1000 * reconnectCount);
                            }
                    }
                    else
                    {
                        return;
                    }
                }

            if (_clientWebSocket.CloseStatus == WebSocketCloseStatus.NormalClosure)
                try
                {
                    _eventProcessService.Disconnected("停止接收");
                }
                catch (Exception ex)
                {
                    try
                    {
                        _eventProcessService.Exception(ex.Message);
                    }
                    catch (Exception)
                    {
                        // ignored
                    }
                }
        }
        catch (Exception ex)
        {
            try
            {
                _eventProcessService.Exception(ex.Message);
            }
            catch (Exception)
            {
                // ignored
            }
        }
    }

    /// <summary>
    ///     停止接收事件消息
    /// </summary>
    public async Task StopReceiveAsync()
    {
        if (_clientWebSocket != null && _clientWebSocket.State != WebSocketState.Closed)
            await _clientWebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "", CancellationToken.None);
    }
}
