using System;
using System.Collections.Generic;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Text.Unicode;
using System.Threading.Tasks;
using DoDo.Open.Sdk.Models;
using DoDo.Open.Sdk.Models.Bots;
using DoDo.Open.Sdk.Models.Channels;
using DoDo.Open.Sdk.Models.Islands;
using DoDo.Open.Sdk.Models.Members;
using DoDo.Open.Sdk.Models.Messages;
using DoDo.Open.Sdk.Models.Personals;
using DoDo.Open.Sdk.Models.Resources;
using DoDo.Open.Sdk.Models.Roles;
using DoDo.Open.Sdk.Models.WebSockets;
using RestSharp;

namespace DoDo.Open.Sdk.Services
{
    /// <summary>
    /// 开放接口服务
    /// </summary>
    public class OpenApiService
    {
        private readonly OpenApiOptions _openApiOptions;

        public OpenApiService(OpenApiOptions openApiOptions)
        {
            _openApiOptions = openApiOptions;
        }

        #region 机器人

        /// <summary>
        /// 获取机器人配置
        /// </summary>
        /// <returns></returns>
        public OpenApiOptions GetBotOptions()
        {
            return _openApiOptions;
        }

        /// <summary>
        /// 获取机器人信息
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public GetBotInfoOutput GetBotInfo(GetBotInfoInput input, bool isThrowException = false)
        {
            return GetBotInfoAsync(input, isThrowException).Result;
        }

        /// <summary>
        /// 获取机器人信息-异步
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public async Task<GetBotInfoOutput> GetBotInfoAsync(GetBotInfoInput input, bool isThrowException = false)
        {
            return await BaseRequest<GetBotInfoInput, GetBotInfoOutput>("/api/v1/bot/info", input, isThrowException);
        }

        /// <summary>
        /// 机器人退群
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public bool SetBotIslandLeave(SetBotIslandLeaveInput input, bool isThrowException = false)
        {
            return SetBotIslandLeaveAsync(input, isThrowException).Result;
        }

        /// <summary>
        /// 机器人退群-异步
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public async Task<bool> SetBotIslandLeaveAsync(SetBotIslandLeaveInput input, bool isThrowException = false)
        {
            return await BaseRequest("/api/v1/bot/island/leave", input, isThrowException);
        }

        /// <summary>
        /// 获取机器人邀请列表
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public GetBotInviteListOutput GetBotInviteList(GetBotInviteListInput input, bool isThrowException = false)
        {
            return GetBotInviteListAsync(input, isThrowException).Result;
        }

        /// <summary>
        /// 获取机器人邀请列表-异步
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public async Task<GetBotInviteListOutput> GetBotInviteListAsync(GetBotInviteListInput input, bool isThrowException = false)
        {
            return await BaseRequest<GetBotInviteListInput, GetBotInviteListOutput>("/api/v1/bot/invite/list", input, isThrowException);
        }

        /// <summary>
        /// 添加成员到机器人邀请列表
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public bool SetBotInviteAdd(SetBotInviteAddInput input, bool isThrowException = false)
        {
            return SetBotInviteAddAsync(input, isThrowException).Result;
        }

        /// <summary>
        /// 添加成员到机器人邀请列表-异步
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public async Task<bool> SetBotInviteAddAsync(SetBotInviteAddInput input, bool isThrowException = false)
        {
            return await BaseRequest("/api/v1/bot/invite/add", input, isThrowException);
        }

        /// <summary>
        /// 移除成员出机器人邀请列表
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public bool SetBotInviteRemove(SetBotInviteRemoveInput input, bool isThrowException = false)
        {
            return SetBotInviteRemoveAsync(input, isThrowException).Result;
        }

        /// <summary>
        /// 移除成员出机器人邀请列表-异步
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public async Task<bool> SetBotInviteRemoveAsync(SetBotInviteRemoveInput input, bool isThrowException = false)
        {
            return await BaseRequest("/api/v1/bot/invite/remove", input, isThrowException);
        }

        #endregion

        #region 群

        /// <summary>
        /// 获取群列表
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public List<GetIslandListOutput> GetIslandList(GetIslandListInput input, bool isThrowException = false)
        {
            return GetIslandListAsync(input, isThrowException).Result;
        }

