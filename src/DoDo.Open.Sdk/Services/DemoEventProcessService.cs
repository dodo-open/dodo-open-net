using System;
using System.Text.RegularExpressions;
using System.Threading;
using DoDo.Open.Sdk.Models.Bots;
using DoDo.Open.Sdk.Models.Channels;
using DoDo.Open.Sdk.Models.Events;
using DoDo.Open.Sdk.Models.Islands;
using DoDo.Open.Sdk.Models.Members;
using DoDo.Open.Sdk.Models.Messages;
using DoDo.Open.Sdk.Models.Personals;
using DoDo.Open.Sdk.Models.Resources;
using DoDo.Open.Sdk.Models.Roles;
using DoDo.Open.Sdk.Models.WebSockets;

namespace DoDo.Open.Sdk.Services
{
    /// <summary>
    /// 示例事件处理服务
    /// </summary>
    public class DemoEventProcessService : EventProcessService
    {
        private readonly OpenApiService _openApiService;

        public DemoEventProcessService(OpenApiService openApiService)
        {
            _openApiService = openApiService;
        }

        public override void Connected(string message)
        {
            Console.WriteLine($"{message}\n");
        }

        public override void Disconnected(string message)
        {
            Console.WriteLine($"{message}\n");
        }

        public override void Reconnected(string message)
        {
            Console.WriteLine($"{message}\n");
        }

        public override void Exception(string message)
        {
            Console.WriteLine($"{message}\n");
        }

        public override void PersonalMessageEvent<T>(EventSubjectOutput<EventSubjectDataBusiness<EventBodyPersonalMessage<T>>> input)
        {
            var eventBody = input.Data.EventBody;

            if (eventBody.MessageBody is MessageBodyText messageBodyText)
            {
                var messageBody = messageBodyText;

                _openApiService.SetPersonalMessageSend(new SetPersonalMessageSendInput<MessageBodyText>
                {
                    DoDoId = eventBody.DodoId,
                    MessageBody = new MessageBodyText
                    {
                        Content = "触发个人消息事件-文本"
                    }
                });

                _openApiService.SetPersonalMessageSend(new SetPersonalMessageSendInput<MessageBodyText>
                {
                    DoDoId = eventBody.DodoId,
                    MessageBody = messageBody
                });
            }
            else if (eventBody.MessageBody is MessageBodyPicture messageBodyPicture)
            {
                var messageBody = messageBodyPicture;

                _openApiService.SetPersonalMessageSend(new SetPersonalMessageSendInput<MessageBodyText>
                {
                    DoDoId = eventBody.DodoId,
                    MessageBody = new MessageBodyText
                    {
                        Content = "触发个人消息事件-图片"
                    }
                });

                _openApiService.SetPersonalMessageSend(new SetPersonalMessageSendInput<MessageBodyPicture>
                {
                    DoDoId = eventBody.DodoId,
                    MessageBody = messageBody
                });
            }
            else if (eventBody.MessageBody is MessageBodyVideo messageBodyVideo)
            {
                var messageBody = messageBodyVideo;

                _openApiService.SetPersonalMessageSend(new SetPersonalMessageSendInput<MessageBodyText>
                {
                    DoDoId = eventBody.DodoId,
                    MessageBody = new MessageBodyText
                    {
                        Content = "触发个人消息事件-视频"
                    }
                });

                _openApiService.SetPersonalMessageSend(new SetPersonalMessageSendInput<MessageBodyVideo>
                {
                    DoDoId = eventBody.DodoId,
                    MessageBody = messageBody
                });
            }
        }

