using System;
using System.Collections.Generic;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Text.Unicode;
using DoDo.Open.Sdk.Models;
using DoDo.Open.Sdk.Models.Bots;
using DoDo.Open.Sdk.Models.ChannelArticles;
using DoDo.Open.Sdk.Models.ChannelMessages;
using DoDo.Open.Sdk.Models.Channels;
using DoDo.Open.Sdk.Models.ChannelVoices;
using DoDo.Open.Sdk.Models.Events;
using DoDo.Open.Sdk.Models.Gifts;
using DoDo.Open.Sdk.Models.Islands;
using DoDo.Open.Sdk.Models.Members;
using DoDo.Open.Sdk.Models.Messages;
using DoDo.Open.Sdk.Models.Permissions;
using DoDo.Open.Sdk.Models.Personals;
using DoDo.Open.Sdk.Models.Resources;
using DoDo.Open.Sdk.Models.Roles;
using DoDo.Open.Sdk.Models.WebSockets;
using DoDo.Open.Sdk.Utils;

namespace DoDo.Open.Sdk.Services
{
    /// <summary>
    /// 示例事件处理服务
    /// </summary>
    public class DemoEventProcessService : EventProcessService
    {
        private readonly OpenApiService _openApiService;
        private readonly OpenApiOptions _openApiOptions;

        public DemoEventProcessService(OpenApiService openApiService)
        {
            _openApiService = openApiService;
            _openApiOptions = openApiService.GetBotOptions();
        }

        public override void Connected(string message)
        {
            _openApiOptions.Log?.Invoke($"Connected: {message}");
        }

        public override void Disconnected(string message)
        {
            _openApiOptions.Log?.Invoke($"Disconnected: {message}");
        }

        public override void Reconnected(string message)
        {
            _openApiOptions.Log?.Invoke($"Reconnected: {message}");
        }

        public override void Exception(string message)
        {
            _openApiOptions.Log?.Invoke($"Exception: {message}");
        }

        public override void Received(string message)
        {
            _openApiOptions.Log?.Invoke($"Received: {message}");
        }

        #region 私信

