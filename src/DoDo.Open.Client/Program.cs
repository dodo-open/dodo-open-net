using System;
using DoDo.Open.Sdk.Models;
using DoDo.Open.Sdk.Services;

//接口配置
var openApiOptions = new OpenApiOptions
{
    BaseApi = "https://botopen-test.imdodo.com",
    ClientId = "82223747",
    Token = "ODIyMjM3NDc.fO-_vQ9m.N2wgeySOHBRd-7CqTzNkPiDFZZXJW1Jf2Q8zl-Co0II"
};
//开放接口服务
var openApiService = new OpenApiService(openApiOptions);
//示例事件处理服务，该服务仅用作前期测试，需要开发具体功能时请替换成自己的实现类（继承IEventProcessService接口即可）
var eventProcessService = new DemoEventProcessService(openApiService);
//开放事件服务
var openEventService = new OpenEventService(openApiService, eventProcessService);

Console.WriteLine("\n开始接收事件消息\n");

await openEventService.ReceiveAsync(true);

Console.ReadKey();