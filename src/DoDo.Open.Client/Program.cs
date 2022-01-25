using System;
using DoDo.Open.Sdk.Models;
using DoDo.Open.Sdk.Services;

//接口配置
var openApiOptions = new OpenApiOptions
{
    BaseApi = "接口地址",
    ClientId = "机器人唯一标识",
    ClientSecret = "密钥，切勿泄漏，验证签名使用",
    Token = "鉴权token",
    PublicKey = "公钥，用于签名加密"
};
//开放接口服务
var openApiService = new OpenApiService(openApiOptions);
//示例事件处理服务
var eventProcessService = new DemoEventProcessService(openApiService);
//开放事件服务
var openEventService = new OpenEventService(openApiService, eventProcessService);

Console.WriteLine("\n开始接收事件消息\n");

await openEventService.ReceiveAsync(true);

Console.ReadKey();