        /// <summary>
        /// 获取群列表-异步
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public async Task<List<GetIslandListOutput>> GetIslandListAsync(GetIslandListInput input, bool isThrowException = false)
        {
            return await BaseRequest<GetIslandListInput, List<GetIslandListOutput>>("/api/v1/island/list", input, isThrowException);
        }

        /// <summary>
        /// 获取群信息
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public GetIslandInfoOutput GetIslandInfo(GetIslandInfoInput input, bool isThrowException = false)
        {
            return GetIslandInfoAsync(input, isThrowException).Result;
        }

        /// <summary>
        /// 获取群信息-异步
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public async Task<GetIslandInfoOutput> GetIslandInfoAsync(GetIslandInfoInput input, bool isThrowException = false)
        {
            return await BaseRequest<GetIslandInfoInput, GetIslandInfoOutput>("/api/v1/island/info", input, isThrowException);
        }

        /// <summary>
        /// 获取群等级排行榜
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public List<GetIslandLevelRankListOutput> GetIslandLevelRankList(GetIslandLevelRankListInput input, bool isThrowException = false)
        {
            return GetIslandLevelRankListAsync(input, isThrowException).Result;
        }

        /// <summary>
        /// 获取群等级排行榜-异步
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public async Task<List<GetIslandLevelRankListOutput>> GetIslandLevelRankListAsync(GetIslandLevelRankListInput input, bool isThrowException = false)
        {
            return await BaseRequest<GetIslandLevelRankListInput, List<GetIslandLevelRankListOutput>>("/api/v1/island/level/rank/list", input, isThrowException);
        }

        /// <summary>
        /// 获取群禁言名单
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public GetIslandMuteListOutput GetIslandMuteList(GetIslandMuteListInput input, bool isThrowException = false)
        {
            return GetIslandMuteListAsync(input, isThrowException).Result;
        }

        /// <summary>
        /// 获取群禁言名单-异步
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public async Task<GetIslandMuteListOutput> GetIslandMuteListAsync(GetIslandMuteListInput input, bool isThrowException = false)
        {
            return await BaseRequest<GetIslandMuteListInput, GetIslandMuteListOutput>("/api/v1/island/mute/list", input, isThrowException);
        }

        /// <summary>
        /// 获取群封禁名单
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public GetIslandBanListOutput GetIslandBanList(GetIslandBanListInput input, bool isThrowException = false)
        {
            return GetIslandBanListAsync(input, isThrowException).Result;
        }

        /// <summary>
        /// 获取群封禁名单-异步
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public async Task<GetIslandBanListOutput> GetIslandBanListAsync(GetIslandBanListInput input, bool isThrowException = false)
        {
            return await BaseRequest<GetIslandBanListInput, GetIslandBanListOutput>("/api/v1/island/ban/list", input, isThrowException); ;
        }

        #endregion

        #region 频道

        /// <summary>
        /// 获取频道列表
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public List<GetChannelListOutput> GetChannelList(GetChannelListInput input, bool isThrowException = false)
        {
            return GetChannelListAsync(input, isThrowException).Result;
        }

        /// <summary>
        /// 获取频道列表-异步
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public async Task<List<GetChannelListOutput>> GetChannelListAsync(GetChannelListInput input, bool isThrowException = false)
        {
            return await BaseRequest<GetChannelListInput, List<GetChannelListOutput>>("/api/v1/channel/list", input, isThrowException);
        }

        /// <summary>
        /// 获取频道信息
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public GetChannelInfoOutput GetChannelInfo(GetChannelInfoInput input, bool isThrowException = false)
        {
            return GetChannelInfoAsync(input, isThrowException).Result;
        }

        /// <summary>
        /// 获取频道信息-异步
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public async Task<GetChannelInfoOutput> GetChannelInfoAsync(GetChannelInfoInput input, bool isThrowException = false)
        {
            return await BaseRequest<GetChannelInfoInput, GetChannelInfoOutput>("/api/v1/channel/info", input, isThrowException);
        }

        /// <summary>
        /// 创建频道
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public SetChannelAddOutput SetChannelAdd(SetChannelAddInput input, bool isThrowException = false)
        {
            return SetChannelAddAsync(input, isThrowException).Result;
        }

        /// <summary>
        /// 创建频道-异步
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public async Task<SetChannelAddOutput> SetChannelAddAsync(SetChannelAddInput input, bool isThrowException = false)
        {
            return await BaseRequest<SetChannelAddInput, SetChannelAddOutput>("/api/v1/channel/add", input, isThrowException);
        }

