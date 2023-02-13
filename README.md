<p align="center">
  <a href="https://open.imdodo.com">
    <img src="https://avatars.githubusercontent.com/u/96616694" width="200" height="200" alt="dodo-open">
  </a>
</p>

<div align="center">

  # dodo-open-net

  _✨ 基于最新 C# .NET Standard 开发，支持Windows、MacOS、Linux、Docker，完美跨平台。 ✨_

  <a href="https://github.com/dodo-open/dodo-open-net/blob/main/LICENSE">
    <img src="https://img.shields.io/github/license/dodo-open/dodo-open-net" alt="license">
  </a>
  <a href="https://github.com/dodo-open/dodo-open-net/releases">
    <img src="https://img.shields.io/github/v/release/dodo-open/dodo-open-net?color=blueviolet&include_prereleases"
      alt="release">
  </a>

</div>

## 项目介绍

- 项目内包含完整的SDK源码以及SDK调用实例，请放心使用！

- 您既可以下载SDK源码，项目内引用，亦可以通过Nuget包的方式引用，请参考下方 [示例项目](#示例项目)

## 开发工具

[Visual Studio 2022](https://visualstudio.microsoft.com/zh-hans/vs/)

- 安装时，请勾选ASP.NET和Web开发组件，其他组件按需安装

## 示例项目

[DoDo.Open.Client](https://github.com/dodo-open/dodo-open-net/tree/main/src/DoDo.Open.Client)

- 创建一个控制台程序
- 安装Nuget包 [DoDo.Open.SDK](https://www.nuget.org/packages/DoDo.Open.Sdk/)
- 入口类Program.cs使用以下代码
- 启动控制台程序
- 机器人所在群内发送"菜单"即可查看示例功能

```cs

using System;
using DoDo.Open.Sdk.Consts;
using DoDo.Open.Sdk.Models;
using DoDo.Open.Sdk.Services;
using DoDo.Open.Sdk.Models.WebHooks;

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

```

## 核心代码

#### [OpenApiService](https://github.com/dodo-open/dodo-open-net/blob/main/src/DoDo.Open.Sdk/Services/OpenApiService.cs)

此类封装了接口相关调用逻辑

#### [OpenEventService](https://github.com/dodo-open/dodo-open-net/blob/main/src/DoDo.Open.Sdk/Services/OpenEventService.cs)

此类封装了事件相关接收逻辑

#### [EventProcessService](https://github.com/dodo-open/dodo-open-net/blob/main/src/DoDo.Open.Sdk/Services/EventProcessService.cs)

此抽象类封装了事件相关处理逻辑，用户只需要创建自己的处理类（例如：[DemoEventProcessService](https://github.com/dodo-open/dodo-open-net/blob/main/src/DoDo.Open.Sdk/Services/DemoEventProcessService.cs)）并继承此抽象类，即可自定义处理逻辑

继承后，必须通过override关键词重写Connected、Disconnected、Reconnected、Exception核心方法，其他事件方法可以选择性重写！