        public override async void PersonalMessageEvent<T>(EventSubjectOutput<EventSubjectDataBusiness<EventBodyPersonalMessage<T>>> input)
        {
            try
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
                    await _openApiService.SetPersonalMessageSendAsync(new SetPersonalMessageSendInput<MessageBodyText>
                    {
                        DodoSourceId = eventBody.DodoSourceId,
                        MessageBody = new MessageBodyText
                        {
                            Content = reply
                        }
                    });
                }
            }
            catch (Exception e)
            {
                Exception(e.Message);
            }
        }

        #endregion

        #region 文字频道

        public override async void ChannelMessageEvent<T>(EventSubjectOutput<EventSubjectDataBusiness<EventBodyChannelMessage<T>>> input)
        {
            try
            {
                var eventBody = input.Data.EventBody;

                var reply = "";

                var jsonSerializerOptions = new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                if (eventBody.MessageBody is MessageBodyText messageBodyText)
                {
                    var messageBody = messageBodyText;

                    var content = messageBody.Content;

                    _openApiOptions.Log?.Invoke($"Command: {content}");

                    try
                    {
                        #region 菜单

                        if (content.StartsWith("菜单"))
                        {
                            reply += $"<@!{eventBody.DodoSourceId}>\n";
                            reply += "\n**菜单来咯！**\n\n";
                            reply += "**机器人**\n";
                            reply += "**群**\n";
                            reply += "**频道**\n";
                            reply += "**文字频道**\n";
                            reply += "**语音频道**\n";
                            reply += "**帖子频道**\n";
                            reply += "**身份组**\n";
                            reply += "**成员**\n";
                            reply += "**赠礼系统**\n";
                            reply += "**私信**\n";
                            reply += "**资源**\n";
                            reply += "**事件**\n";
                        }
                        else if (content.StartsWith("机器人"))
                        {
                            reply += $"<@!{eventBody.DodoSourceId}>\n";
                            reply += "\n**机器人**\n\n";
                            reply += "获取机器人配置\n";
                            reply += "获取机器人信息\n";
                            reply += "机器人退群\n";
                            reply += "获取机器人邀请列表\n";
                            reply += "添加成员到机器人邀请列表\n";
                            reply += "移除成员出机器人邀请列表\n";
                        }
                        else if (content.StartsWith("群"))
                        {
                            reply += $"<@!{eventBody.DodoSourceId}>\n";
                            reply += "\n**群**\n\n";
                            reply += "获取群列表\n";
                            reply += "获取群信息\n";
                            reply += "获取群等级排行榜\n";
                            reply += "获取群禁言名单\n";
                            reply += "获取群封禁名单\n";
                        }
                        else if (content.StartsWith("频道"))
                        {
                            reply += $"<@!{eventBody.DodoSourceId}>\n";

                            reply += "\n**频道**\n\n";
                            reply += "获取频道列表\n";
                            reply += "获取频道信息\n";
                            reply += "创建频道\n";
                            reply += "编辑频道 ID\n";
                            reply += "删除频道 ID\n";
                        }
                        else if (content.StartsWith("文字频道"))
                        {
                            reply += $"<@!{eventBody.DodoSourceId}>\n";
                            reply += "\n**文字频道**\n\n";
                            reply += "发送文字消息\n";
                            reply += "发送图片消息\n";
                            reply += "发送视频消息\n";
                            reply += "发送卡片消息\n";
                            reply += "发送文字频道私信\n";
                            reply += "发送图片频道私信\n";
                            reply += "发送视频频道私信\n";
                            reply += "发送卡片频道私信\n";
                            reply += "编辑文字消息 ID\n";
                            reply += "编辑卡片消息 ID\n";
                            reply += "撤回消息 ID\n";
                            reply += "置顶消息 ID\n";
                            reply += "获取消息反应列表 ID\n";
                            reply += "获取消息反应内成员列表 ID ID\n";
                            reply += "添加表情反应 ID\n";
                            reply += "取消表情反应 ID\n";
                        }
                        else if (content.StartsWith("语音频道"))
                        {
                            reply += $"<@!{eventBody.DodoSourceId}>\n";
                            reply += "\n**语音频道**\n\n";
                            reply += "获取成员语音频道状态\n";
                            reply += "移动语音频道成员 ID\n";
                            reply += "管理语音中的成员 ID\n";
                        }
                        else if (content.StartsWith("帖子频道"))
                        {
                            reply += $"<@!{eventBody.DodoSourceId}>\n";
                            reply += "\n**帖子频道**\n\n";
                            reply += "发布帖子 ID\n";
                            reply += "删除帖子评论回复 ID ID\n";
                        }
                        else if (content.StartsWith("身份组"))
                        {
                            reply += $"<@!{eventBody.DodoSourceId}>\n";
                            reply += "\n**身份组**\n\n";
                            reply += "获取身份组列表\n";
                            reply += "创建身份组\n";
                            reply += "编辑身份组 ID\n";
                            reply += "删除身份组 ID\n";
                            reply += "赋予成员身份组 ID\n";
                            reply += "取消成员身份组 ID\n";
                        }
                        else if (content.StartsWith("成员"))
                        {
                            reply += $"<@!{eventBody.DodoSourceId}>\n";
                            reply += "\n**成员**\n\n";
                            reply += "获取成员列表\n";
                            reply += "获取成员信息\n";
                            reply += "获取成员身份组列表\n";
                            reply += "获取成员邀请信息\n";
                            reply += "编辑成员群昵称\n";
                            reply += "禁言成员\n";
                            reply += "取消成员禁言\n";
                            reply += "永久封禁成员\n";
                            reply += "取消成员永久封禁\n";
                        }
                        else if (content.StartsWith("赠礼系统"))
                        {
                            reply += $"<@!{eventBody.DodoSourceId}>\n";
                            reply += "\n**赠礼系统**\n\n";
                            reply += "获取群收入\n";
                            reply += "获取成员分成管理\n";
                            reply += "获取内容礼物列表 ID\n";
                            reply += "获取内容礼物内成员列表 ID ID\n";
                            reply += "获取内容礼物总值列表 ID\n";
                        }
                        else if (content.StartsWith("私信"))
                        {
                            reply += $"<@!{eventBody.DodoSourceId}>\n";
                            reply += "\n**私信**\n\n";
                            reply += "发送文字私信\n";
                            reply += "发送图片私信\n";
                            reply += "发送视频私信\n";
                        }
                        else if (content.StartsWith("资源"))
                        {
                            reply += $"<@!{eventBody.DodoSourceId}>\n";
                            reply += "\n**资源**\n\n";
                            reply += "上传资源图片\n";
                        }
                        else if (content.StartsWith("事件"))
                        {
                            reply += $"<@!{eventBody.DodoSourceId}>\n";
                            reply += "\n**事件**\n\n";
                            reply += "获取WebSocket连接\n";
                        }

                        #endregion

                        #region 机器人

                        else if (content.StartsWith("获取机器人配置"))
                        {
                            var output = _openApiService.GetBotOptions();

                            if (output != null)
                            {
                                reply += $"接口地址：{output.BaseApi}\n";
                                reply += $"机器人唯一标识：{output.ClientId}\n";
                            }
                            else
                            {
                                reply += "调用接口失败！";
                            }
                        }
                        else if (content.StartsWith("获取机器人信息"))
                        {
                            var output = await _openApiService.GetBotInfoAsync(new GetBotInfoInput(), true);

                            if (output != null)
                            {
                                reply += $"机器人唯一标识：{output.ClientId}\n";
                                reply += $"机器人DoDoID：{output.DodoSourceId}\n";
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
                            var output = await _openApiService.SetBotIslandLeaveAsync(new SetBotIslandLeaveInput
                            {
                                IslandSourceId = eventBody.IslandSourceId
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
                        else if (content.StartsWith("获取机器人邀请列表"))
                        {
                            var outputList = await _openApiService.GetBotInviteListAsync(new GetBotInviteListInput
                            {
                                PageSize = 3,
                                MaxId = 0
                            }, true);

                            if (outputList != null)
                            {
                                if (outputList.List.Count > 0)
                                {
                                    foreach (var output in outputList.List)
                                    {
                                        reply += $"DoDoID：{output.DodoSourceId}\n";
                                        reply += $"群昵称：{output.NickName}\n";
                                        reply += $"头像：{output.AvatarUrl}\n";
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
                        else if (content.StartsWith("添加成员到机器人邀请列表"))
                        {
                            var output = await _openApiService.SetBotInviteAddAsync(new SetBotInviteAddInput
                            {
                                DodoSourceId = eventBody.DodoSourceId
                            }, true);

                            if (output)
                            {
                                reply += "添加成员到机器人邀请列表成功！";
                            }
                            else
                            {
                                reply += "调用接口失败！";
                            }
                        }
                        else if (content.StartsWith("移除成员出机器人邀请列表"))
                        {
                            var output = await _openApiService.SetBotInviteRemoveAsync(new SetBotInviteRemoveInput
                            {
                                DodoSourceId = eventBody.DodoSourceId
                            }, true);

                            if (output)
                            {
                                reply += "移除成员出机器人邀请列表成功！";
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
                            var outputList = await _openApiService.GetIslandListAsync(new GetIslandListInput(), true);

                            if (outputList != null)
                            {
                                if (outputList.Count > 0)
                                {
                                    foreach (var output in outputList)
                                    {
                                        reply += $"群ID：{output.IslandSourceId}\n";
                                        reply += $"群号：{output.IslandId}\n";
                                        reply += $"群名称：{output.IslandName}\n";
                                        reply += $"群总人数：{output.MemberCount}\n";
                                        reply += $"群在线人数：{output.OnlineMemberCount}\n";
                                        reply += $"群头像：{output.CoverUrl}\n";
                                        reply += $"默认访问频道ID：{output.DefaultChannelId}\n";
                                        reply += $"系统消息频道ID：{output.SystemChannelId}\n";
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
                            var output = await _openApiService.GetIslandInfoAsync(new GetIslandInfoInput
                            {
                                IslandSourceId = eventBody.IslandSourceId
                            }, true);

                            if (output != null)
                            {
                                reply += $"群ID：{output.IslandSourceId}\n";
                                reply += $"群名称：{output.IslandName}\n";
                                reply += $"群头像：{output.CoverUrl}\n";
                                reply += $"群总人数：{output.MemberCount}\n";
                                reply += $"群在线人数：{output.OnlineMemberCount}\n";
                                reply += $"群描述：{output.Description}\n";
                                reply += $"默认访问频道ID：{output.DefaultChannelId}\n";
                                reply += $"系统消息频道ID：{output.SystemChannelId}\n";
                            }
                            else
                            {
                                reply += "调用接口失败！";
                            }
                        }
                        else if (content.StartsWith("获取群等级排行榜"))
                        {
                            var outputList = await _openApiService.GetIslandLevelRankListAsync(new GetIslandLevelRankListInput
                            {
                                IslandSourceId = eventBody.IslandSourceId
                            }, true);

                            if (outputList != null)
                            {
                                if (outputList.Count > 0)
                                {
                                    foreach (var output in outputList)
                                    {
                                        reply += $"DoDoID：{output.DodoSourceId}\n";
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
                            var outputList = await _openApiService.GetIslandMuteListAsync(new GetIslandMuteListInput
                            {
                                IslandSourceId = eventBody.IslandSourceId,
                                PageSize = 3,
                                MaxId = 0
                            }, true);

                            if (outputList != null)
                            {
                                if (outputList.List.Count > 0)
                                {
                                    foreach (var output in outputList.List)
                                    {
                                        reply += $"DoDoID：{output.DodoSourceId}\n";
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
                            var outputList = await _openApiService.GetIslandBanListAsync(new GetIslandBanListInput
                            {
                                IslandSourceId = eventBody.IslandSourceId,
                                PageSize = 3,
                                MaxId = 0
                            }, true);

                            if (outputList != null)
                            {
                                if (outputList.List.Count > 0)
                                {
                                    foreach (var output in outputList.List)
                                    {
                                        reply += $"DoDoID：{output.DodoSourceId}\n";
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
                            var outputList = await _openApiService.GetChannelListAsync(new GetChannelListInput
                            {
                                IslandSourceId = eventBody.IslandSourceId
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
                        else if (content.StartsWith("获取频道信息"))
                        {
                            var output = await _openApiService.GetChannelInfoAsync(new GetChannelInfoInput
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
                            }
                            else
                            {
                                reply += "调用接口失败！";
                            }
                        }
                        else if (content.StartsWith("创建频道"))
                        {
                            var output = await _openApiService.SetChannelAddAsync(new SetChannelAddInput
                            {
                                IslandSourceId = eventBody.IslandSourceId,
                                ChannelName = "创建频道测试",
                                ChannelType = 1
                            }, true);

                            if (output != null)
                            {
                                reply += $"频道ID：{output.ChannelId}\n";
                            }
                            else
                            {
                                reply += "调用接口失败！";
                            }
                        }
                        else if (content.StartsWith("编辑频道"))
                        {
                            var regex = Regex.Match(content, @"(\d+?)$");

                            var output = await _openApiService.SetChannelEditAsync(new SetChannelEditInput
                            {
                                IslandSourceId = eventBody.IslandSourceId,
                                ChannelId = regex.Value,
                                ChannelName = "编辑频道测试"
                            }, true);

                            if (output)
                            {
                                reply += "编辑频道成功\n";
                            }
                            else
                            {
                                reply += "调用接口失败！";
                            }
                        }
                        else if (content.StartsWith("删除频道"))
                        {
                            var regex = Regex.Match(content, @"(\d+?)$");

                            var output = await _openApiService.SetChannelRemoveAsync(new SetChannelRemoveInput
                            {
                                IslandSourceId = eventBody.IslandSourceId,
                                ChannelId = regex.Value
                            }, true);

                            if (output)
                            {
                                reply += "编辑频道成功\n";
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
                            var output = await _openApiService.SetChannelMessageSendAsync(new SetChannelMessageSendInput<MessageBodyText>
                            {
                                ChannelId = eventBody.ChannelId,
                                MessageBody = new MessageBodyText
                                {
                                    Content = "发送文字消息测试"
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
                            var output = await _openApiService.SetChannelMessageSendAsync(new SetChannelMessageSendInput<MessageBodyPicture>
                            {
                                ChannelId = eventBody.ChannelId,
                                MessageBody = new MessageBodyPicture
                                {
                                    Url = "https://img.imdodo.com/dodo/8c77d48865bf547a69fb3bba6228760c.png",
                                    Width = 600,
                                    Height = 600,
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
                            var output = await _openApiService.SetChannelMessageSendAsync(new SetChannelMessageSendInput<MessageBodyVideo>
                            {
                                ChannelId = eventBody.ChannelId,
                                MessageBody = new MessageBodyVideo
                                {
                                    Url = "https://video.imdodo.com/dodo/7f0a1979c818fa05cf7bdeae20aad24b.mp4",
                                    CoverUrl = "https://img.imdodo.com/dodo/2493bf9b000b8dc18e77d079ac517bb9.png",
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
                        else if (content.StartsWith("发送卡片消息"))
                        {
                            var output = await _openApiService.SetChannelMessageSendAsync(new SetChannelMessageSendInput<MessageBodyCard>
                            {
                                ChannelId = eventBody.ChannelId,
                                MessageBody = new MessageBodyCard
                                {
                                    Card = new MessageModelCard
                                    {
                                        Type = "card",
                                        Theme = "grey",
                                        Title = "卡片消息",
                                        Components = new List<object>
                                        {
                                           new
                                           {
                                               type = "header",
                                               text = new
                                               {
                                                   type = "dodo-md",
                                                   content = "发送卡片消息测试"
                                               }
                                           },
                                           new
                                           {
                                               type = "image-group",
                                               elements = new List<object>()
                                               {
                                                   new
                                                   {
                                                       type = "image",
                                                       src = "https://img.imdodo.com/upload/cdn/1C274FE42B6C98494A06D674559B2206_1658739484506.png"
                                                   },
                                                   new
                                                   {
                                                       type = "image",
                                                       src = "https://img.imdodo.com/upload/cdn/09151DF5C726C6E2F5915E5B117EF98E_1660189645615.png"
                                                   }
                                               }
                                           }
                                        }
                                    }
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
                        else if (content.StartsWith("发送文字频道私信"))
                        {
                            var output = await _openApiService.SetChannelMessageSendAsync(new SetChannelMessageSendInput<MessageBodyText>
                            {
                                ChannelId = eventBody.ChannelId,
                                MessageBody = new MessageBodyText
                                {
                                    Content = "发送文字频道私信测试"
                                },
                                DodoSourceId = eventBody.DodoSourceId
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
                        else if (content.StartsWith("发送图片频道私信"))
                        {
                            var output = await _openApiService.SetChannelMessageSendAsync(new SetChannelMessageSendInput<MessageBodyPicture>
                            {
                                ChannelId = eventBody.ChannelId,
                                MessageBody = new MessageBodyPicture
                                {
                                    Url = "https://img.imdodo.com/dodo/8c77d48865bf547a69fb3bba6228760c.png",
                                    Width = 500,
                                    Height = 500,
                                    IsOriginal = 1
                                },
                                DodoSourceId = eventBody.DodoSourceId
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
                        else if (content.StartsWith("发送视频频道私信"))
                        {
                            var output = await _openApiService.SetChannelMessageSendAsync(new SetChannelMessageSendInput<MessageBodyVideo>
                            {
                                ChannelId = eventBody.ChannelId,
                                MessageBody = new MessageBodyVideo
                                {
                                    Url = "https://video.imdodo.com/dodo/ff85c752daf7d67884cb9ad3921a5d01.mp4",
                                    CoverUrl = "https://img.imdodo.com/dodo/8c77d48865bf547a69fb3bba6228760c.png",
                                    Duration = 0,
                                    Size = 0
                                },
                                DodoSourceId = eventBody.DodoSourceId
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
                        else if (content.StartsWith("发送卡片频道私信"))
                        {
                            var output = await _openApiService.SetChannelMessageSendAsync(new SetChannelMessageSendInput<MessageBodyCard>
                            {
                                ChannelId = eventBody.ChannelId,
                                MessageBody = new MessageBodyCard
                                {
                                    Card = new MessageModelCard
                                    {
                                        Type = "card",
                                        Theme = "grey",
                                        Title = "卡片消息",
                                        Components = new List<object>
                                        {
                                            new
                                            {
                                                type = "header",
                                                text = new
                                                {
                                                    type = "dodo-md",
                                                    content = "发送卡片频道私信测试"
                                                }
                                            },
                                            new
                                            {
                                                type = "image-group",
                                                elements = new List<object>()
                                                {
                                                    new
                                                    {
                                                        type = "image",
                                                        src = "https://img.imdodo.com/upload/cdn/1C274FE42B6C98494A06D674559B2206_1658739484506.png"
                                                    },
                                                    new
                                                    {
                                                        type = "image",
                                                        src = "https://img.imdodo.com/upload/cdn/09151DF5C726C6E2F5915E5B117EF98E_1660189645615.png"
                                                    }
                                                }
                                            }
                                        }
                                    }
                                },
                                DodoSourceId = eventBody.DodoSourceId
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
                        else if (content.StartsWith("编辑文字消息"))
                        {
                            var regex = Regex.Match(content, @"(\d+?)$");

                            var output = await _openApiService.SetChannelMessageEditAsync(new SetChannelMessageEditInput<MessageBodyText>
                            {
                                MessageId = regex.Value,
                                MessageBody = new MessageBodyText
                                {
                                    Content = "编辑文字消息测试"
                                }
                            }, true);

                            if (output)
                            {
                                reply += "编辑文字消息成功！";
                            }
                            else
                            {
                                reply += "调用接口失败！";
                            }
                        }
                        else if (content.StartsWith("编辑卡片消息"))
                        {
                            var regex = Regex.Match(content, @"(\d+?)$");

                            var output = await _openApiService.SetChannelMessageEditAsync(new SetChannelMessageEditInput<MessageBodyCard>
                            {
                                MessageId = regex.Value,
                                MessageBody = new MessageBodyCard
                                {
                                    Card = new MessageModelCard
                                    {
                                        Type = "card",
                                        Theme = "grey",
                                        Title = "卡片消息",
                                        Components = new List<object>
                                    {
                                        new
                                        {
                                            type = "header",
                                            text = new
                                            {
                                                type = "dodo-md",
                                                content = "编辑卡片消息测试"
                                            }
                                        },
                                        new
                                        {
                                            type = "image-group",
                                            elements = new List<object>()
                                            {
                                                new
                                                {
                                                    type = "image",
                                                    src = "https://img.imdodo.com/upload/cdn/1C274FE42B6C98494A06D674559B2206_1658739484506.png"
                                                },
                                                new
                                                {
                                                    type = "image",
                                                    src = "https://img.imdodo.com/upload/cdn/09151DF5C726C6E2F5915E5B117EF98E_1660189645615.png"
                                                }
                                            }
                                        }
                                    }
                                    }
                                }
                            }, true);

                            if (output)
                            {
                                reply += "编辑卡片消息成功！";
                            }
                            else
                            {
                                reply += "调用接口失败！";
                            }
                        }
                        else if (content.StartsWith("撤回消息"))
                        {
                            var regex = Regex.Match(content, @"(\d+?)$");

                            var output = await _openApiService.SetChannelMessageWithdrawAsync(new SetChannelMessageWithdrawInput
                            {
                                MessageId = regex.Value,
                                Reason = "撤回消息测试"
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
                        else if (content.StartsWith("置顶消息"))
                        {
                            var regex = Regex.Match(content, @"(\d+?)$");

                            var output = await _openApiService.SetChannelMessageTopAsync(new SetChannelMessageTopInput
                            {
                                MessageId = regex.Value,
                                OperateType = 1
                            }, true);

                            if (output)
                            {
                                reply += "置顶消息成功！";
                            }
                            else
                            {
                                reply += "调用接口失败！";
                            }

                        }
                        else if (content.StartsWith("获取消息反应列表"))
                        {
                            var regex = Regex.Match(content, @"(\d+?)$");

                            var outputList = await _openApiService.GetChannelMessageReactionListAsync(new GetChannelMessageReactionListInput
                            {
                                MessageId = regex.Value
                            }, true);

                            if (outputList != null)
                            {
                                if (outputList.Count > 0)
                                {
                                    foreach (var output in outputList)
                                    {
                                        reply += $"反应表情类型：{output.Emoji.Type}\n";
                                        reply += $"反应表情ID：{output.Emoji.Id}\n";
                                        reply += $"反应数量：{output.Count}\n";
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
                        else if (content.StartsWith("获取消息反应内成员列表"))
                        {
                            var regex = Regex.Match(content, @"(\d+?) (\d+?)$");
                            var regexs = regex.Value.Split(' ');
                            var outputList = await _openApiService.GetChannelMessageReactionMemberListAsync(new GetChannelMessageReactionMemberListInput
                            {
                                MessageId = regexs[0],
                                Emoji = new MessageModelEmoji
                                {
                                    Type = 1,
                                    Id = regexs[1]
                                },
                                PageSize = 3,
                                MaxId = 0
                            }, true);

                            if (outputList != null)
                            {
                                if (outputList.List.Count > 0)
                                {
                                    foreach (var output in outputList.List)
                                    {
                                        reply += $"DoDoID：{output.DodoSourceId}\n";
                                        reply += $"群昵称：{output.NickName}\n";
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
                        else if (content.StartsWith("添加表情反应"))
                        {
                            var regex = Regex.Match(content, @"(\d+?)$");

                            var output = await _openApiService.SetChannelMessageReactionAddAsync(new SetChannelMessageReactionAddInput
                            {
                                MessageId = eventBody.MessageId,
                                Emoji = new MessageModelEmoji
                                {
                                    Type = 1,
                                    Id = regex.Value
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
                            var regex = Regex.Match(content, @"(\d+?)$");

                            var output = await _openApiService.SetChannelMessageReactionRemoveAsync(new SetChannelMessageReactionRemoveInput
                            {
                                MessageId = eventBody.MessageId,
                                Emoji = new MessageModelEmoji
                                {
                                    Type = 1,
                                    Id = regex.Value
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

                        #region 语音频道

                        else if (content.StartsWith("获取成员语音频道状态"))
                        {
                            var output = await _openApiService.GetChannelVoiceMemberStatusAsync(new GetChannelVoiceMemberStatusInput
                            {
                                IslandSourceId = eventBody.IslandSourceId,
                                DodoSourceId = eventBody.DodoSourceId
                            }, true);

                            if (output != null)
                            {
                                reply += $"所在语音频道ID：{output.ChannelId}\n";
                                reply += $"扬声器的状态：{output.SpkStatus}\n";
                                reply += $"麦的状态：{output.MicStatus}\n";
                                reply += $"麦序模式状态：{output.MicSortStatus}\n";
                            }
                            else
                            {
                                reply += "调用接口失败！";
                            }
                        }
                        else if (content.StartsWith("移动语音频道成员"))
                        {
                            var regex = Regex.Match(content, @"(\d+?)$");

                            var output = await _openApiService.SetChannelVoiceMemberMoveAsync(new SetChannelVoiceMemberMoveInput
                            {
                                IslandSourceId = eventBody.IslandSourceId,
                                DodoSourceId = eventBody.DodoSourceId,
                                ChannelId = regex.Value
                            }, true);

                            if (output)
                            {
                                reply += "移动语音频道成员成功！";
                            }
                            else
                            {
                                reply += "调用接口失败！";
                            }
                        }
                        else if (content.StartsWith("管理语音中的成员"))
                        {
                            var regex = Regex.Match(content, @"(\d+?)$");

                            var output = await _openApiService.SetChannelVoiceMemberEditAsync(new SetChannelVoiceMemberEditInput
                            {
                                ChannelId = regex.Value,
                                DodoSourceId = eventBody.DodoSourceId,
                                OperateType = 3
                            }, true);

                            if (output)
                            {
                                reply += "管理语音中的成员成功！";
                            }
                            else
                            {
                                reply += "调用接口失败！";
                            }
                        }

                        #endregion

                        #region 帖子频道

                        else if (content.StartsWith("发布帖子"))
                        {
                            var regex = Regex.Match(content, @"(\d+?)$");

                            var output = await _openApiService.SetChannelArticleAddAsync(new SetChannelArticleAddInput
                            {
                                ChannelId = regex.Value,
                                Title = "发布帖子测试",
                                Content = "发布帖子测试成功",
                                ImageUrl = "https://img.imdodo.com/dodo/8c77d48865bf547a69fb3bba6228760c.png"
                            }, true);

                            if (output != null)
                            {
                                reply += $"帖子ID：{output.ArticleId}\n";
                            }
                            else
                            {
                                reply += "调用接口失败！";
                            }
                        }
                        else if (content.StartsWith("删除帖子评论回复"))
                        {
                            var regex = Regex.Match(content, @"(\d+?) (\d+?)$");
                            var regexs = regex.Value.Split(' ');
                            var output = await _openApiService.SetChannelArticleRemoveAsync(new SetChannelArticleRemoveInput
                            {
                                ChannelId = regexs[0],
                                Type = 1,
                                Id = regexs[1]
                            }, true);

                            if (output)
                            {
                                reply += "删除帖子评论回复成功！";
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
                            var outputList = await _openApiService.GetRoleListAsync(new GetRoleListInput
                            {
                                IslandSourceId = eventBody.IslandSourceId
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
                                        reply += $"身份组排序位置：{output.Position}\n";
                                        reply += $"身份组权限值：{output.Permission}\n";
                                        reply += $"身份组成员数：{output.MemberCount}\n";
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
                        else if (content.StartsWith("创建身份组"))
                        {
                            var output = await _openApiService.SetRoleAddAsync(new SetRoleAddInput
                            {
                                IslandSourceId = eventBody.IslandSourceId,
                                RoleName = "创建身份组测试",
                                RoleColor = "#999999",
                                Position = 1,
                                Permission = PermissionUtil.CalculationPermission(Permission.Administrator)
                            }, true);

                            if (output != null)
                            {
                                reply += $"身份组ID：{output.RoleId}\n";
                            }
                            else
                            {
                                reply += "调用接口失败！";
                            }
                        }
                        else if (content.StartsWith("编辑身份组"))
                        {
                            var regex = Regex.Match(content, @"(\d+?)$");

                            var output = await _openApiService.SetRoleEditAsync(new SetRoleEditInput
                            {
                                IslandSourceId = eventBody.IslandSourceId,
                                RoleId = regex.Value,
                                RoleName = "编辑身份组测试",
                                RoleColor = "#999999",
                                Position = 1,
                                Permission = "8"
                            }, true);

                            if (output)
                            {
                                reply += "编辑身份组成功\n";
                            }
                            else
                            {
                                reply += "调用接口失败！";
                            }
                        }
                        else if (content.StartsWith("删除身份组"))
                        {
                            var regex = Regex.Match(content, @"(\d+?)$");

                            var output = await _openApiService.SetRoleRemoveAsync(new SetRoleRemoveInput
                            {
                                IslandSourceId = eventBody.IslandSourceId,
                                RoleId = regex.Value
                            }, true);

                            if (output)
                            {
                                reply += "删除身份组成功\n";
                            }
                            else
                            {
                                reply += "调用接口失败！";
                            }
                        }
                        else if (content.StartsWith("获取身份组成员列表"))
                        {
                            var regex = Regex.Match(content, @"(\d+?)$");

                            var outputList = await _openApiService.GetRoleMemberListAsync(new GetRoleMemberListInput
                            {
                                IslandSourceId = eventBody.IslandSourceId,
                                RoleId = regex.Value,
                                PageSize = 3,
                                MaxId = 0
                            }, true);

                            if (outputList != null)
                            {
                                if (outputList.List.Count > 0)
                                {
                                    foreach (var output in outputList.List)
                                    {
                                        reply += $"DoDoID：{output.DodoSourceId}\n";
                                        reply += $"群昵称：{output.NickName}\n";
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

                            var output = await _openApiService.SetRoleMemberAddAsync(new SetRoleMemberAddInput
                            {
                                IslandSourceId = eventBody.IslandSourceId,
                                DodoSourceId = eventBody.DodoSourceId,
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
                            var output = await _openApiService.SetRoleMemberRemoveAsync(new SetRoleMemberRemoveInput
                            {
                                IslandSourceId = eventBody.IslandSourceId,
                                DodoSourceId = eventBody.DodoSourceId,
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
                            var outputList = await _openApiService.GetMemberListAsync(new GetMemberListInput
                            {
                                IslandSourceId = eventBody.IslandSourceId,
                                PageSize = 3,
                                MaxId = 0
                            }, true);

                            if (outputList != null)
                            {
                                if (outputList.List.Count > 0)
                                {
                                    foreach (var output in outputList.List)
                                    {
                                        reply += $"DoDoID：{output.DodoSourceId}\n";
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
                            var output = await _openApiService.GetMemberInfoAsync(new GetMemberInfoInput
                            {
                                IslandSourceId = eventBody.IslandSourceId,
                                DodoSourceId = eventBody.DodoSourceId
                            }, true);

                            if (output != null)
                            {
                                reply += $"群ID：{output.IslandSourceId}\n";
                                reply += $"DoDoID：{output.DodoSourceId}\n";
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
                            var outputList = await _openApiService.GetMemberRoleListAsync(new GetMemberRoleListInput
                            {
                                IslandSourceId = eventBody.IslandSourceId,
                                DodoSourceId = eventBody.DodoSourceId
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
                            var output = await _openApiService.GetMemberInvitationInfoAsync(new GetMemberInvitationInfoInput
                            {
                                IslandSourceId = eventBody.IslandSourceId,
                                DodoSourceId = eventBody.DodoSourceId
                            }, true);

                            if (output != null)
                            {
                                reply += $"DoDoID：{output.DodoSourceId}\n";
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
                            var output = await _openApiService.SetMemberNickNameEditAsync(new SetMemberNickNameEditInput
                            {
                                IslandSourceId = eventBody.IslandSourceId,
                                DodoSourceId = eventBody.DodoSourceId,
                                NickName = "编辑成员群昵称测试"
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
                            var output = await _openApiService.SetMemberMuteAddAsync(new SetMemberMuteAddInput
                            {
                                IslandSourceId = eventBody.IslandSourceId,
                                DodoSourceId = eventBody.DodoSourceId,
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
                            var output = await _openApiService.SetMemberMuteRemoveAsync(new SetMemberMuteRemoveInput
                            {
                                IslandSourceId = eventBody.IslandSourceId,
                                DodoSourceId = eventBody.DodoSourceId
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
                            var output = await _openApiService.SetMemberBanAddAsync(new SetMemberBanAddInput
                            {
                                IslandSourceId = eventBody.IslandSourceId,
                                DodoSourceId = eventBody.DodoSourceId,
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
                            var output = await _openApiService.SetMemberBanRemoveAsync(new SetMemberBanRemoveInput
                            {
                                IslandSourceId = eventBody.IslandSourceId,
                                DodoSourceId = eventBody.DodoSourceId
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

                        #region 赠礼系统

                        else if (content.StartsWith("获取群收入"))
                        {
                            var output = await _openApiService.GetGiftAccountAsync(new GetGiftAccountInput
                            {
                                IslandSourceId = eventBody.IslandSourceId
                            }, true);

                            if (output != null)
                            {
                                reply += $"总收入（里程）：{output.TotalIncome}\n";
                                reply += $"待结算收入（里程）：{output.SettlableIncome}\n";
                                reply += $"可转账收入（里程）：{output.TransferableIncome}\n";
                            }
                            else
                            {
                                reply += "调用接口失败！";
                            }
                        }
                        else if (content.StartsWith("获取成员分成管理"))
                        {
                            var output = await _openApiService.GetGiftShareRatioInfoAsync(new GetGiftShareRatioInfoInput
                            {
                                IslandSourceId = eventBody.IslandSourceId
                            }, true);

                            if (output != null)
                            {
                                reply += "[ 默认抽成 ]\n";
                                reply += $"群抽成：{output.DefaultRatio.IslandRatio}\n";
                                reply += $"被打赏用户：{output.DefaultRatio.UserRatio}\n";
                                reply += $"平台抽成：{output.DefaultRatio.PlatformRatio}\n";
                                reply += "\n";
                                reply += "[ 身份组抽成列表 ]\n";

                                foreach (var item in output.RoleRatioList)
                                {
                                    reply += $"身份组ID：{item.RoleId}\n";
                                    reply += $"身份组名称：{item.RoleName}\n";
                                    reply += $"群抽成：{item.IslandRatio}\n";
                                    reply += $"被打赏用户：{item.UserRatio}\n";
                                    reply += $"平台抽成：{item.PlatformRatio}\n";
                                    reply += "\n";
                                }
                            }
                            else
                            {
                                reply += "调用接口失败！";
                            }
                        }
                        else if (content.StartsWith("获取内容礼物列表"))
                        {
                            var regex = Regex.Match(content, @"(\d+?)$");

                            var outputList = await _openApiService.GetGiftListAsync(new GetGiftListInput
                            {
                                TargetType = 1,
                                TargetId = regex.Value
                            }, true);

                            if (outputList != null)
                            {
                                if (outputList.Count > 0)
                                {
                                    foreach (var output in outputList)
                                    {
                                        reply += $"礼物ID：{output.GiftId}\n";
                                        reply += $"礼物数量：{output.GiftCount}\n";
                                        reply += $"礼物总价值（铃钱）：{output.GiftTotalAmount}\n";
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
                        else if (content.StartsWith("获取内容礼物内成员列表"))
                        {
                            var regex = Regex.Match(content, @"(\d+?) (\d+?)$");
                            var regexs = regex.Value.Split(' ');

                            var outputList = await _openApiService.GetGiftMemberListAsync(new GetGiftMemberListInput
                            {
                                TargetType = 1,
                                TargetId = regexs[0],
                                GiftId = regexs[1],
                                PageSize = 3,
                                MaxId = 0
                            }, true);

                            if (outputList != null)
                            {
                                if (outputList.List.Count > 0)
                                {
                                    foreach (var output in outputList.List)
                                    {
                                        reply += $"DoDoID：{output.DodoSourceId}\n";
                                        reply += $"群昵称：{output.NickName}\n";
                                        reply += $"礼物数量：{output.GiftCount}\n";
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
                        else if (content.StartsWith("获取内容礼物总值列表"))
                        {
                            var regex = Regex.Match(content, @"(\d+?)$");

                            var outputList = await _openApiService.GetGiftGrossValueListAsync(new GetGiftGrossValueListInput
                            {
                                TargetType = 1,
                                TargetId = regex.Value,
                                PageSize = 3,
                                MaxId = 0
                            }, true);

                            if (outputList != null)
                            {
                                if (outputList.List.Count > 0)
                                {
                                    foreach (var output in outputList.List)
                                    {
                                        reply += $"DoDoID：{output.DodoSourceId}\n";
                                        reply += $"群昵称：{output.NickName}\n";
                                        reply += $"赠礼总值（铃钱）：{output.GiftTotalAmount}\n";
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

                        #region 私信

                        else if (content.StartsWith("发送文字私信"))
                        {
                            var output = await _openApiService.SetPersonalMessageSendAsync(new SetPersonalMessageSendInput<MessageBodyText>
                            {
                                IslandSourceId = eventBody.IslandSourceId,
                                DodoSourceId = eventBody.DodoSourceId,
                                MessageBody = new MessageBodyText
                                {
                                    Content = "发送文字私信测试"
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
                            var output = await _openApiService.SetPersonalMessageSendAsync(new SetPersonalMessageSendInput<MessageBodyPicture>
                            {
                                IslandSourceId = eventBody.IslandSourceId,
                                DodoSourceId = eventBody.DodoSourceId,
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
                            var output = await _openApiService.SetPersonalMessageSendAsync(new SetPersonalMessageSendInput<MessageBodyVideo>
                            {
                                IslandSourceId = eventBody.IslandSourceId,
                                DodoSourceId = eventBody.DodoSourceId,
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
                            var output = await _openApiService.SetResourcePictureUploadAsync(new SetResourceUploadInput
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
                            var output = await _openApiService.GetWebSocketConnectionAsync(new GetWebSocketConnectionInput(), true);

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

                        reply = "触发异常：" + e.Message;
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
                else if (eventBody.MessageBody is MessageBodyShare messageBodyShare)
                {
                    var messageBody = messageBodyShare;

                    reply += "触发消息事件-分享消息\n";
                    reply += $"跳转链接：{messageBody.JumpUrl}\n";
                }
                else if (eventBody.MessageBody is MessageBodyFile messageBodyFile)
                {
                    var messageBody = messageBodyFile;

                    reply += "触发消息事件-文件消息\n";
                    reply += $"文件链接：{messageBody.Url}\n";
                    reply += $"文件名称：{messageBody.Name}\n";
                    reply += $"文件大小：{messageBody.Size}\n";
                }
                else if (eventBody.MessageBody is MessageBodyCard messageBodyCard)
                {
                    var messageBody = messageBodyCard;

                    reply += "触发消息事件-卡片消息\n";
                    reply += $"{JsonSerializer.Serialize(messageBody, jsonSerializerOptions)}\n";
                }

                if (reply != "")
                {
                    await _openApiService.SetChannelMessageSendAsync(new SetChannelMessageSendInput<MessageBodyText>
                    {
                        ChannelId = eventBody.ChannelId,
                        MessageBody = new MessageBodyText
                        {
                            Content = reply
                        }
                    });
                }
            }
            catch (Exception e)
            {
                Exception(e.Message);
            }
        }

        public override async void MessageReactionEvent(EventSubjectOutput<EventSubjectDataBusiness<EventBodyMessageReaction>> input)
        {
            try
            {
                var eventBody = input.Data.EventBody;

                var reply = "";

                reply += "触发消息表情反应事件\n";
                reply += $"来源频道ID：{eventBody.ChannelId}\n";
                reply += $"来源DoDoID：{eventBody.DodoSourceId}\n";
                reply += $"反应对象类型：{eventBody.ReactionTarget.Type}\n";
                reply += $"反应对象ID：{eventBody.ReactionTarget.Id}\n";
                reply += $"反应表情类型：{eventBody.ReactionEmoji.Type}\n";
                reply += $"反应表情ID：{eventBody.ReactionEmoji.Id}\n";
                reply += $"反应类型：{eventBody.ReactionType}\n";

                await _openApiService.SetChannelMessageSendAsync(new SetChannelMessageSendInput<MessageBodyText>
                {
                    ChannelId = eventBody.ChannelId,
                    MessageBody = new MessageBodyText
                    {
                        Content = reply
                    }
                });
            }
            catch (Exception e)
            {
                Exception(e.Message);
            }
        }

        public override async void CardMessageButtonClickEvent(EventSubjectOutput<EventSubjectDataBusiness<EventBodyCardMessageButtonClick>> input)
        {
            try
            {
                var eventBody = input.Data.EventBody;

                var reply = "";

                reply += "触发卡片消息按钮事件\n";
                reply += $"来源频道ID：{eventBody.ChannelId}\n";
                reply += $"来源消息ID：{eventBody.MessageId}\n";
                reply += $"来源DoDoID：{eventBody.DodoSourceId}\n";
                reply += $"交互自定义ID：{eventBody.InteractCustomId}\n";
                reply += $"Value：{eventBody.Value}\n";

                await _openApiService.SetChannelMessageSendAsync(new SetChannelMessageSendInput<MessageBodyText>
                {
                    ChannelId = eventBody.ChannelId,
                    MessageBody = new MessageBodyText
                    {
                        Content = reply
                    }
                });
            }
            catch (Exception e)
            {
                Exception(e.Message);
            }
        }

        public override async void CardMessageFormSubmitEvent(EventSubjectOutput<EventSubjectDataBusiness<EventBodyCardMessageFormSubmit>> input)
        {
            try
            {
                var eventBody = input.Data.EventBody;

                var reply = "";

                var jsonSerializerOptions = new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                reply += "触发卡片消息表单回传事件\n";
                reply += $"来源频道ID：{eventBody.ChannelId}\n";
                reply += $"来源消息ID：{eventBody.MessageId}\n";
                reply += $"来源DoDoID：{eventBody.DodoSourceId}\n";
                reply += $"交互自定义ID：{eventBody.InteractCustomId}\n";
                reply += $"表单数据：{JsonSerializer.Serialize(eventBody.FormData, jsonSerializerOptions)}\n";

                await _openApiService.SetChannelMessageSendAsync(new SetChannelMessageSendInput<MessageBodyText>
                {
                    ChannelId = eventBody.ChannelId,
                    MessageBody = new MessageBodyText
                    {
                        Content = reply
                    }
                });
            }
            catch (Exception e)
            {
                Exception(e.Message);
            }
        }

        public override async void CardMessageListSubmitEvent(EventSubjectOutput<EventSubjectDataBusiness<EventBodyCardMessageListSubmit>> input)
        {
            try
            {
                var eventBody = input.Data.EventBody;

                var reply = "";

                var jsonSerializerOptions = new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                reply += "触发卡片消息列表回传事件\n";
                reply += $"来源频道ID：{eventBody.ChannelId}\n";
                reply += $"来源消息ID：{eventBody.MessageId}\n";
                reply += $"来源DoDoID：{eventBody.DodoSourceId}\n";
                reply += $"交互自定义ID：{eventBody.InteractCustomId}\n";
                reply += $"列表数据：{JsonSerializer.Serialize(eventBody.ListData, jsonSerializerOptions)}\n";

                await _openApiService.SetChannelMessageSendAsync(new SetChannelMessageSendInput<MessageBodyText>
                {
                    ChannelId = eventBody.ChannelId,
                    MessageBody = new MessageBodyText
                    {
                        Content = reply
                    }
                });
            }
            catch (Exception e)
            {
                Exception(e.Message);
            }
        }

        #endregion

        #region 语音频道

        public override async void ChannelVoiceMemberJoinEvent(EventSubjectOutput<EventSubjectDataBusiness<EventBodyChannelVoiceMemberJoin>> input)
        {
            try
            {
                var eventBody = input.Data.EventBody;

                var reply = "";

                reply += "触发成员加入语音频道事件\n";
                reply += $"来源频道ID：{eventBody.ChannelId}\n";
                reply += $"来源DoDoID：{eventBody.DodoSourceId}\n";

                var output = await _openApiService.GetIslandInfoAsync(new GetIslandInfoInput
                {
                    IslandSourceId = eventBody.IslandSourceId
                });

                if (output == null)
                    return;

                await _openApiService.SetChannelMessageSendAsync(new SetChannelMessageSendInput<MessageBodyText>
                {
                    ChannelId = output.SystemChannelId,
                    MessageBody = new MessageBodyText
                    {
                        Content = reply
                    }
                });
            }
            catch (Exception e)
            {
                Exception(e.Message);
            }
        }

        public override async void ChannelVoiceMemberLeaveEvent(EventSubjectOutput<EventSubjectDataBusiness<EventBodyChannelVoiceMemberLeave>> input)
        {
            try
            {
                var eventBody = input.Data.EventBody;

                var reply = "";

                reply += "触发成员退出语音频道事件\n";
                reply += $"来源频道ID：{eventBody.ChannelId}\n";
                reply += $"来源DoDoID：{eventBody.DodoSourceId}\n";

                var output = await _openApiService.GetIslandInfoAsync(new GetIslandInfoInput
                {
                    IslandSourceId = eventBody.IslandSourceId
                });

                if (output == null)
                    return;

                await _openApiService.SetChannelMessageSendAsync(new SetChannelMessageSendInput<MessageBodyText>
                {
                    ChannelId = output.SystemChannelId,
                    MessageBody = new MessageBodyText
                    {
                        Content = reply
                    }
                });
            }
            catch (Exception e)
            {
                Exception(e.Message);
            }
        }

        #endregion

        #region 帖子频道

        public override async void ChannelArticleEvent(EventSubjectOutput<EventSubjectDataBusiness<EventBodyChannelArticle>> input)
        {
            try
            {
                var eventBody = input.Data.EventBody;

                var reply = "";

                var jsonSerializerOptions = new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                reply += "帖子发布事件\n";
                reply += $"来源频道ID：{eventBody.ChannelId}\n";
                reply += $"来源DoDoID：{eventBody.DodoSourceId}\n";
                reply += $"帖子ID：{eventBody.ArticleId}\n";
                reply += $"标题：{eventBody.Title}\n";
                reply += $"内容：{eventBody.Content}\n";
                reply += $"图片列表：{JsonSerializer.Serialize(eventBody.ImageList, jsonSerializerOptions)}\n";

                var output = await _openApiService.GetIslandInfoAsync(new GetIslandInfoInput
                {
                    IslandSourceId = eventBody.IslandSourceId
                });

                if (output == null)
                    return;

                await _openApiService.SetChannelMessageSendAsync(new SetChannelMessageSendInput<MessageBodyText>
                {
                    ChannelId = output.SystemChannelId,
                    MessageBody = new MessageBodyText
                    {
                        Content = reply
                    }
                });
            }
            catch (Exception e)
            {
                Exception(e.Message);
            }
        }

        public override async void ChannelArticleCommentEvent(EventSubjectOutput<EventSubjectDataBusiness<EventBodyChannelArticleComment>> input)
        {
            try
            {
                var eventBody = input.Data.EventBody;

                var reply = "";

                var jsonSerializerOptions = new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                reply += "帖子评论回复事件\n";
                reply += $"来源频道ID：{eventBody.ChannelId}\n";
                reply += $"来源DoDoID：{eventBody.DodoSourceId}\n";
                reply += $"帖子ID：{eventBody.ArticleId}\n";
                reply += $"评论ID：{eventBody.CommentId}\n";
                reply += $"回复ID：{eventBody.ReplyId}\n";
                reply += $"内容：{eventBody.Content}\n";
                reply += $"图片列表：{JsonSerializer.Serialize(eventBody.ImageList, jsonSerializerOptions)}\n";

                var output = await _openApiService.GetIslandInfoAsync(new GetIslandInfoInput
                {
                    IslandSourceId = eventBody.IslandSourceId
                });

                if (output == null)
                    return;

                await _openApiService.SetChannelMessageSendAsync(new SetChannelMessageSendInput<MessageBodyText>
                {
                    ChannelId = output.SystemChannelId,
                    MessageBody = new MessageBodyText
                    {
                        Content = reply
                    }
                });
            }
            catch (Exception e)
            {
                Exception(e.Message);
            }
        }

        #endregion

        #region 成员

        public override async void MemberJoinEvent(EventSubjectOutput<EventSubjectDataBusiness<EventBodyMemberJoin>> input)
        {
            try
            {
                var eventBody = input.Data.EventBody;

                var reply = "";

                reply += "触发成员加入事件\n";
                reply += $"来源DoDoID：{eventBody.DodoSourceId}\n";
                reply += $"变动时间：{eventBody.ModifyTime}\n";

                var output = await _openApiService.GetIslandInfoAsync(new GetIslandInfoInput
                {
                    IslandSourceId = eventBody.IslandSourceId
                });

                if (output == null)
                    return;

                await _openApiService.SetChannelMessageSendAsync(new SetChannelMessageSendInput<MessageBodyText>
                {
                    ChannelId = output.SystemChannelId,
                    MessageBody = new MessageBodyText
                    {
                        Content = reply
                    }
                });
            }
            catch (Exception e)
            {
                Exception(e.Message);
            }
        }

        public override async void MemberLeaveEvent(EventSubjectOutput<EventSubjectDataBusiness<EventBodyMemberLeave>> input)
        {
            try
            {
                var eventBody = input.Data.EventBody;

                var reply = "";

                reply += "触发成员退出事件\n";
                reply += $"来源DoDoID：{eventBody.DodoSourceId}\n";
                reply += $"退出类型：{eventBody.LeaveType}\n";
                reply += $"操作者DoDoID：{eventBody.OperateDodoSourceId}\n";
                reply += $"变动时间：{eventBody.ModifyTime}\n";

                var output = await _openApiService.GetIslandInfoAsync(new GetIslandInfoInput
                {
                    IslandSourceId = eventBody.IslandSourceId
                });

                if (output == null)
                    return;

                await _openApiService.SetChannelMessageSendAsync(new SetChannelMessageSendInput<MessageBodyText>
                {
                    ChannelId = output.SystemChannelId,
                    MessageBody = new MessageBodyText
                    {
                        Content = reply
                    }
                });
            }
            catch (Exception e)
            {
                Exception(e.Message);
            }
        }

        public override async void MemberInviteEvent(EventSubjectOutput<EventSubjectDataBusiness<EventBodyMemberInvite>> input)
        {
            try
            {
                var eventBody = input.Data.EventBody;

                var reply = "";

                reply += "触发成员邀请事件\n";
                reply += $"来源群ID：{eventBody.IslandSourceId}\n";
                reply += $"邀请人DoDoID：{eventBody.DodoSourceId}\n";
                reply += $"邀请人群昵称：{eventBody.DodoIslandNickName}\n";
                reply += $"被邀请人DoDoID：{eventBody.ToDodoSourceId}\n";
                reply += $"被邀请人群昵称：{eventBody.ToDodoIslandNickName}\n";

                var output = await _openApiService.GetIslandInfoAsync(new GetIslandInfoInput
                {
                    IslandSourceId = eventBody.IslandSourceId
                });

                if (output == null)
                    return;

                await _openApiService.SetChannelMessageSendAsync(new SetChannelMessageSendInput<MessageBodyText>
                {
                    ChannelId = output.SystemChannelId,
                    MessageBody = new MessageBodyText
                    {
                        Content = reply
                    }
                });
            }
            catch (Exception e)
            {
                Exception(e.Message);
            }
        }

        #endregion

        #region 赠礼系统

        public override async void GiftSendEvent(EventSubjectOutput<EventSubjectDataBusiness<EventBodyGiftSend>> input)
        {
            try
            {
                var eventBody = input.Data.EventBody;

                var reply = "";

                var jsonSerializerOptions = new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                reply += "触发赠礼成功事件\n";
                reply += $"来源群ID：{eventBody.IslandSourceId}\n";
                reply += $"来源频道ID：{eventBody.ChannelId}\n";
                reply += $"订单号：{eventBody.OrderNo}\n";
                reply += $"内容类型：{eventBody.TargetType}\n";
                reply += $"内容ID：{eventBody.TargetId}\n";
                reply += $"礼物总价值（铃钱）：{eventBody.TotalAmount}\n";
                reply += $"礼物信息：{JsonSerializer.Serialize(eventBody.Gift, jsonSerializerOptions)}\n";
                reply += $"群分成（百分比）：{eventBody.IslandRatio}\n";
                reply += $"群收入（里程）：{eventBody.IslandIncome}\n";
                reply += $"赠礼人DoDoID：{eventBody.DodoSourceId}\n";
                reply += $"赠礼人群昵称：{eventBody.DodoIslandNickName}\n";
                reply += $"被赠礼人DoDoID：{eventBody.ToDodoSourceId}\n";
                reply += $"被赠礼人群昵称：{eventBody.ToDodoIslandNickName}\n";
                reply += $"被赠礼人分成（百分比）：{eventBody.ToDodoRatio}\n";
                reply += $"被赠礼人收入（里程）：{eventBody.ToDodoIncome}\n";

                var output = await _openApiService.GetIslandInfoAsync(new GetIslandInfoInput
                {
                    IslandSourceId = eventBody.IslandSourceId
                });

                if (output == null)
                    return;

                await _openApiService.SetChannelMessageSendAsync(new SetChannelMessageSendInput<MessageBodyText>
                {
                    ChannelId = output.SystemChannelId,
                    MessageBody = new MessageBodyText
                    {
                        Content = reply
                    }
                });
            }
            catch (Exception e)
            {
                Exception(e.Message);
            }
        }

        #endregion
    }
}