        /// <summary>
        /// 编辑频道
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public bool SetChannelEdit(SetChannelEditInput input, bool isThrowException = false)
        {
            return SetChannelEditAsync(input, isThrowException).Result;
        }

        /// <summary>
        /// 编辑频道-异步
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public async Task<bool> SetChannelEditAsync(SetChannelEditInput input, bool isThrowException = false)
        {
            return await BaseRequest<SetChannelEditInput, bool>("/api/v1/channel/edit", input, isThrowException);
        }

        /// <summary>
        /// 删除频道
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public bool SetChannelRemove(SetChannelRemoveInput input, bool isThrowException = false)
        {
            return SetChannelRemoveAsync(input, isThrowException).Result;
        }

        /// <summary>
        /// 删除频道-异步
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public async Task<bool> SetChannelRemoveAsync(SetChannelRemoveInput input, bool isThrowException = false)
        {
            return await BaseRequest<SetChannelRemoveInput, bool>("/api/v1/channel/remove", input, isThrowException);
        }

        #endregion

        #region 文字频道

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public SetChannelMessageSendOutput SetChannelMessageSend<T>(SetChannelMessageSendInput<T> input, bool isThrowException = false)
        where T : MessageBodyBase
        {
            return SetChannelMessageSendAsync(input, isThrowException).Result;
        }

        /// <summary>
        /// 发送消息-异步
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public async Task<SetChannelMessageSendOutput> SetChannelMessageSendAsync<T>(SetChannelMessageSendInput<T> input, bool isThrowException = false)
            where T : MessageBodyBase
        {
            return await BaseRequest<SetChannelMessageSendInput<T>, SetChannelMessageSendOutput>("/api/v1/channel/message/send", input, isThrowException);
        }

        /// <summary>
        /// 编辑消息
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public bool SetChannelMessageEdit<T>(SetChannelMessageEditInput<T> input, bool isThrowException = false)
            where T : MessageBodyBase
        {
            return SetChannelMessageEditAsync(input,isThrowException).Result;
        }

        /// <summary>
        /// 编辑消息-异步
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public async Task<bool> SetChannelMessageEditAsync<T>(SetChannelMessageEditInput<T> input, bool isThrowException = false)
            where T : MessageBodyBase
        {
            return await BaseRequest("/api/v1/channel/message/edit", input, isThrowException);
        }

        /// <summary>
        /// 撤回消息
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public bool SetChannelMessageWithdraw(SetChannelMessageWithdrawInput input, bool isThrowException = false)
        {
            return SetChannelMessageWithdrawAsync(input, isThrowException).Result;
        }

        /// <summary>
        /// 撤回消息-异步
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public async Task<bool> SetChannelMessageWithdrawAsync(SetChannelMessageWithdrawInput input, bool isThrowException = false)
        {
            return await BaseRequest("/api/v1/channel/message/withdraw", input, isThrowException);
        }

        /// <summary>
        /// 表情反应
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        [Obsolete("该方法已弃用，请使用 SetChannelMessageReactionAdd 和 SetChannelMessageReactionRemove 替代")]
        public bool SetChannelMessageReaction(SetChannelMessageReactionInput input, bool isThrowException = false)
        {
            return SetChannelMessageReactionAsync(input, isThrowException).Result;
        }

        /// <summary>
        /// 表情反应-异步
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        [Obsolete("该方法已弃用，请使用 SetChannelMessageReactionAddAsync 和 SetChannelMessageReactionRemoveAsync 替代")]
        public async Task<bool> SetChannelMessageReactionAsync(SetChannelMessageReactionInput input, bool isThrowException = false)
        {
            return await BaseRequest("/api/v1/channel/message/reaction", input, isThrowException);
        }

        /// <summary>
        /// 添加表情反应
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public bool SetChannelMessageReactionAdd(SetChannelMessageReactionAddInput input, bool isThrowException = false)
        {
            return SetChannelMessageReactionAddAsync(input, isThrowException).Result;
        }

        /// <summary>
        /// 添加表情反应-异步
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public async Task<bool> SetChannelMessageReactionAddAsync(SetChannelMessageReactionAddInput input, bool isThrowException = false)
        {
            return await BaseRequest("/api/v1/channel/message/reaction/add", input, isThrowException);
        }

