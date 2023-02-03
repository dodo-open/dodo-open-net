using System;
using System.Text.Json;
using DoDo.Open.Sdk.Consts;
using DoDo.Open.Sdk.Models;
using DoDo.Open.Sdk.Models.WebHooks;
using DoDo.Open.Sdk.Services;
using DoDo.Open.Sdk.Utils;

//接口服务
var openApiService = new OpenApiService(new OpenApiOptions
{
    BaseApi = "接口地址",
    ClientId = "机器人唯一标识",
    Token = "机器人鉴权Token",
    Log = message =>
    {
        Console.WriteLine(message);
        Console.WriteLine();
    }
});
//事件处理服务，可自定义，只要继承EventProcessService抽象类即可
var eventProcessService = new DemoEventProcessService(openApiService);
//事件配置
var openEventOptions = new OpenEventOptions { IsAsync = true };
//事件服务
var openEventService = new OpenEventService(openApiService, eventProcessService, openEventOptions);

//接收来自WebSocket的事件消息，启动后自动连接并接收消息，开发者无需任何额外操作
openEventOptions.Protocol = EventProtocolConst.WebSocket;
openEventOptions.IsReconnect = true;
await openEventService.ReceiveAsync();

//接收来自WebHook的事件消息，开发者回调地址收到消息后，可将消息推送至该服务进行处理
/*openEventOptions.Protocol = EventProtocolConst.WebHook;
openEventOptions.SecretKey = "事件密钥SecretKey";
var openWebHookOutput = await openEventService.ReceiveAsync(new OpenWebHookInput
{
    ClientId = "机器人唯一标识",
    Payload = "加密消息"
});*/