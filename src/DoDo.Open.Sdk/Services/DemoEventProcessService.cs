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

        public override void Received(string message)
        {
            Console.WriteLine($"接收事件：{message}\n");
        }

        public override void PersonalMessageEvent<T>(EventSubjectOutput<EventSubjectDataBusiness<EventBodyPersonalMessage<T>>> input)
        {
            var eventBody = input.Data.EventBody;
            var reply = "";

            if (eventBody.MessageBody is MessageBodyText messageBodyText)
            {
                var messageBody = messageBodyText;

                reply += "触发私信事件-文字消息\n";
                reply += "内容：" + messageBody.Content;
            }
            else if (eventBody.MessageBody is MessageBodyPicture messageBodyPicture)
            {
                var messageBody = messageBodyPicture;

                reply += "触发私信事件-图片消息\n";
                reply += $"图片链接：{messageBody.Url}\n";
                reply += $"图片宽度：{messageBody.Width}\n";
                reply += $"图片高度：{messageBody.Height}\n";
                reply += $"是否原图：{messageBody.IsOriginal}\n";
            }
            else if (eventBody.MessageBody is MessageBodyVideo messageBodyVideo)
            {
                var messageBody = messageBodyVideo;

                reply += "触发私信事件-视频消息\n";
                reply += $"视频链接：{messageBody.Url}\n";
                reply += $"封面链接：{messageBody.CoverUrl}\n";
                reply += $"视频时长：{messageBody.Duration}\n";
                reply += $"视频大小：{messageBody.Size}\n";
            }

            if (reply != "")
            {
                _openApiService.SetPersonalMessageSend(new SetPersonalMessageSendInput<MessageBodyText>
                {
                    DodoId = eventBody.DodoId,
                    MessageBody = new MessageBodyText
                    {
                        Content = reply
                    }
                });
            }
        }

        public override void ChannelMessageEvent<T>(EventSubjectOutput<EventSubjectDataBusiness<EventBodyChannelMessage<T>>> input)
        {
            var eventBody = input.Data.EventBody;

            var reply = "";

            if (eventBody.MessageBody is MessageBodyText messageBodyText)
            {
                var messageBody = messageBodyText;

                var content = messageBody.Content;

                Console.WriteLine($"\n【{content}】");

                try
                {
                    if (content.StartsWith("菜单"))
                    {
                        reply += $"<@!{eventBody.DodoId}>\n\n";
                        reply += "**菜单来咯！**\n\n";
                        reply += "【机器人】获取机器人信息\n";
                        reply += "【机器人】机器人退群\n";
                        reply += "【群】获取群列表\n";
                        reply += "【群】获取群信息\n";
                        reply += "【群】获取群等级排行榜\n";
                        reply += "【群】获取群禁言名单\n";
                        reply += "【群】获取群封禁名单\n";
                        reply += "【频道】获取频道列表\n";
                        reply += "【频道】取频道信息\n";
                        reply += "【文字频道】发送文字消息\n";
                        reply += "【文字频道】发送图片消息\n";
                        reply += "【文字频道】发送视频消息\n";
                        reply += "【文字频道】编辑消息\n";
                        reply += "【文字频道】撤回消息\n";
                        reply += "【文字频道】添加表情反应\n";
                        reply += "【文字频道】取消表情反应\n";
                        reply += "【身份组】获取身份组列表\n";
                        reply += "【身份组】赋予成员身份组 ID\n";
                        reply += "【身份组】取消成员身份组 ID\n";
                        reply += "【成员】获取成员列表\n";
                        reply += "【成员】获取成员信息\n";
                        reply += "【成员】获取成员身份组列表\n";
                        reply += "【成员】获取成员邀请信息\n";
                        reply += "【成员】编辑成员群昵称\n";
                        reply += "【成员】禁言成员\n";
                        reply += "【成员】取消成员禁言\n";
                        reply += "【成员】永久封禁成员\n";
                        reply += "【成员】取消成员永久封禁\n";
                        reply += "【数字藏品】获取成员数字藏品判断\n";
                        reply += "【私信】发送文字私信\n";
                        reply += "【私信】发送图片私信\n";
                        reply += "【私信】发送视频私信\n";
                        reply += "【资源】上传资源图片\n";
                        reply += "【事件】获取WebSocket连接\n";
                    }
                    
                    #region 机器人

                    else if (content.StartsWith("获取机器人信息"))
                    {
                        var output = _openApiService.GetBotInfo(new GetBotInfoInput(), true);

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
                    else if (content.StartsWith("机器人退群"))
                    {
                        var output = _openApiService.SetBotIslandLeave(new SetBotIslandLeaveInput
                        {
                            IslandId = eventBody.IslandId
                        }, true);

                        if (output)
                        {
                            reply += "机器人退群成功！";
                        }
                        else
                        {
                            reply += "调用接口失败！";
                        }
                    }

                    #endregion

                    #region 群

                    else if (content.StartsWith("获取群列表"))
                    {
                        var outputList = _openApiService.GetIslandList(new GetIslandListInput(), true);

                        if (outputList != null)
                        {
                            if (outputList.Count > 0)
                            {
                                foreach (var output in outputList)
                                {
                                    reply += $"群号：{output.IslandId}\n";
                                    reply += $"群名称：{output.IslandName}\n";
                                    reply += $"群总人数：{output.MemberCount}\n";
                                    reply += $"群在线人数：{output.OnlineMemberCount}\n";
                                    reply += $"群头像：{output.CoverUrl}\n";
                                    reply += $"系统消息频道ID：{output.SystemChannelId}\n";
                                    reply += $"默认访问频道ID：{output.DefaultChannelId}\n";
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
                    else if (content.StartsWith("获取群信息"))
                    {
                        var output = _openApiService.GetIslandInfo(new GetIslandInfoInput
                        {
                            IslandId = eventBody.IslandId
                        }, true);

                        if (output != null)
                        {
                            reply += $"群号：{output.IslandId}\n";
                            reply += $"群名称：{output.IslandName}\n";
                            reply += $"群头像：{output.CoverUrl}\n";
                            reply += $"群总人数：{output.MemberCount}\n";
                            reply += $"群在线人数：{output.OnlineMemberCount}\n";
                            reply += $"群描述：{output.Description}\n";
                            reply += $"系统消息频道ID：{output.SystemChannelId}\n";
                            reply += $"默认访问频道ID：{output.DefaultChannelId}\n";
                        }
                        else
                        {
                            reply += "调用接口失败！";
                        }
                    }
                    else if (content.StartsWith("获取群等级排行榜"))
                    {
                        var outputList = _openApiService.GetIslandLevelRankList(new GetIslandLevelRankListInput
                        {
                            IslandId = eventBody.IslandId
                        }, true);

                        if (outputList != null)
                        {
                            if (outputList.Count > 0)
                            {
                                foreach (var output in outputList)
                                {
                                    reply += $"DoDo号：{output.DodoId}\n";
                                    reply += $"群昵称：{output.NickName}\n";
                                    reply += $"等级：{output.Level}\n";
                                    reply += $"排名：{output.Rank}\n";
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
                    else if (content.StartsWith("获取群禁言名单"))
                    {
                        var outputList = _openApiService.GetIslandMuteList(new GetIslandMuteListInput
                        {
                            IslandId = eventBody.IslandId,
                            PageSize = 3,
                            MaxId = 0
                        }, true);

                        if (outputList != null)
                        {
                            if (outputList.List.Count > 0)
                            {
                                foreach (var output in outputList.List)
                                {
                                    reply += $"DoDo号：{output.DodoId}\n";
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
                    else if (content.StartsWith("获取群封禁名单"))
                    {
                        var outputList = _openApiService.GetIslandBanList(new GetIslandBanListInput
                        {
                            IslandId = eventBody.IslandId,
                            PageSize = 3,
                            MaxId = 0
                        }, true);

                        if (outputList != null)
                        {
                            if (outputList.List.Count > 0)
                            {
                                foreach (var output in outputList.List)
                                {
                                    reply += $"DoDo号：{output.DodoId}\n";
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

                    #endregion

                    #region 频道

                    else if (content.StartsWith("获取频道列表"))
                    {
                        var outputList = _openApiService.GetChannelList(new GetChannelListInput
                        {
                            IslandId = eventBody.IslandId
                        }, true);

                        if (outputList != null)
                        {
                            if (outputList.Count > 0)
                            {
                                foreach (var output in outputList)
                                {
                                    reply += $"频道ID：{output.ChannelId}\n";
                                    reply += $"频道名称：{output.ChannelName}\n";
                                    reply += $"频道类型：{output.ChannelType}\n";
                                    reply += $"默认频道标识：{output.DefaultFlag}\n";
                                    reply += $"分组ID：{output.GroupId}\n";
                                    reply += $"分组名称：{output.GroupName}\n";
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
                    else if (content.StartsWith("取频道信息"))
                    {
                        var output = _openApiService.GetChannelInfo(new GetChannelInfoInput
                        {
                            ChannelId = eventBody.ChannelId
                        }, true);

                        if (output != null)
                        {
                            reply += $"频道ID：{output.ChannelId}\n";
                            reply += $"频道名称：{output.ChannelName}\n";
                            reply += $"频道类型：{output.ChannelType}\n";
                            reply += $"默认频道标识：{output.DefaultFlag}\n";
                            reply += $"分组ID：{output.GroupId}\n";
                            reply += $"分组名称：{output.GroupName}\n";
                            reply += "\n";
                        }
                        else
                        {
                            reply += "调用接口失败！";
                        }
                    }

                    #endregion

                    #region 文字频道

                    else if (content.StartsWith("发送文字消息"))
                    {
                        var output = _openApiService.SetChannelMessageSend(new SetChannelMessageSendInput<MessageBodyText>
                        {
                            ChannelId = eventBody.ChannelId,
                            MessageBody = new MessageBodyText
                            {
                                Content = "测试文字消息"
                            }
                        }, true);

                        if (output != null)
                        {
                            reply += $"消息ID：{output.MessageId}\n";
                        }
                        else
                        {
                            reply += "调用接口失败！";
                        }
                    }
                    else if (content.StartsWith("发送图片消息"))
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
                        }, true);

                        if (output != null)
                        {
                            reply += $"消息ID：{output.MessageId}\n";
                        }
                        else
                        {
                            reply += "调用接口失败！";
                        }
                    }
                    else if (content.StartsWith("发送视频消息"))
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
                        }, true);

                        if (output != null)
                        {
                            reply += $"消息ID：{output.MessageId}\n";
                        }
                        else
                        {
                            reply += "调用接口失败！";
                        }
                    }
                    else if (content.StartsWith("编辑消息"))
                    {
                        var outputMessage = _openApiService.SetChannelMessageSend(new SetChannelMessageSendInput<MessageBodyText>
                        {
                            ChannelId = eventBody.ChannelId,
                            MessageBody = new MessageBodyText
                            {
                                Content = "测试文字消息"
                            }
                        }, true);

                        var output = _openApiService.SetChannelMessageEdit(new SetChannelMessageEditInput<MessageBodyText>
                        {
                            MessageId = outputMessage.MessageId,
                            MessageBody = new MessageBodyText
                            {
                                Content = "修改后的文字"
                            }
                        }, true);

                        if (output)
                        {
                            reply += "编辑消息成功！";
                        }
                        else
                        {
                            reply += "调用接口失败！";
                        }
                    }
                    else if (content.StartsWith("撤回消息"))
                    {
                        Thread.Sleep(3000);
                        var output = _openApiService.SetChannelMessageWithdraw(new SetChannelMessageWithdrawInput
                        {
                            MessageId = eventBody.MessageId,
                            Reason = "撤回测试"
                        }, true);

                        if (output)
                        {
                            reply += "撤回消息成功！";
                        }
                        else
                        {
                            reply += "调用接口失败！";
                        }

                    }
                    else if (content.StartsWith("添加表情反应"))
                    {

                        var output = _openApiService.SetChannelMessageReactionAdd(new SetChannelMessageReactionAddInput
                        {
                            MessageId = eventBody.MessageId,
                            ReactionEmoji = new MessageModelEmoji
                            {
                                Type = 1,
                                Id = "128520"
                            }
                        }, true);

                        if (output)
                        {
                            reply += "添加表情反应成功！";
                        }
                        else
                        {
                            reply += "调用接口失败！";
                        }

                    }
                    else if (content.StartsWith("取消表情反应"))
                    {

                        var output = _openApiService.SetChannelMessageReactionRemove(new SetChannelMessageReactionRemoveInput
                        {
                            MessageId = eventBody.MessageId,
                            ReactionEmoji = new MessageModelEmoji
                            {
                                Type = 1,
                                Id = "128520"
                            }
                        }, true);

                        if (output)
                        {
                            reply += "取消表情反应成功！";
                        }
                        else
                        {
                            reply += "调用接口失败！";
                        }

                    }

                    #endregion

                    #region 身份组

                    else if (content.StartsWith("获取身份组列表"))
                    {
                        var outputList = _openApiService.GetRoleList(new GetRoleListInput
                        {
                            IslandId = eventBody.IslandId
                        }, true);

                        if (outputList != null)
                        {
                            if (outputList.Count > 0)
                            {
                                foreach (var output in outputList)
                                {
                                    reply += $"身份组ID：{output.RoleId}\n";
                                    reply += $"身份组名称：{output.RoleName}\n";
                                    reply += $"身份组颜色：{output.RoleColor}\n";
                                    reply += $"位置：{output.Position}\n";
                                    reply += $"权限值：{output.Permission}\n";
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
                    else if (content.StartsWith("赋予成员身份组"))
                    {
                        var regex = Regex.Match(content, @"(\d+?)$");

                        var output = _openApiService.SetRoleMemberAdd(new SetRoleMemberAddInput
                        {
                            IslandId = eventBody.IslandId,
                            DodoId = eventBody.DodoId,
                            RoleId = regex.Value
                        }, true);

                        if (output)
                        {
                            reply += "赋予成员身份组成功！";
                        }
                        else
                        {
                            reply += "调用接口失败！";
                        }

                    }
                    else if (content.StartsWith("取消成员身份组"))
                    {
                        var regex = Regex.Match(content, @"(\d+?)$");
                        var output = _openApiService.SetRoleMemberRemove(new SetRoleMemberRemoveInput
                        {
                            IslandId = eventBody.IslandId,
                            DodoId = eventBody.DodoId,
                            RoleId = regex.Value
                        }, true);

                        if (output)
                        {
                            reply += "取消成员身份组成功！";
                        }
                        else
                        {
                            reply += "调用接口失败！";
                        }

                    }

                    #endregion

                    #region 成员

                    else if (content.StartsWith("获取成员列表"))
                    {
                        var outputList = _openApiService.GetMemberList(new GetMemberListInput
                        {
                            IslandId = eventBody.IslandId,
                            PageSize = 3,
                            MaxId = 0
                        }, true);

                        if (outputList != null)
                        {
                            if (outputList.List.Count > 0)
                            {
                                foreach (var output in outputList.List)
                                {
                                    reply += $"DoDo号：{output.DodoId}\n";
                                    reply += $"群昵称：{output.NickName}\n";
                                    reply += $"DoDo昵称：{output.PersonalNickName}\n";
                                    reply += $"头像：{output.AvatarUrl}\n";
                                    reply += $"加群时间：{output.JoinTime}\n";
                                    reply += $"性别：{output.Sex}\n";
                                    reply += $"等级：{output.Level}\n";
                                    reply += $"是否机器人：{output.IsBot}\n";
                                    reply += $"在线设备：{output.OnlineDevice}\n";
                                    reply += $"在线状态：{output.OnlineStatus}\n";
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
                    else if (content.StartsWith("获取成员信息"))
                    {
                        var output = _openApiService.GetMemberInfo(new GetMemberInfoInput
                        {
                            IslandId = eventBody.IslandId,
                            DodoId = eventBody.DodoId
                        }, true);

                        if (output != null)
                        {
                            reply += $"群号：{output.IslandId}\n";
                            reply += $"DoDo号：{output.DodoId}\n";
                            reply += $"群昵称：{output.NickName}\n";
                            reply += $"DoDo昵称：{output.PersonalNickName}\n";
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
                    else if (content.StartsWith("获取成员身份组列表"))
                    {
                        var outputList = _openApiService.GetMemberRoleList(new GetMemberRoleListInput
                        {
                            IslandId = eventBody.IslandId,
                            DodoId = eventBody.DodoId
                        }, true);

                        if (outputList != null)
                        {
                            if (outputList.Count > 0)
                            {
                                foreach (var output in outputList)
                                {
                                    reply += $"身份组ID：{output.RoleId}\n";
                                    reply += $"身份组名称：{output.RoleName}\n";
                                    reply += $"身份组颜色：{output.RoleColor}\n";
                                    reply += $"位置：{output.Position}\n";
                                    reply += $"权限值：{output.Permission}\n";
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
                    else if (content.StartsWith("获取成员邀请信息"))
                    {
                        var output = _openApiService.GetMemberInvitationInfo(new GetMemberInvitationInfoInput
                        {
                            IslandId = eventBody.IslandId,
                            DodoId = eventBody.DodoId
                        }, true);

                        if (output != null)
                        {
                            reply += $"DoDo号：{output.DodoId}\n";
                            reply += $"群昵称：{output.NickName}\n";
                            reply += $"邀请人数：{output.InvitationCount}\n";
                        }
                        else
                        {
                            reply += "调用接口失败！";
                        }

                    }
                    else if (content.StartsWith("编辑成员群昵称"))
                    {
                        var output = _openApiService.SetMemberNickNameEdit(new SetMemberNickNameEditInput
                        {
                            IslandId = eventBody.IslandId,
                            DodoId = eventBody.DodoId,
                            NickName = "群昵称编辑测试"
                        }, true);

                        if (output)
                        {
                            reply += "编辑成员群昵称成功！";
                        }
                        else
                        {
                            reply += "调用接口失败！";
                        }
                    }
                    else if (content.StartsWith("禁言成员"))
                    {
                        var output = _openApiService.SetMemberMuteAdd(new SetMemberMuteAddInput
                        {
                            IslandId = eventBody.IslandId,
                            DodoId = eventBody.DodoId,
                            Duration = 30,
                            Reason = "禁言测试"
                        }, true);

                        if (output)
                        {
                            reply += "禁言成员成功！";
                        }
                        else
                        {
                            reply += "调用接口失败！";
                        }
                    }
                    else if (content.StartsWith("取消成员禁言"))
                    {
                        var output = _openApiService.SetMemberMuteRemove(new SetMemberMuteRemoveInput
                        {
                            IslandId = eventBody.IslandId,
                            DodoId = eventBody.DodoId
                        }, true);

                        if (output)
                        {
                            reply += "取消成员禁言成功！";
                        }
                        else
                        {
                            reply += "调用接口失败！";
                        }
                    }
                    else if (content.StartsWith("永久封禁成员"))
                    {
                        var output = _openApiService.SetMemberBanAdd(new SetMemberBanAddInput
                        {
                            IslandId = eventBody.IslandId,
                            DodoId = eventBody.DodoId,
                            NoticeChannelId = eventBody.ChannelId,
                            Reason = "封禁测试"
                        }, true);

                        if (output)
                        {
                            reply += "永久封禁成员成功！";
                        }
                        else
                        {
                            reply += "调用接口失败！";
                        }
                    }
                    else if (content.StartsWith("取消成员永久封禁"))
                    {
                        var output = _openApiService.SetMemberBanRemove(new SetMemberBanRemoveInput
                        {
                            IslandId = eventBody.IslandId,
                            DodoId = eventBody.DodoId
                        }, true);

                        if (output)
                        {
                            reply += "取消成员永久封禁成功！";
                        }
                        else
                        {
                            reply += "调用接口失败！";
                        }
                    }

                    #endregion

                    #region 数字藏品

                    else if (content.StartsWith("获取成员数字藏品判断"))
                    {
                        var output = _openApiService.GetMemberNftStatus(new GetMemberNftStatusInput
                        {
                            IslandId = eventBody.IslandId,
                            DodoId = eventBody.DodoId,
                            Platform = "upower",
                            Issuer = "哔哩哔哩",
                            Series = "dodo测试1"
                        }, true);

                        if (output != null)
                        {
                            reply += $"是否已绑定该数藏平台：{output.IsBandPlatform}\n";
                            reply += $"是否拥有该发行方的NFT：{output.IsHaveIssuer}\n";
                            reply += $"是否拥有该系列的NFT：{output.IsHaveSeries}\n";
                        }
                        else
                        {
                            reply += "调用接口失败！";
                        }

                    }

                    #endregion

                    #region 私信

                    else if (content.StartsWith("发送文字私信"))
                    {
                        var output = _openApiService.SetPersonalMessageSend(new SetPersonalMessageSendInput<MessageBodyText>
                        {
                            DodoId = eventBody.DodoId,
                            MessageBody = new MessageBodyText
                            {
                                Content = "测试文字消息"
                            }
                        }, true);

                        if (output != null)
                        {
                            reply += $"消息ID：{output.MessageId}\n";
                        }
                        else
                        {
                            reply += "调用接口失败！";
                        }
                    }
                    else if (content.StartsWith("发送图片私信"))
                    {
                        var output = _openApiService.SetPersonalMessageSend(new SetPersonalMessageSendInput<MessageBodyPicture>
                        {
                            DodoId = eventBody.DodoId,
                            MessageBody = new MessageBodyPicture
                            {
                                Url = "https://img.imdodo.com/dodo/8c77d48865bf547a69fb3bba6228760c.png",
                                Width = 500,
                                Height = 500,
                                IsOriginal = 1
                            }
                        }, true);

                        if (output != null)
                        {
                            reply += $"消息ID：{output.MessageId}\n";
                        }
                        else
                        {
                            reply += "调用接口失败！";
                        }
                    }
                    else if (content.StartsWith("发送视频私信"))
                    {
                        var output = _openApiService.SetPersonalMessageSend(new SetPersonalMessageSendInput<MessageBodyVideo>
                        {
                            DodoId = eventBody.DodoId,
                            MessageBody = new MessageBodyVideo
                            {
                                Url = "https://video.imdodo.com/dodo/ff85c752daf7d67884cb9ad3921a5d01.mp4",
                                CoverUrl = "https://img.imdodo.com/dodo/8c77d48865bf547a69fb3bba6228760c.png",
                                Duration = 0,
                                Size = 0
                            }
                        }, true);

                        if (output != null)
                        {
                            reply += $"消息ID：{output.MessageId}\n";
                        }
                        else
                        {
                            reply += "调用接口失败！";
                        }
                    }

                    #endregion

                    #region 资源

                    else if (content.StartsWith("上传资源图片"))
                    {
                        var output = _openApiService.SetResourcePictureUpload(new SetResourceUploadInput
                        {
                            FilePath = "https://img.imdodo.com/dodo/8c77d48865bf547a69fb3bba6228760c.png"
                        }, true);

                        if (output != null)
                        {
                            reply += $"链接：{output.Url}\n";
                            reply += $"高度：{output.Height}\n";
                            reply += $"宽度：{output.Width}\n";
                        }
                        else
                        {
                            reply += "调用接口失败！";
                        }
                    }

                    #endregion

                    #region 事件

                    else if (content.StartsWith("获取WebSocket连接"))
                    {
                        var output = _openApiService.GetWebSocketConnection(new GetWebSocketConnectionInput(), true);

                        if (output != null)
                        {
                            reply += $"节点：{output.Endpoint}\n";
                        }
                        else
                        {
                            reply += "调用接口失败！";
                        }
                    } 

                    #endregion

                }
                catch (Exception e)
                {

                    reply ="触发异常：" + e.Message;
                }
            }
            else if (eventBody.MessageBody is MessageBodyPicture messageBodyPicture)
            {
                var messageBody = messageBodyPicture;

                reply += "触发消息事件-图片消息\n";
                reply += $"图片链接：{messageBody.Url}\n";
                reply += $"图片宽度：{messageBody.Width}\n";
                reply += $"图片高度：{messageBody.Height}\n";
                reply += $"是否原图：{messageBody.IsOriginal}\n";
            }
            else if (eventBody.MessageBody is MessageBodyVideo messageBodyVideo)
            {
                var messageBody = messageBodyVideo;

                reply += "触发消息事件-视频消息\n";
                reply += $"视频链接：{messageBody.Url}\n";
                reply += $"封面链接：{messageBody.CoverUrl}\n";
                reply += $"视频时长：{messageBody.Duration}\n";
                reply += $"视频大小：{messageBody.Size}\n";
            }
            else if (eventBody.MessageBody is MessageBodyFile messageBodyFile)
            {
                var messageBody = messageBodyFile;

                reply += "触发消息事件-文件消息\n";
                reply += $"文件链接：{messageBody.Url}\n";
                reply += $"文件名称：{messageBody.Name}\n";
                reply += $"文件大小：{messageBody.Size}\n";
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

        public override void MessageReactionEvent(EventSubjectOutput<EventSubjectDataBusiness<EventBodyMessageReaction>> input)
        {
            var eventBody = input.Data.EventBody;

            var reply = "";

            reply += "触发消息表情反应事件\n";
            reply += $"来源频道ID：{eventBody.ChannelId}\n";
            reply += $"来源DoDo号：{eventBody.DodoId}\n";
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

        public override void MemberJoinEvent(EventSubjectOutput<EventSubjectDataBusiness<EventBodyMemberJoin>> input)
        {
            var eventBody = input.Data.EventBody;

            var reply = "";

            reply += "触发成员加入事件\n";
            reply += $"来源DoDo号：{eventBody.DodoId}\n";
            reply += $"变动时间：{eventBody.ModifyTime}\n";

            var output = _openApiService.GetIslandInfo(new GetIslandInfoInput
            {
                IslandId = eventBody.IslandId
            });

            if (output == null)
                return;

            _openApiService.SetChannelMessageSend(new SetChannelMessageSendInput<MessageBodyText>
            {
                ChannelId = output.SystemChannelId,
                MessageBody = new MessageBodyText
                {
                    Content = reply
                }
            });
        }

        public override void MemberLeaveEvent(EventSubjectOutput<EventSubjectDataBusiness<EventBodyMemberLeave>> input)
        {
            var eventBody = input.Data.EventBody;

            var reply = "";

            reply += "触发成员退出事件\n";
            reply += $"来源DoDo号：{eventBody.DodoId}\n";
            reply += $"退出类型：{eventBody.LeaveType}\n";
            reply += $"操作者DoDo号：{eventBody.OperateDoDoId}\n";
            reply += $"变动时间：{eventBody.ModifyTime}\n";

            var output = _openApiService.GetIslandInfo(new GetIslandInfoInput
            {
                IslandId = eventBody.IslandId
            });

            if (output == null)
                return;

            _openApiService.SetChannelMessageSend(new SetChannelMessageSendInput<MessageBodyText>
            {
                ChannelId = output.SystemChannelId,
                MessageBody = new MessageBodyText
                {
                    Content = reply
                }
            });
        }
    }
}