        /// <summary>
        /// 取消表情反应
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public bool SetChannelMessageReactionRemove(SetChannelMessageReactionRemoveInput input, bool isThrowException = false)
        {
            return SetChannelMessageReactionRemoveAsync(input, isThrowException).Result;
        }

        /// <summary>
        /// 取消表情反应-异步
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public async Task<bool> SetChannelMessageReactionRemoveAsync(SetChannelMessageReactionRemoveInput input, bool isThrowException = false)
        {
            return await BaseRequest("/api/v1/channel/message/reaction/remove", input, isThrowException);
        }

        #endregion

        #region 语音频道

        /// <summary>
        /// 获取成员语音频道状态
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public GetChannelVoiceMemberStatusOutput GetChannelVoiceMemberStatus(GetChannelVoiceMemberStatusInput input, bool isThrowException = false)
        {
            return GetChannelVoiceMemberStatusAsync(input, isThrowException).Result;
        }

        /// <summary>
        /// 获取成员语音频道状态-异步
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public async Task<GetChannelVoiceMemberStatusOutput> GetChannelVoiceMemberStatusAsync(GetChannelVoiceMemberStatusInput input, bool isThrowException = false)
        {
            return await BaseRequest<GetChannelVoiceMemberStatusInput, GetChannelVoiceMemberStatusOutput>("/api/v1/channel/voice/member/status", input, isThrowException);
        }

        /// <summary>
        /// 移动语音频道成员
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public bool SetChannelVoiceMemberMove(SetChannelVoiceMemberMoveInput input, bool isThrowException = false)
        {
            return SetChannelVoiceMemberMoveAsync(input, isThrowException).Result;
        }

        /// <summary>
        /// 移动语音频道成员-异步
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public async Task<bool> SetChannelVoiceMemberMoveAsync(SetChannelVoiceMemberMoveInput input, bool isThrowException = false)
        {
            return await BaseRequest("/api/v1/channel/voice/member/move", input, isThrowException);
        }

        /// <summary>
        /// 管理语音中的成员
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public bool SetChannelVoiceMemberEdit(SetChannelVoiceMemberEditInput input, bool isThrowException = false)
        {
            return SetChannelVoiceMemberEditAsync(input, isThrowException).Result;
        }

        /// <summary>
        /// 管理语音中的成员-异步
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public async Task<bool> SetChannelVoiceMemberEditAsync(SetChannelVoiceMemberEditInput input, bool isThrowException = false)
        {
            return await BaseRequest("/api/v1/channel/voice/member/edit", input, isThrowException);
        }

        #endregion

        #region 帖子频道

        /// <summary>
        /// 发布帖子
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public SetChannelArticleAddOutput SetChannelArticleAdd(SetChannelArticleAddInput input, bool isThrowException = false)
        {
            return SetChannelArticleAddAsync(input, isThrowException).Result;
        }

        /// <summary>
        /// 发布帖子-异步
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public async Task<SetChannelArticleAddOutput> SetChannelArticleAddAsync(SetChannelArticleAddInput input, bool isThrowException = false)
        {
            return await BaseRequest<SetChannelArticleAddInput, SetChannelArticleAddOutput>("/api/v1/channel/article/add", input, isThrowException);
        }

        /// <summary>
        /// 删除帖子评论回复
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public bool SetChannelArticleRemove(SetChannelArticleRemoveInput input, bool isThrowException = false)
        {
            return SetChannelArticleRemoveAsync(input, isThrowException).Result;
        }

        /// <summary>
        /// 删除帖子评论回复-异步
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public async Task<bool> SetChannelArticleRemoveAsync(SetChannelArticleRemoveInput input, bool isThrowException = false)
        {
            return await BaseRequest("/api/v1/channel/article/remove", input, isThrowException);
        }
        
        #endregion

        #region 身份组

        /// <summary>
        /// 获取身份组列表
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public List<GetRoleListOutput> GetRoleList(GetRoleListInput input, bool isThrowException = false)
        {
            return GetRoleListAsync(input, isThrowException).Result;
        }

        /// <summary>
        /// 获取身份组列表-异步
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public async Task<List<GetRoleListOutput>> GetRoleListAsync(GetRoleListInput input, bool isThrowException = false)
        {
            return await BaseRequest<GetRoleListInput, List<GetRoleListOutput>>("/api/v1/role/list", input, isThrowException);
        }

