using System.Collections.Generic;
using System.Threading.Tasks;
using DoDo.Open.Sdk.Models.Bots;
using DoDo.Open.Sdk.Models.Channels;
using DoDo.Open.Sdk.Models.Islands;
using DoDo.Open.Sdk.Models.Members;
using DoDo.Open.Sdk.Models.Messages;
using DoDo.Open.Sdk.Models.Personals;
using DoDo.Open.Sdk.Models.Resources;
using DoDo.Open.Sdk.Models.Roles;
using DoDo.Open.Sdk.Models.WebSockets;

namespace DoDo.Open.Sdk.Services;

/// <summary>
///     开放接口服务
/// </summary>
public interface IOpenApiService
{
    /// <summary>
    ///     置个人消息发送
    /// </summary>
    /// <param name="input"></param>
    Task<SetPersonalMessageSendOutput> SetPersonalMessageSend<T>(SetPersonalMessageSendInput<T> input)
        where T : MessageBodyBase;

    /// <summary>
    ///     置资源图片上传
    /// </summary>
    /// <param name="input"></param>
    Task<SetResourcePictureUploadOutput> SetResourcePictureUpload(SetResourceUploadInput input);

    /// <summary>
    ///     取WebSocket连接
    /// </summary>
    /// <param name="input"></param>
    Task<GetWebSocketConnectionOutput> GetWebSocketConnection(GetWebSocketConnectionInput input);

    /// <summary>
    ///     取机器人信息
    /// </summary>
    /// <param name="input"></param>
    Task<GetBotInfoOutput> GetBotInfo(GetBotInfoInput input);

    /// <summary>
    ///     置机器人群退出
    /// </summary>
    /// <param name="input"></param>
    Task<bool> SetBotIslandLeave(SetBotIslandLeaveInput input);

    /// <summary>
    ///     取群列表
    /// </summary>
    /// <param name="input"></param>
    Task<List<GetIslandListOutput>> GetIslandList(GetIslandListInput input);

    /// <summary>
    ///     取群信息
    /// </summary>
    /// <param name="input"></param>
    Task<GetIslandInfoOutput> GetIslandInfo(GetIslandInfoInput input);

    /// <summary>
    ///     取群等级排行榜
    /// </summary>
    /// <param name="input"></param>
    Task<List<GetIslandLevelRankListOutput>> GetIslandLevelRankList(GetIslandLevelRankListInput input);

    /// <summary>
    ///     取频道列表
    /// </summary>
    /// <param name="input"></param>
    Task<List<GetChannelListOutput>> GetChannelList(GetChannelListInput input);

    /// <summary>
    ///     取频道信息
    /// </summary>
    /// <param name="input"></param>
    Task<GetChannelInfoOutput> GetChannelInfo(GetChannelInfoInput input);

    /// <summary>
    ///     置频道消息发送
    /// </summary>
    /// <param name="input"></param>
    Task<SetChannelMessageSendOutput> SetChannelMessageSend<T>(SetChannelMessageSendInput<T> input)
        where T : MessageBodyBase;

    /// <summary>
    ///     置频道消息编辑
    /// </summary>
    /// <param name="input"></param>
    Task<bool> SetChannelMessageEdit<T>(SetChannelMessageEditInput<T> input)
        where T : MessageBodyBase;

    /// <summary>
    ///     置频道消息撤回
    /// </summary>
    /// <param name="input"></param>
    Task<bool> SetChannelMessageWithdraw(SetChannelMessageWithdrawInput input);

    /// <summary>
    ///     置频道消息反应
    /// </summary>
    /// <param name="input"></param>
    Task<bool> SetChannelMessageReaction(SetChannelMessageReactionInput input);

    /// <summary>
    ///     置频道消息反应新增
    /// </summary>
    /// <param name="input"></param>
    Task<bool> SetChannelMessageReactionAdd(SetChannelMessageReactionAddInput input);

    /// <summary>
    ///     置频道消息反应移除
    /// </summary>
    /// <param name="input"></param>
    Task<bool> SetChannelMessageReactionRemove(SetChannelMessageReactionRemoveInput input);

    /// <summary>
    ///     取身份组列表
    /// </summary>
    /// <param name="input"></param>
    Task<List<GetRoleListOutput>> GetRoleList(GetRoleListInput input);

    /// <summary>
    ///     置身份组成员新增
    /// </summary>
    /// <param name="input"></param>
    Task<bool> SetRoleMemberAdd(SetRoleMemberAddInput input);

    /// <summary>
    ///     置身份组成员移除
    /// </summary>
    /// <param name="input"></param>
    Task<bool> SetRoleMemberRemove(SetRoleMemberRemoveInput input);

    /// <summary>
    ///     取成员列表
    /// </summary>
    /// <param name="input"></param>
    Task<GetMemberListOutput> GetMemberList(GetMemberListInput input);

    /// <summary>
    ///     取成员信息
    /// </summary>
    /// <param name="input"></param>
    Task<GetMemberInfoOutput> GetMemberInfo(GetMemberInfoInput input);

    /// <summary>
    ///     取成员身份组列表
    /// </summary>
    /// <param name="input"></param>
    Task<List<GetMemberRoleListOutput>> GetMemberRoleList(GetMemberRoleListInput input);

    /// <summary>
    ///     取成员邀请信息
    /// </summary>
    /// <param name="input"></param>
    Task<GetMemberInvitationInfoOutput> GetMemberInvitationInfo(GetMemberInvitationInfoInput input);

    /// <summary>
    ///     置成员昵称
    /// </summary>
    /// <param name="input"></param>
    Task<bool> SetMemberNick(SetMemberNickInput input);

    /// <summary>
    ///     置成员禁言
    /// </summary>
    /// <param name="input"></param>
    Task<bool> SetMemberBan(SetMemberBanInput input);

    /// <summary>
    ///     取成员高能链数字藏品信息
    /// </summary>
    /// <param name="input"></param>
    Task<GetMemberUPowerchainInfoOutput> GetMemberUPowerchainInfo(GetMemberUPowerchainInfoInput input);

    /// <summary>
    ///     取成员数字藏品状态
    /// </summary>
    /// <param name="input"></param>
    Task<GetMemberNftStatusOutput> GetMemberNftStatus(GetMemberNftStatusInput input);
}
