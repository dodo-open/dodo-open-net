using System;
using DoDo.Open.Sdk.Models;
using DoDo.Open.Sdk.Services;

//开放接口服务
var openApiService = new OpenApiService(new OpenApiOptions
{
    BaseApi = "接口地址",
    ClientId = "机器人唯一标识",
    Token = "机器人鉴权Token"
});
//事件处理服务，可自定义，只要继承EventProcessService抽象类即可
var eventProcessService = new DemoEventProcessService(openApiService);
//开放事件服务
var openEventService = new OpenEventService(openApiService, eventProcessService, new OpenEventOptions
{
    IsReconnect = true,
    IsAsync = true
});
//接收事件消息
await openEventService.ReceiveAsync();

Console.ReadKey();