        /// <summary>
        /// 创建身份组
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public SetRoleAddOutput SetRoleAdd(SetRoleAddInput input, bool isThrowException = false)
        {
            return SetRoleAddAsync(input, isThrowException).Result;
        }

        /// <summary>
        /// 创建身份组-异步
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public async Task<SetRoleAddOutput> SetRoleAddAsync(SetRoleAddInput input, bool isThrowException = false)
        {
            return await BaseRequest<SetRoleAddInput, SetRoleAddOutput>("/api/v1/role/add", input, isThrowException);
        }

        /// <summary>
        /// 编辑身份组
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public bool SetRoleEdit(SetRoleEditInput input, bool isThrowException = false)
        {
            return SetRoleEditAsync(input, isThrowException).Result;
        }

        /// <summary>
        /// 编辑身份组-异步
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public async Task<bool> SetRoleEditAsync(SetRoleEditInput input, bool isThrowException = false)
        {
            return await BaseRequest<SetRoleEditInput, bool>("/api/v1/role/edit", input, isThrowException);
        }

        /// <summary>
        /// 删除身份组
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public bool SetRoleRemove(SetRoleRemoveInput input, bool isThrowException = false)
        {
            return SetRoleRemoveAsync(input, isThrowException).Result;
        }

        /// <summary>
        /// 删除身份组-异步
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public async Task<bool> SetRoleRemoveAsync(SetRoleRemoveInput input, bool isThrowException = false)
        {
            return await BaseRequest<SetRoleRemoveInput, bool>("/api/v1/role/remove", input, isThrowException);
        }

        /// <summary>
        /// 赋予成员身份组
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public bool SetRoleMemberAdd(SetRoleMemberAddInput input, bool isThrowException = false)
        {
            return SetRoleMemberAddAsync(input, isThrowException).Result;
        }

        /// <summary>
        /// 赋予成员身份组-异步
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public async Task<bool> SetRoleMemberAddAsync(SetRoleMemberAddInput input, bool isThrowException = false)
        {
            return await BaseRequest("/api/v1/role/member/add", input, isThrowException);
        }

        /// <summary>
        /// 取消成员身份组
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public bool SetRoleMemberRemove(SetRoleMemberRemoveInput input, bool isThrowException = false)
        {
            return SetRoleMemberRemoveAsync(input, isThrowException).Result;
        }

        /// <summary>
        /// 取消成员身份组-异步
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public async Task<bool> SetRoleMemberRemoveAsync(SetRoleMemberRemoveInput input, bool isThrowException = false)
        {
            return await BaseRequest("/api/v1/role/member/remove", input, isThrowException);
        }

        #endregion

        #region 成员

        /// <summary>
        /// 获取成员列表
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public GetMemberListOutput GetMemberList(GetMemberListInput input, bool isThrowException = false)
        {
            return GetMemberListAsync(input, isThrowException).Result;
        }

        /// <summary>
        /// 获取成员列表-异步
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public async Task<GetMemberListOutput> GetMemberListAsync(GetMemberListInput input, bool isThrowException = false)
        {
            return await BaseRequest<GetMemberListInput, GetMemberListOutput>("/api/v1/member/list", input, isThrowException);
        }

        /// <summary>
        /// 获取成员信息
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public GetMemberInfoOutput GetMemberInfo(GetMemberInfoInput input, bool isThrowException = false)
        {
            return GetMemberInfoAsync(input, isThrowException).Result;
        }

        /// <summary>
        /// 获取成员信息-异步
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public async Task<GetMemberInfoOutput> GetMemberInfoAsync(GetMemberInfoInput input, bool isThrowException = false)
        {
            return await BaseRequest<GetMemberInfoInput, GetMemberInfoOutput>("/api/v1/member/info", input, isThrowException);
        }

        /// <summary>
        /// 获取成员身份组列表
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public List<GetMemberRoleListOutput> GetMemberRoleList(GetMemberRoleListInput input, bool isThrowException = false)
        {
            return GetMemberRoleListAsync(input, isThrowException).Result;
        }

        /// <summary>
        /// 获取成员身份组列表-异步
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public async Task<List<GetMemberRoleListOutput>> GetMemberRoleListAsync(GetMemberRoleListInput input, bool isThrowException = false)
        {
            return await BaseRequest<GetMemberRoleListInput, List<GetMemberRoleListOutput>>("/api/v1/member/role/list", input, isThrowException);
        }

