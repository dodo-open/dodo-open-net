using System;
using DoDo.Open.Sdk.Models;
using DoDo.Open.Sdk.Services;

//开放接口服务
var openApiService = new OpenApiService(new OpenApiOptions
{
    BaseApi = "https://botopen-test.imdodo.com",
    ClientId = "82223747",
    Token = "ODIyMjM3NDc.fO-_vQ9m.N2wgeySOHBRd-7CqTzNkPiDFZZXJW1Jf2Q8zl-Co0II"
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