        public override void ChannelMessageEvent<T>(EventSubjectOutput<EventSubjectDataBusiness<EventBodyChannelMessage<T>>> input)
        {
            var eventBody = input.Data.EventBody;

            if (eventBody.MessageBody is MessageBodyText messageBodyText)
            {
                var messageBody = messageBodyText;

                var content = messageBody.Content;
                var reply = "";

                Console.WriteLine($"\n【{content}】");

                if (content.StartsWith("菜单"))
                {
                    reply += $"<@!{eventBody.DodoId}>\n\n";
                    reply += "**菜单来咯！**\n\n";
                    reply += "【机器人】取机器人信息\n";
                    reply += "【机器人】置机器人群退出\n";
                    reply += "【群】取群列表\n";
                    reply += "【群】取群信息\n";
                    reply += "【频道】取频道列表\n";
                    reply += "【频道】取频道信息\n";
                    reply += "【频道】置频道文本消息发送\n";
                    reply += "【频道】置频道图片消息发送\n";
                    reply += "【频道】置频道视频消息发送\n";
                    reply += "【频道】置频道消息编辑\n";
                    reply += "【频道】置频道消息撤回\n";
                    reply += "【身份组】取身份组列表\n";
                    reply += "【身份组】置身份组成员新增 ID\n";
                    reply += "【身份组】置身份组成员移除 ID\n";
                    reply += "【成员】取成员列表\n";
                    reply += "【成员】取成员信息\n";
                    reply += "【成员】取成员身份组列表\n";
                    reply += "【成员】置成员昵称\n";
                    reply += "【成员】置成员禁言\n";
                    reply += "【个人】置个人文本消息发送\n";
                    reply += "【个人】置个人图片消息发送\n";
                    reply += "【个人】置个人视频消息发送\n";
                    reply += "【资源】置资源图片上传\n";
                    reply += "【事件】取WebSocket连接\n";
                }
                else if (content.StartsWith("取机器人信息"))
                {
                    var output = _openApiService.GetBotInfo(new GetBotInfoInput());

                    if (output != null)
                    {
                        reply += $"机器人唯一标识：{output.ClientId}\n";
                        reply += $"机器人DoDo号：{output.DodoId}\n";
                        reply += $"机器人昵称：{output.NickName}\n";
                        reply += $"机器人头像：{output.AvatarUrl}\n";
                    }
                    else
                    {
                        reply += "调用接口失败！";
                    }
                }
                else if (content.Contains("置机器人群退出"))
                {
                    var output = _openApiService.SetBotIslandLeave(new SetBotIslandLeaveInput
                    {
                        IslandId = eventBody.IslandId
                    });

                    if (output)
                    {
                        reply += "置机器人群成功！";
                    }
                    else
                    {
                        reply += "调用接口失败！";
                    }
                }
                else if (content.Contains("取群列表"))
                {
                    var outputList = _openApiService.GetIslandList(new GetIslandListInput());

                    if (outputList != null)
                    {
                        if (outputList.Count > 0)
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
                            reply += "暂无列表数据！";
                        }
                    }
                    else
                    {
                        reply += "调用接口失败！";
                    }

                }
                else if (content.Contains("取群信息"))
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
                else if (content.Contains("取频道列表"))
                {
                    var outputList = _openApiService.GetChannelList(new GetChannelListInput
                    {
                        IslandId = eventBody.IslandId
                    });

                    if (outputList != null)
                    {
                        if (outputList.Count > 0)
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
                            reply += "暂无列表数据！";
                        }
                    }
                    else
                    {
                        reply += "调用接口失败！";
                    }

                }
                else if (content.Contains("取频道信息"))
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
                else if (content.Contains("置频道文本消息发送"))
                {
                    var output = _openApiService.SetChannelMessageSend(new SetChannelMessageSendInput<MessageBodyText>
                    {
                        ChannelId = eventBody.ChannelId,
                        MessageBody = new MessageBodyText
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
                else if (content.Contains("置频道图片消息发送"))
                {
                    var output = _openApiService.SetChannelMessageSend(new SetChannelMessageSendInput<MessageBodyPicture>
                    {
                        ChannelId = eventBody.ChannelId,
                        MessageBody = new MessageBodyPicture
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
                else if (content.Contains("置频道视频消息发送"))
                {
                    var output = _openApiService.SetChannelMessageSend(new SetChannelMessageSendInput<MessageBodyVideo>
                    {
                        ChannelId = eventBody.ChannelId,
                        MessageBody = new MessageBodyVideo
                        {
                            Url = "https://video.imdodo.com/dodo/ff85c752daf7d67884cb9ad3921a5d01.mp4",
                            CoverUrl = "https://img.imdodo.com/dodo/8c77d48865bf547a69fb3bba6228760c.png",
                            Duration = 0,
                            Size = 0
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
                else if (content.Contains("置频道消息编辑"))
                {
                    var outputMessage = _openApiService.SetChannelMessageSend(new SetChannelMessageSendInput<MessageBodyText>
                    {
                        ChannelId = eventBody.ChannelId,
                        MessageBody = new MessageBodyText
                        {
                            Content = "测试文本消息"
                        }
                    });

                    var output = _openApiService.SetChannelMessageEdit(new SetChannelMessageEditInput<MessageBodyText>
                    {
                        MessageId = outputMessage.MessageId,
                        MessageBody = new MessageBodyText
                        {
                            Content = "修改后的文本"
                        }
                    });

                    if (output)
                    {
                        reply += "置频道消息编辑成功！";
                    }
                    else
                    {
                        reply += "调用接口失败！";
                    }
                }
                else if (content.Contains("置频道消息撤回"))
                {
                    Thread.Sleep(3000);
                    var output = _openApiService.SetChannelMessageWithdraw(new SetChannelMessageWithdrawInput
                    {
                        MessageId = eventBody.MessageId,
                        Reason = "撤回测试"
                    });

                    if (output)
                    {
                        reply += "置频道消息撤回成功！";
                    }
                    else
                    {
                        reply += "调用接口失败！";
                    }

                }
                else if (content.Contains("取身份组列表"))
                {
                    var outputList = _openApiService.GetRoleList(new GetRoleListInput
                    {
                        IslandId = eventBody.IslandId
                    });

                    if (outputList != null)
                    {
                        if (outputList.Count > 0)
                        {
                            foreach (var output in outputList)
                            {
                                reply += $"身份组ID：{output.RoleId}\n";
                                reply += $"身份组名称：{output.RoleName}\n";
                                reply += "\n";
                            }
                        }
                        else
                        {
                            reply += "暂无列表数据！";
                        }
                    }
                    else
                    {
                        reply += "调用接口失败！";
                    }

                }
                else if (content.Contains("置身份组成员新增"))
                {
                    var regex = Regex.Match(content, @"(\d+?)$");

                    var output = _openApiService.SetRoleMemberAdd(new SetRoleMemberAddInput
                    {
                        IslandId = eventBody.IslandId,
                        DoDoId = eventBody.DodoId,
                        RoleId = regex.Value
                    });

                    if (output)
                    {
                        reply += "置身份组成员新增成功！";
                    }
                    else
                    {
                        reply += "调用接口失败！";
                    }

                }
                else if (content.Contains("置身份组成员移除"))
                {
                    var regex = Regex.Match(content, @"(\d+?)$");
                    var output = _openApiService.SetRoleMemberRemove(new SetRoleMemberRemoveInput
                    {
                        IslandId = eventBody.IslandId,
                        DoDoId = eventBody.DodoId,
                        RoleId = regex.Value
                    });

                    if (output)
                    {
                        reply += "置身份组成员移除成功！";
                    }
                    else
                    {
                        reply += "调用接口失败！";
                    }

                }
                else if (content.Contains("取成员列表"))
                {
                    var outputList = _openApiService.GetMemberList(new GetMemberListInput
                    {
                        IslandId = eventBody.IslandId,
                        PageSize = 3,
                        MaxId = 0
                    });

                    if (outputList?.List != null)
                    {
                        if (outputList.List.Count > 0)
                        {
                            foreach (var output in outputList.List)
                            {
                                reply += $"DoDo号：{output.DodoId}\n";
                                reply += $"在群昵称：{output.NickName}\n";
                                reply += $"头像：{output.AvatarUrl}\n";
                                reply += $"加群时间：{output.JoinTime}\n";
                                reply += $"性别：{output.Sex}\n";
                                reply += $"等级：{output.Level}\n";
                                reply += $"是否机器人：{output.IsBot}\n";
                                reply += "\n";
                            }
                        }
                        else
                        {
                            reply += "暂无列表数据！";
                        }
                    }
                    else
                    {
                        reply += "调用接口失败！";
                    }
                }
                else if (content.Contains("取成员信息"))
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
                        reply += $"在群昵称：{output.NickName}\n";
                        reply += $"头像：{output.AvatarUrl}\n";
                        reply += $"加群时间：{output.JoinTime}\n";
                        reply += $"性别：{output.Sex}\n";
                        reply += $"等级：{output.Level}\n";
                        reply += $"是否机器人：{output.IsBot}\n";
                        reply += $"在线设备：{output.OnlineDevice}\n";
                        reply += $"在线状态：{output.OnlineStatus}\n";
                    }
                    else
                    {
                        reply += "调用接口失败！";
                    }

                }
                else if (content.Contains("取成员身份组列表"))
                {
                    var outputList = _openApiService.GetMemberRoleList(new GetMemberRoleListInput
                    {
                        IslandId = eventBody.IslandId,
                        DodoId = eventBody.DodoId
                    });

                    if (outputList != null)
                    {
                        if (outputList.Count > 0)
                        {
                            foreach (var output in outputList)
                            {
                                reply += $"身份组ID：{output.RoleId}\n";
                                reply += $"身份组名称：{output.RoleName}\n";
                                reply += "\n";
                            }
                        }
                        else
                        {
                            reply += "暂无列表数据！";
                        }
                    }
                    else
                    {
                        reply += "调用接口失败！";
                    }

                }
                else if (content.Contains("置成员昵称"))
                {
                    var output = _openApiService.SetMemberNick(new SetMemberNickInput
                    {
                        IslandId = eventBody.IslandId,
                        DoDoId = eventBody.DodoId,
                        NickName = "昵称修改测试"
                    });

                    if (output)
                    {
                        reply += "置成员昵称成功！";
                    }
                    else
                    {
                        reply += "调用接口失败！";
                    }
                }
                else if (content.Contains("置成员禁言"))
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
                        reply += "置成员禁言成功！";
                    }
                    else
                    {
                        reply += "调用接口失败！";
                    }
                }
                else if (content.Contains("置个人文本消息发送"))
                {
                    var output = _openApiService.SetPersonalMessageSend(new SetPersonalMessageSendInput<MessageBodyText>
                    {
                        DoDoId = eventBody.DodoId,
                        MessageBody = new MessageBodyText
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
                else if (content.Contains("置个人图片消息发送"))
                {
                    var output = _openApiService.SetPersonalMessageSend(new SetPersonalMessageSendInput<MessageBodyPicture>
                    {
                        DoDoId = eventBody.DodoId,
                        MessageBody = new MessageBodyPicture
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
                else if (content.Contains("置个人视频消息发送"))
                {
                    var output = _openApiService.SetPersonalMessageSend(new SetPersonalMessageSendInput<MessageBodyVideo>
                    {
                        DoDoId = eventBody.DodoId,
                        MessageBody = new MessageBodyVideo
                        {
                            Url = "https://video.imdodo.com/dodo/ff85c752daf7d67884cb9ad3921a5d01.mp4",
                            CoverUrl = "https://img.imdodo.com/dodo/8c77d48865bf547a69fb3bba6228760c.png",
                            Duration = 0,
                            Size = 0
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
                else if (content.Contains("置资源图片上传"))
                {
                    var output = _openApiService.SetResourcePictureUpload(new SetResourceUploadInput
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
                else if (content.Contains("取WebSocket连接"))
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
                    _openApiService.SetChannelMessageSend(new SetChannelMessageSendInput<MessageBodyText>
                    {
                        ChannelId = eventBody.ChannelId,
                        MessageBody = new MessageBodyText
                        {
                            Content = reply
                        }
                    });
                }
            }
            else if (eventBody.MessageBody is MessageBodyPicture messageBodyPicture)
            {
                var messageBody = messageBodyPicture;

                _openApiService.SetChannelMessageSend(new SetChannelMessageSendInput<MessageBodyText>
                {
                    ChannelId = eventBody.ChannelId,
                    MessageBody = new MessageBodyText
                    {
                        Content = "触发频道消息事件-图片"
                    }
                });

                _openApiService.SetChannelMessageSend(new SetChannelMessageSendInput<MessageBodyPicture>
                {
                    ChannelId = eventBody.ChannelId,
                    MessageBody = messageBody
                });
            }
            else if (eventBody.MessageBody is MessageBodyVideo messageBodyVideo)
            {
                var messageBody = messageBodyVideo;

                _openApiService.SetChannelMessageSend(new SetChannelMessageSendInput<MessageBodyText>
                {
                    ChannelId = eventBody.ChannelId,
                    MessageBody = new MessageBodyText
                    {
                        Content = "触发频道消息事件-视频"
                    }
                });

                _openApiService.SetChannelMessageSend(new SetChannelMessageSendInput<MessageBodyVideo>
                {
                    ChannelId = eventBody.ChannelId,
                    MessageBody = messageBody
                });
            }
        }

        public override void MessageReactionEvent(EventSubjectOutput<EventSubjectDataBusiness<EventBodyMessageReaction>> input)
        {
            var eventBody = input.Data.EventBody;

            _openApiService.SetChannelMessageSend(new SetChannelMessageSendInput<MessageBodyText>
            {
                ChannelId = eventBody.ChannelId,
                MessageBody = new MessageBodyText
                {
                    Content = "触发消息反应事件"
                }
            });

            var reply = "";

            reply += $"反应对象类型：{eventBody.ReactionTarget.Type}\n";
            reply += $"反应对象ID：{eventBody.ReactionTarget.Id}\n";
            reply += $"反应表情类型：{eventBody.ReactionEmoji.Type}\n";
            reply += $"反应表情ID：{eventBody.ReactionEmoji.Id}\n";
            reply += $"反应类型：{eventBody.ReactionType}\n";

            _openApiService.SetChannelMessageSend(new SetChannelMessageSendInput<MessageBodyText>
            {
                ChannelId = eventBody.ChannelId,
                MessageBody = new MessageBodyText
                {
                    Content = reply
                }
            });
        }
    }
}