        /// <summary>
        /// 获取成员邀请信息
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public GetMemberInvitationInfoOutput GetMemberInvitationInfo(GetMemberInvitationInfoInput input, bool isThrowException = false)
        {
            return GetMemberInvitationInfoAsync(input, isThrowException).Result;
        }

        /// <summary>
        /// 获取成员邀请信息-异步
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public async Task<GetMemberInvitationInfoOutput> GetMemberInvitationInfoAsync(GetMemberInvitationInfoInput input, bool isThrowException = false)
        {
            return await BaseRequest<GetMemberInvitationInfoInput, GetMemberInvitationInfoOutput>("/api/v1/member/invitation/info", input, isThrowException); 
        }

        /// <summary>
        /// 编辑成员群昵称
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        [Obsolete("该方法已弃用，请使用 SetMemberNickNameEdit 替代")]
        public bool SetMemberNick(SetMemberNickInput input, bool isThrowException = false)
        {
            return SetMemberNickAsync(input, isThrowException).Result;
        }

        /// <summary>
        /// 编辑成员群昵称-异步
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        [Obsolete("该方法已弃用，请使用 SetMemberNickNameEditAsync 替代")]
        public async Task<bool> SetMemberNickAsync(SetMemberNickInput input, bool isThrowException = false)
        {
            return await BaseRequest("/api/v1/member/nick/set", input, isThrowException);
        }

        /// <summary>
        /// 编辑成员群昵称
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public bool SetMemberNickNameEdit(SetMemberNickNameEditInput input, bool isThrowException = false)
        {
            return SetMemberNickNameEditAsync(input, isThrowException).Result;
        }

        /// <summary>
        /// 编辑成员群昵称-异步
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public async Task<bool> SetMemberNickNameEditAsync(SetMemberNickNameEditInput input, bool isThrowException = false)
        {
            return await BaseRequest("/api/v1/member/nick/set", input, isThrowException);
        }

        /// <summary>
        /// 禁言成员
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        [Obsolete("该方法已弃用，请使用 SetMemberMuteAdd 替代")]
        public bool SetMemberBan(SetMemberBanInput input, bool isThrowException = false)
        {
            return SetMemberBanAsync(input, isThrowException).Result;
        }

        /// <summary>
        /// 禁言成员-异步
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        [Obsolete("该方法已弃用，请使用 SetMemberMuteAddAsync 替代")]
        public async Task<bool> SetMemberBanAsync(SetMemberBanInput input, bool isThrowException = false)
        {
            return await BaseRequest("/api/v1/member/ban/set", input, isThrowException);
        }

        /// <summary>
        /// 禁言成员
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public bool SetMemberMuteAdd(SetMemberMuteAddInput input, bool isThrowException = false)
        {
            return SetMemberMuteAddAsync(input, isThrowException).Result;
        }

        /// <summary>
        /// 禁言成员-异步
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public async Task<bool> SetMemberMuteAddAsync(SetMemberMuteAddInput input, bool isThrowException = false)
        {
            return await BaseRequest("/api/v1/member/ban/set", input, isThrowException);
        }

        /// <summary>
        /// 取消成员禁言
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public bool SetMemberMuteRemove(SetMemberMuteRemoveInput input, bool isThrowException = false)
        {
            return SetMemberMuteRemoveAsync(input, isThrowException).Result;
        }

        /// <summary>
        /// 取消成员禁言-异步
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public async Task<bool> SetMemberMuteRemoveAsync(SetMemberMuteRemoveInput input, bool isThrowException = false)
        {
            return await BaseRequest("/api/v1/member/mute/remove", input, isThrowException);
        }

        /// <summary>
        /// 永久封禁成员
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public bool SetMemberBanAdd(SetMemberBanAddInput input, bool isThrowException = false)
        {
            return SetMemberBanAddAsync(input, isThrowException).Result;
        }

        /// <summary>
        /// 永久封禁成员-异步
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public async Task<bool> SetMemberBanAddAsync(SetMemberBanAddInput input, bool isThrowException = false)
        {
            return await BaseRequest("/api/v1/member/ban/add", input, isThrowException);
        }

        /// <summary>
        /// 取消成员永久封禁
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public bool SetMemberBanRemove(SetMemberBanRemoveInput input, bool isThrowException = false)
        {
            return SetMemberBanRemoveAsync(input, isThrowException).Result;
        }

