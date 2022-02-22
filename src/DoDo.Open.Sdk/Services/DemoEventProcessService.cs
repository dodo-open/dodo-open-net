using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using DoDo.Open.Sdk.Models.Bots;
using DoDo.Open.Sdk.Models.Channels;
using DoDo.Open.Sdk.Models.Events;
using DoDo.Open.Sdk.Models.Islands;
using DoDo.Open.Sdk.Models.Members;
using DoDo.Open.Sdk.Models.Messages;
using DoDo.Open.Sdk.Models.Resources;
using DoDo.Open.Sdk.Models.WebSockets;
using Newtonsoft.Json;

namespace DoDo.Open.Sdk.Services
{
    /// <summary>
    /// 示例事件处理服务
    /// </summary>
    public class DemoEventProcessService : IEventProcessService
    {
        private readonly OpenApiService _openApiService;

        public DemoEventProcessService(OpenApiService openApiService)
        {
            _openApiService = openApiService;
        }

        public void Received(string message)
        {
            Task.Factory.StartNew(() =>
            {
                Console.WriteLine($"{message}\n");

                var eventSubjectResult = JsonConvert.DeserializeObject<EventSubjectOutput<EventSubjectDataBase>>(message);
                if (eventSubjectResult == null) return;

                if (eventSubjectResult.Type == EventSubjectDataTypeConst.Business)
                {
                    var eventSubjectDataResult = JsonConvert.DeserializeObject<EventSubjectOutput<EventSubjectDataBusiness<EventBodyBase>>>(message);
                    if (eventSubjectDataResult == null) return;

                    if (eventSubjectDataResult.Data.EventType == EventTypeConst.ChannelMessage)
                    {
                        var eventBodyResult = JsonConvert.DeserializeObject<EventSubjectOutput<EventSubjectDataBusiness<EventBodyChannelMessage<MessageBase>>>>(message);
                        if (eventBodyResult == null) return;

                        var eventBody = eventBodyResult.Data.EventBody;

                        if (eventBody.MessageType == MessageTypeConst.Text)
                        {
                            var messageResult = JsonConvert.DeserializeObject<EventSubjectOutput<EventSubjectDataBusiness<EventBodyChannelMessage<MessageText>>>>(message);
                            if (messageResult == null) return;

                            var messageBody = messageResult.Data.EventBody.MessageBody;
                            var content = messageBody.Content;
                            var reply = "";

                            Console.WriteLine($"\n【{content}】");

                            if (content.StartsWith("菜单"))
                            {
                                reply += $"<@!{eventBody.DodoId}>\n\n";
                                reply += "**菜单来咯！**\n\n";
                                reply += "取机器人信息\n";
                                reply += "取群列表\n";
                                reply += "取群信息\n";
                                reply += "取频道列表\n";
                                reply += "取频道信息\n";
                                reply += "置频道文本消息发送\n";
                                reply += "置频道图片消息发送\n";
                                reply += "置频道视频消息发送\n";
                                reply += "置频道消息撤回\n";
                                reply += "取成员信息\n";
                                reply += "置成员禁言\n";
                                reply += "置资源图片上传\n";
                                reply += "取WebSocket连接\n";
                            }
                            else if (content.StartsWith("取机器人信息"))
                            {
                                var output = _openApiService.GetBotInfo(new GetBotInfoInput());

                                if (output != null)
                                {
                                    reply += $"机器人唯一标识：{output.ClientId}\n";
                                    reply += $"机器人DoDo号：{output.DodoId}\n";
                                    reply += $"机器人昵称：{output.NickName}\n";
                                    reply += $"机器人图标：{output.AvatarUrl}\n";
                                }
                                else
                                {
                                    reply += "调用接口失败！";
                                }
                            }
                            else if (content.StartsWith("取群列表"))
                            {
                                var outputList = _openApiService.GetIslandList(new GetIslandListInput());

                                if (outputList != null)
                                {
                                    foreach (var output in outputList)
                                    {
                                        reply += $"群号：{output.IslandId}\n";
                                        reply += $"群名称：{output.IslandName}\n";
                                        reply += $"群头像：{output.CoverUrl}\n";
                                        reply += $"系统公告频道号：{output.SystemChannelId}\n";
                                        reply += $"进群默认频道号：{output.DefaultChannelId}\n";
                                        reply += "\n";
                                    }
                                }
                                else
                                {
                                    reply += "调用接口失败！";
                                }

                            }
                            else if (content.StartsWith("取群信息"))
                            {
                                var output = _openApiService.GetIslandInfo(new GetIslandInfoInput
                                {
                                    IslandId = eventBody.IslandId
                                });

                                if (output != null)
                                {
                                    reply += $"群号：{output.IslandId}\n";
                                    reply += $"群名称：{output.IslandName}\n";
                                    reply += $"群头像：{output.CoverUrl}\n";
                                    reply += $"群描述：{output.Description}\n";
                                    reply += $"系统公告频道号：{output.SystemChannelId}\n";
                                    reply += $"进群默认频道号：{output.DefaultChannelId}\n";
                                }
                                else
                                {
                                    reply += "调用接口失败！";
                                }
                            }
                            else if (content.StartsWith("取频道列表"))
                            {
                                var outputList = _openApiService.GetChannelList(new GetChannelListInput
                                {
                                    IslandId = eventBody.IslandId
                                });

                                if (outputList != null)
                                {
                                    foreach (var output in outputList)
                                    {
                                        reply += $"频道号：{output.ChannelId}\n";
                                        reply += $"频道名称：{output.ChannelName}\n";
                                        reply += $"默认频道标识：{output.DefaultFlag}\n";
                                        reply += "\n";
                                    }
                                }
                                else
                                {
                                    reply += "调用接口失败！";
                                }

                            }
                            else if (content.StartsWith("取频道信息"))
                            {
                                var output = _openApiService.GetChannelInfo(new GetChannelInfoInput
                                {
                                    ChannelId = eventBody.ChannelId
                                });

                                if (output != null)
                                {
                                    reply += $"频道号：{output.ChannelId}\n";
                                    reply += $"频道名称：{output.ChannelName}\n";
                                    reply += $"默认频道标识：{output.DefaultFlag}\n";
                                    reply += "\n";
                                }
                                else
                                {
                                    reply += "调用接口失败！";
                                }
                            }
                            else if (content.StartsWith("置频道文本消息发送"))
                            {
                                var output = _openApiService.SendChannelMessage(new SendChannelMessageInput<MessageText>
                                {
                                    ChannelId = eventBody.ChannelId,
                                    MessageBody = new MessageText
                                    {
                                        Content = "测试文本消息"
                                    }
                                });

                                if (output != null)
                                {
                                    reply += $"消息ID：{output.MessageId}\n";
                                }
                                else
                                {
                                    reply += "调用接口失败！";
                                }
                            }
                            else if (content.StartsWith("置频道图片消息发送"))
                            {
                                var output = _openApiService.SendChannelMessage(new SendChannelMessageInput<MessagePicture>
                                {
                                    ChannelId = eventBody.ChannelId,
                                    MessageBody = new MessagePicture
                                    {
                                        Url = "https://img.imdodo.com/dodo/8c77d48865bf547a69fb3bba6228760c.png",
                                        Width = 500,
                                        Height = 500,
                                        IsOriginal = 1
                                    }
                                });

                                if (output != null)
                                {
                                    reply += $"消息ID：{output.MessageId}\n";
                                }
                                else
                                {
                                    reply += "调用接口失败！";
                                }
                            }
                            else if (content.StartsWith("置频道视频消息发送"))
                            {
                                var output = _openApiService.SendChannelMessage(new SendChannelMessageInput<MessageVideo>
                                {
                                    ChannelId = eventBody.ChannelId,
                                    MessageBody = new MessageVideo
                                    {
                                        Url = "https://video.imdodo.com/dodo/ff85c752daf7d67884cb9ad3921a5d01.mp4",
                                        CoverUrl = "https://img.imdodo.com/dodo/8c77d48865bf547a69fb3bba6228760c.png",
                                        Duration = 100,
                                        Size = 100
                                    }
                                });

                                if (output != null)
                                {
                                    reply += $"消息ID：{output.MessageId}\n";
                                }
                                else
                                {
                                    reply += "调用接口失败！";
                                }
                            }
                            else if (content.StartsWith("置频道消息撤回"))
                            {
                                Thread.Sleep(3000);
                                var output = _openApiService.WithdrawChannelMessage(new WithdrawChannelMessageInput
                                {
                                    MessageId = eventBody.MessageId
                                });

                                if (output)
                                {
                                    reply += "置频道消息撤回成功";
                                }
                                else
                                {
                                    reply += "调用接口失败！";
                                }

                            }
                            else if (content.StartsWith("取成员信息"))
                            {
                                var output = _openApiService.GetMemberInfo(new GetMemberInfoInput
                                {
                                    IslandId = eventBody.IslandId,
                                    DoDoId = eventBody.DodoId
                                });

                                if (output != null)
                                {
                                    reply += $"群号：{output.IslandId}\n";
                                    reply += $"DoDo号：{output.DodoId}\n";
                                    reply += $"昵称：{output.NickName}\n";
                                    reply += $"头像：{output.AvatarUrl}\n";
                                    reply += $"性别：{output.Sex}\n";
                                }
                                else
                                {
                                    reply += "调用接口失败！";
                                }

                            }
                            else if (content.StartsWith("置成员禁言"))
                            {
                                var output = _openApiService.SetMemberBan(new SetMemberBanInput
                                {
                                    IslandId = eventBody.IslandId,
                                    DoDoId = eventBody.DodoId,
                                    Duration = 30,
                                    Reason = "禁言测试"
                                });

                                if (output)
                                {
                                    reply += "置成员禁言成功";
                                }
                                else
                                {
                                    reply += "调用接口失败！";
                                }
                            }
                            else if (content.StartsWith("置资源图片上传", true, CultureInfo.CurrentCulture))
                            {
                                var output = _openApiService.UploadResourcePicture(new UploadResourceInput
                                {
                                    FilePath = "https://img.imdodo.com/dodo/8c77d48865bf547a69fb3bba6228760c.png"
                                });

                                if (output != null)
                                {
                                    reply += $"链接：{output.Url}\n";
                                    reply += $"高度：{output.Height}\n";
                                    reply += $"宽度：{output.Width }\n";
                                }
                                else
                                {
                                    reply += "调用接口失败！";
                                }
                            }
                            else if (content.StartsWith("取WebSocket连接", true, CultureInfo.CurrentCulture))
                            {
                                var output = _openApiService.GetWebSocketConnection(new GetWebSocketConnectionInput());

                                if (output != null)
                                {
                                    reply += $"节点：{output.Endpoint}\n";
                                }
                                else
                                {
                                    reply += "调用接口失败！";
                                }
                            }

                            if (reply != "")
                            {
                                _openApiService.SendChannelMessage(new SendChannelMessageInput<MessageText>
                                {
                                    ChannelId = eventBody.ChannelId,
                                    MessageBody = new MessageText
                                    {
                                        Content = reply
                                    }
                                });
                            }
                        }
                        else if (eventBody.MessageType == MessageTypeConst.Picture)
                        {
                            var messageResult = JsonConvert.DeserializeObject<EventSubjectOutput<EventSubjectDataBusiness<EventBodyChannelMessage<MessagePicture>>>>(message);
                            if (messageResult == null) return;

                            var messageBody = messageResult.Data.EventBody.MessageBody;

                            _openApiService.SendChannelMessage(new SendChannelMessageInput<MessageText>
                            {
                                ChannelId = eventBody.ChannelId,
                                MessageBody = new MessageText
                                {
                                    Content = "接收到频道图片消息："
                                }
                            });

                            _openApiService.SendChannelMessage(new SendChannelMessageInput<MessagePicture>
                            {
                                ChannelId = eventBody.ChannelId,
                                MessageBody = messageBody
                            });
                        }
                        else if (eventBody.MessageType == MessageTypeConst.Video)
                        {
                            var messageResult = JsonConvert.DeserializeObject<EventSubjectOutput<EventSubjectDataBusiness<EventBodyChannelMessage<MessageVideo>>>>(message);
                            if (messageResult == null) return;

                            var messageBody = messageResult.Data.EventBody.MessageBody;

                            _openApiService.SendChannelMessage(new SendChannelMessageInput<MessageText>
                            {
                                ChannelId = eventBody.ChannelId,
                                MessageBody = new MessageText
                                {
                                    Content = "接收到频道视频消息："
                                }
                            });

                            _openApiService.SendChannelMessage(new SendChannelMessageInput<MessageVideo>
                            {
                                ChannelId = eventBody.ChannelId,
                                MessageBody = messageBody
                            });
                        }
                    }
                }
            });
        }

        public void Connected(string message)
        {
            Console.WriteLine($"{message}\n");
        }

        public void Disconnected(string message)
        {
            Console.WriteLine($"{message}\n");
        }

        public void Reconnected(string message)
        {
            Console.WriteLine($"{message}\n");
        }

        public void Exception(string message)
        {
            Console.WriteLine($"{message}\n");
        }
    }
}