        /// <summary>
        /// 取消成员永久封禁-异步
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public async Task<bool> SetMemberBanRemoveAsync(SetMemberBanRemoveInput input, bool isThrowException = false)
        {
            return await BaseRequest("/api/v1/member/ban/remove", input, isThrowException);
        }

        #endregion

        #region 数字藏品

        /// <summary>
        /// 获取成员高能链数字藏品信息
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        [Obsolete("该方法已弃用，请使用 GetMemberNftStatus 替代")]
        public GetMemberUPowerchainInfoOutput GetMemberUPowerchainInfo(GetMemberUPowerchainInfoInput input, bool isThrowException = false)
        {
            return GetMemberUPowerchainInfoAsync(input, isThrowException).Result;
        }

        /// <summary>
        /// 获取成员高能链数字藏品信息-异步
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        [Obsolete("该方法已弃用，请使用 GetMemberNftStatusAsync 替代")]
        public async Task<GetMemberUPowerchainInfoOutput> GetMemberUPowerchainInfoAsync(GetMemberUPowerchainInfoInput input, bool isThrowException = false)
        {
            return await BaseRequest<GetMemberUPowerchainInfoInput, GetMemberUPowerchainInfoOutput>("/api/v1/member/upowerchain/info", input, isThrowException);
        }

        /// <summary>
        /// 获取成员数字藏品判断
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public GetMemberNftStatusOutput GetMemberNftStatus(GetMemberNftStatusInput input, bool isThrowException = false)
        {
            return GetMemberNftStatusAsync(input, isThrowException).Result;
        }

        /// <summary>
        /// 获取成员数字藏品判断-异步
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public async Task<GetMemberNftStatusOutput> GetMemberNftStatusAsync(GetMemberNftStatusInput input, bool isThrowException = false)
        {
            return await BaseRequest<GetMemberNftStatusInput, GetMemberNftStatusOutput>("/api/v1/member/nft/status", input, isThrowException);
        }

        #endregion

        #region 私信

        /// <summary>
        /// 发送私信
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public SetPersonalMessageSendOutput SetPersonalMessageSend<T>(SetPersonalMessageSendInput<T> input, bool isThrowException = false)
            where T : MessageBodyBase
        {
            return SetPersonalMessageSendAsync(input, isThrowException).Result;
        }

        /// <summary>
        /// 发送私信-异步
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public async Task<SetPersonalMessageSendOutput> SetPersonalMessageSendAsync<T>(SetPersonalMessageSendInput<T> input, bool isThrowException = false)
            where T : MessageBodyBase
        {
            return await BaseRequest<SetPersonalMessageSendInput<T>, SetPersonalMessageSendOutput>("/api/v1/personal/message/send", input, isThrowException);
        }

        #endregion

        #region 资源

        /// <summary>
        /// 上传资源图片
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public SetResourcePictureUploadOutput SetResourcePictureUpload(SetResourceUploadInput input, bool isThrowException = false)
        {
            return SetResourcePictureUploadAsync(input, isThrowException).Result;
        }

        /// <summary>
        /// 上传资源图片-异步
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public async Task<SetResourcePictureUploadOutput> SetResourcePictureUploadAsync(SetResourceUploadInput input, bool isThrowException = false)
        {
            return await BaseRequest<SetResourceUploadInput, SetResourcePictureUploadOutput>("/api/v1/resource/picture/upload", input, isThrowException);
        }

        #endregion

        #region 事件

        /// <summary>
        /// 获取WebSocket连接
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public GetWebSocketConnectionOutput GetWebSocketConnection(GetWebSocketConnectionInput input, bool isThrowException = false)
        {
            return GetWebSocketConnectionAsync(input, isThrowException).Result;
        }

        /// <summary>
        /// 获取WebSocket连接-异步
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public async Task<GetWebSocketConnectionOutput> GetWebSocketConnectionAsync(GetWebSocketConnectionInput input, bool isThrowException = false)
        {
            return await BaseRequest<GetWebSocketConnectionInput, GetWebSocketConnectionOutput>("/api/v1/websocket/connection", input, isThrowException);
        }

        #endregion

        #region 基础调用

        /// <summary>
        /// 基础调用（什么也不带）
        /// </summary>
        /// <param name="resource">接口路径</param>
        /// <param name="isThrowException">是否抛出异常</param>
        /// <returns>返回结果</returns>
        public async Task<bool> BaseRequest(string resource, bool isThrowException)
        {
            var result = await BaseRequest<object, object>(resource, Method.POST, new object(), isThrowException);

            if (result == default)
                return default;

            return result.Status == 0;
        }

        /// <summary>
        /// 基础调用（带返回参数）
        /// </summary>
        /// <typeparam name="TOutput">返回参数类型</typeparam>
        /// <param name="resource">接口路径</param>
        /// <param name="isThrowException">是否抛出异常</param>
        /// <returns>返回结果</returns>
        public async Task<TOutput> BaseRequest<TOutput>(string resource, bool isThrowException)
            where TOutput : new()
        {
            var result = await BaseRequest<object, TOutput>(resource, Method.POST, new object(), isThrowException);

            if (result == default)
                return default;

            return result.Status == 0 ? result.Data : default;
        }

        /// <summary>
        /// 基础调用（带请求参数）
        /// </summary>
        /// <typeparam name="TInput">请求参数类型</typeparam>
        /// <param name="resource">接口路径</param>
        /// <param name="input">请求数据</param>
        /// <param name="isThrowException">是否抛出异常</param>
        /// <returns>返回结果</returns>
        public async Task<bool> BaseRequest<TInput>(string resource, TInput input, bool isThrowException)
            where TInput : new()
        {
            var result = await BaseRequest<TInput, object>(resource, Method.POST, input, isThrowException);

            if (result == default)
                return default;

            return result.Status == 0;
        }

        /// <summary>
        /// 基础调用（带请求参数和返回参数）
        /// </summary>
        /// <typeparam name="TInput">请求参数类型</typeparam>
        /// <typeparam name="TOutput">返回参数类型</typeparam>
        /// <param name="resource">接口路径</param>
        /// <param name="input">请求数据</param>
        /// <param name="isThrowException">是否抛出异常</param>
        /// <returns>返回结果</returns>
        public async Task<TOutput> BaseRequest<TInput, TOutput>(string resource, TInput input, bool isThrowException)
            where TInput : new()
            where TOutput : new()
        {
            var result = await BaseRequest<TInput, TOutput>(resource, Method.POST, input, isThrowException);

            if (result == default)
                return default;

            return result.Status == 0 ? result.Data : default;
        }

        /// <summary>
        /// 基础调用
        /// </summary>
        /// <typeparam name="TInput">请求参数类型</typeparam>
        /// <typeparam name="TOutput">返回参数类型</typeparam>
        /// <param name="resource">接口路径</param>
        /// <param name="method">请求方式</param>
        /// <param name="input">请求数据</param>
        /// <param name="isThrowException">是否抛出异常</param>
        /// <returns>返回结果</returns>
        public async Task<OpenApiBaseOutput<TOutput>> BaseRequest<TInput, TOutput>(string resource, Method method, TInput input, bool isThrowException)
        where TInput : new()
        where TOutput : new()
        {
            try
            {
                var client = new RestClient(_openApiOptions.BaseApi);
                var request = new RestRequest(resource);

                request.AddHeader("Authorization", $"Bot {_openApiOptions.ClientId}.{_openApiOptions.Token}");

                var jsonSerializerOptions = new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                if (input is SetResourceUploadInput uploadResourceInput)
                {
                    if (Regex.IsMatch(uploadResourceInput.FilePath, "(http|https|ftp)://.*?"))
                    {
                        request.AddFile("file", new RestClient(uploadResourceInput.FilePath).DownloadData(new RestRequest()), uploadResourceInput.FilePath);
                    }
                    else
                    {
                        request.AddFile("file", uploadResourceInput.FilePath);
                    }
                }
                else
                {
                    request.AddJsonBody(JsonSerializer.Serialize(input, jsonSerializerOptions));
                }

                var response = await client.ExecuteAsync<OpenApiBaseOutput<TOutput>>(request, method);

                _openApiOptions.Log?.Invoke($"Resource: {resource}\nRequest: {JsonSerializer.Serialize(input, jsonSerializerOptions)}\nResponse: {response.Content}");

                if (response.Data.Status != 0)
                {
                    if (isThrowException)
                    {
                        throw new Exception(response.Data.Message);
                    }
                }

                return response.Data;
            }
            catch
            {
                if (isThrowException)
                {
                    throw;
                }

                return default;
            }

        }

        #endregion

    }
}