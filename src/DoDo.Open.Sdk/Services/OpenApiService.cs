using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.RegularExpressions;
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

namespace DoDo.Open.Sdk.Services;

/// <summary>
///     开放接口服务
/// </summary>
public class OpenApiService
{
    private readonly HttpClient _httpClient;
    private readonly OpenApiOptions _openApiOptions;

    public OpenApiService(OpenApiOptions openApiOptions)
    {
        _openApiOptions = openApiOptions;
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri(_openApiOptions.BaseApi);
        _httpClient.DefaultRequestHeaders.Add("Authorization",
            $"Bot {_openApiOptions.ClientId}.{_openApiOptions.Token}");
    }

    #region 个人

    /// <summary>
    ///     置个人消息发送
    /// </summary>
    /// <param name="input"></param>
    public async Task<SetPersonalMessageSendOutput> SetPersonalMessageSend<T>(SetPersonalMessageSendInput<T> input)
        where T : MessageBodyBase
    {
        var result = await
            BaseRequest<SetPersonalMessageSendInput<T>, SetPersonalMessageSendOutput>("/api/v1/personal/message/send",
                input);

        return result;
    }

    #endregion

    #region 资源

    /// <summary>
    ///     置资源图片上传
    /// </summary>
    /// <param name="input"></param>
    public async Task<SetResourcePictureUploadOutput> SetResourcePictureUpload(SetResourceUploadInput input)
    {
        var result = await
            BaseRequest<SetResourceUploadInput, SetResourcePictureUploadOutput>("/api/v1/resource/picture/upload",
                input);

        return result;
    }

    #endregion

    #region 事件

    /// <summary>
    ///     取WebSocket连接
    /// </summary>
    /// <param name="input"></param>
    public async Task<GetWebSocketConnectionOutput> GetWebSocketConnection(GetWebSocketConnectionInput input)
    {
        var result = await
            BaseRequest<GetWebSocketConnectionInput, GetWebSocketConnectionOutput>("/api/v1/websocket/connection",
                input);

        return result;
    }

    #endregion

    #region 机器人

    /// <summary>
    ///     取机器人配置
    /// </summary>
    /// <returns></returns>
    public OpenApiOptions GetBotOptions()
    {
        return _openApiOptions;
    }

    /// <summary>
    ///     取机器人信息
    /// </summary>
    /// <param name="input"></param>
    public async Task<GetBotInfoOutput> GetBotInfo(GetBotInfoInput input)
    {
        var result = await BaseRequest<GetBotInfoInput, GetBotInfoOutput>("/api/v1/bot/info", input);

        return result;
    }

    /// <summary>
    ///     置机器人群退出
    /// </summary>
    /// <param name="input"></param>
    public async Task<bool> SetBotIslandLeave(SetBotIslandLeaveInput input)
    {
        var result = await BaseRequest("/api/v1/bot/island/leave", input);

        return result;
    }

    #endregion

    #region 群

    /// <summary>
    ///     取群列表
    /// </summary>
    /// <param name="input"></param>
    public async Task<List<GetIslandListOutput>> GetIslandList(GetIslandListInput input)
    {
        var result = await
            BaseRequest<GetIslandListInput, List<GetIslandListOutput>>("/api/v1/island/list", input);

        return result;
    }

    /// <summary>
    ///     取群信息
    /// </summary>
    /// <param name="input"></param>
    public async Task<GetIslandInfoOutput> GetIslandInfo(GetIslandInfoInput input)
    {
        var result = await
            BaseRequest<GetIslandInfoInput, GetIslandInfoOutput>("/api/v1/island/info", input);

        return result;
    }

    /// <summary>
    ///     取群等级排行榜
    /// </summary>
    /// <param name="input"></param>
    public async Task<List<GetIslandLevelRankListOutput>> GetIslandLevelRankList(GetIslandLevelRankListInput input)
    {
        var result = await
            BaseRequest<GetIslandLevelRankListInput, List<GetIslandLevelRankListOutput>>(
                "/api/v1/island/level/rank/list", input);

        return result;
    }

    #endregion

    #region 频道

    /// <summary>
    ///     取频道列表
    /// </summary>
    /// <param name="input"></param>
    public async Task<List<GetChannelListOutput>> GetChannelList(GetChannelListInput input)
    {
        var result = await
            BaseRequest<GetChannelListInput, List<GetChannelListOutput>>("/api/v1/channel/list", input);

        return result;
    }

    /// <summary>
    ///     取频道信息
    /// </summary>
    /// <param name="input"></param>
    public async Task<GetChannelInfoOutput> GetChannelInfo(GetChannelInfoInput input)
    {
        var result = await
            BaseRequest<GetChannelInfoInput, GetChannelInfoOutput>("/api/v1/channel/info", input);

        return result;
    }

    #endregion

    #region 文字频道

    /// <summary>
    ///     置频道消息发送
    /// </summary>
    /// <param name="input"></param>
    public async Task<SetChannelMessageSendOutput> SetChannelMessageSend<T>(SetChannelMessageSendInput<T> input)
        where T : MessageBodyBase
    {
        var result = await
            BaseRequest<SetChannelMessageSendInput<T>, SetChannelMessageSendOutput>("/api/v1/channel/message/send",
                input);

        return result;
    }

    /// <summary>
    ///     置频道消息编辑
    /// </summary>
    /// <param name="input"></param>
    public async Task<bool> SetChannelMessageEdit<T>(SetChannelMessageEditInput<T> input)
        where T : MessageBodyBase
    {
        var result = await BaseRequest("/api/v1/channel/message/edit", input);

        return result;
    }

    /// <summary>
    ///     置频道消息撤回
    /// </summary>
    /// <param name="input"></param>
    public async Task<bool> SetChannelMessageWithdraw(SetChannelMessageWithdrawInput input)
    {
        var result = await BaseRequest("/api/v1/channel/message/withdraw", input);

        return result;
    }

    /// <summary>
    ///     置频道消息反应
    /// </summary>
    /// <param name="input"></param>
    [Obsolete("该方法已弃用，请使用 SetChannelMessageReactionAdd 和 SetChannelMessageReactionRemove 替代")]
    public async Task<bool> SetChannelMessageReaction(SetChannelMessageReactionInput input)
    {
        var result = await BaseRequest("/api/v1/channel/message/reaction", input);

        return result;
    }

    /// <summary>
    ///     置频道消息反应新增
    /// </summary>
    /// <param name="input"></param>
    public async Task<bool> SetChannelMessageReactionAdd(SetChannelMessageReactionAddInput input)
    {
        var result = await BaseRequest("/api/v1/channel/message/reaction/add", input);

        return result;
    }

    /// <summary>
    ///     置频道消息反应移除
    /// </summary>
    /// <param name="input"></param>
    public async Task<bool> SetChannelMessageReactionRemove(SetChannelMessageReactionRemoveInput input)
    {
        var result = await BaseRequest("/api/v1/channel/message/reaction/remove", input);

        return result;
    }

    #endregion

    #region 身份组

    /// <summary>
    ///     取身份组列表
    /// </summary>
    /// <param name="input"></param>
    public async Task<List<GetRoleListOutput>> GetRoleList(GetRoleListInput input)
    {
        var result = await
            BaseRequest<GetRoleListInput, List<GetRoleListOutput>>("/api/v1/role/list", input);

        return result;
    }

    /// <summary>
    ///     置身份组成员新增
    /// </summary>
    /// <param name="input"></param>
    public async Task<bool> SetRoleMemberAdd(SetRoleMemberAddInput input)
    {
        var result = await BaseRequest("/api/v1/role/member/add", input);

        return result;
    }

    /// <summary>
    ///     置身份组成员移除
    /// </summary>
    /// <param name="input"></param>
    public async Task<bool> SetRoleMemberRemove(SetRoleMemberRemoveInput input)
    {
        var result = await BaseRequest("/api/v1/role/member/remove", input);

        return result;
    }

    #endregion

    #region 成员

    /// <summary>
    ///     取成员列表
    /// </summary>
    /// <param name="input"></param>
    public async Task<GetMemberListOutput> GetMemberList(GetMemberListInput input)
    {
        var result = await
            BaseRequest<GetMemberListInput, GetMemberListOutput>("/api/v1/member/list", input);

        return result;
    }

    /// <summary>
    ///     取成员信息
    /// </summary>
    /// <param name="input"></param>
    public async Task<GetMemberInfoOutput> GetMemberInfo(GetMemberInfoInput input)
    {
        var result = await
            BaseRequest<GetMemberInfoInput, GetMemberInfoOutput>("/api/v1/member/info", input);

        return result;
    }

    /// <summary>
    ///     取成员身份组列表
    /// </summary>
    /// <param name="input"></param>
    public async Task<List<GetMemberRoleListOutput>> GetMemberRoleList(GetMemberRoleListInput input)
    {
        var result = await
            BaseRequest<GetMemberRoleListInput, List<GetMemberRoleListOutput>>("/api/v1/member/role/list", input);

        return result;
    }

    /// <summary>
    ///     取成员邀请信息
    /// </summary>
    /// <param name="input"></param>
    public async Task<GetMemberInvitationInfoOutput> GetMemberInvitationInfo(GetMemberInvitationInfoInput input)
    {
        var result = await
            BaseRequest<GetMemberInvitationInfoInput, GetMemberInvitationInfoOutput>("/api/v1/member/invitation/info",
                input);

        return result;
    }

    /// <summary>
    ///     置成员昵称
    /// </summary>
    /// <param name="input"></param>
    public async Task<bool> SetMemberNick(SetMemberNickInput input)
    {
        var result = await BaseRequest("/api/v1/member/nick/set", input);

        return result;
    }

    /// <summary>
    ///     置成员禁言
    /// </summary>
    /// <param name="input"></param>
    public async Task<bool> SetMemberBan(SetMemberBanInput input)
    {
        var result = await BaseRequest("/api/v1/member/ban/set", input);

        return result;
    }

    #endregion

    #region 数字藏品

    /// <summary>
    ///     取成员高能链数字藏品信息
    /// </summary>
    /// <param name="input"></param>
    public async Task<GetMemberUPowerchainInfoOutput> GetMemberUPowerchainInfo(GetMemberUPowerchainInfoInput input)
    {
        var result = await
            BaseRequest<GetMemberUPowerchainInfoInput, GetMemberUPowerchainInfoOutput>(
                "/api/v1/member/upowerchain/info", input);

        return result;
    }

    /// <summary>
    ///     取成员数字藏品状态
    /// </summary>
    /// <param name="input"></param>
    public async Task<GetMemberNftStatusOutput> GetMemberNftStatus(GetMemberNftStatusInput input)
    {
        var result = await
            BaseRequest<GetMemberNftStatusInput, GetMemberNftStatusOutput>("/api/v1/member/nft/status", input);

        return result;
    }

    #endregion

    #region 基础调用

    /// <summary>
    ///     基础调用（什么也不带）
    /// </summary>
    /// <param name="resource">接口路径</param>
    /// <returns>返回结果</returns>
    public async Task<bool> BaseRequest(string resource)
    {
        var result = await BaseRequest<object, object>(resource, HttpMethod.Post, new object());

        if (result == default)
            return default;

        return result.Status == 0;
    }

    /// <summary>
    ///     基础调用（带返回参数）
    /// </summary>
    /// <typeparam name="TOutput">返回参数类型</typeparam>
    /// <param name="resource">接口路径</param>
    /// <returns>返回结果</returns>
    public async Task<TOutput> BaseRequest<TOutput>(string resource)
        where TOutput : new()
    {
        var result = await BaseRequest<object, TOutput>(resource, HttpMethod.Post, new object());

        if (result == default)
            return default;

        return result.Status == 0 ? result.Data : default;
    }

    /// <summary>
    ///     基础调用（带请求参数）
    /// </summary>
    /// <typeparam name="TInput">请求参数类型</typeparam>
    /// <param name="resource">接口路径</param>
    /// <param name="input">请求数据</param>
    /// <returns>返回结果</returns>
    public async Task<bool> BaseRequest<TInput>(string resource, TInput input)
        where TInput : new()
    {
        var result = await BaseRequest<TInput, object>(resource, HttpMethod.Post, input);

        if (result == default)
            return default;

        return result.Status == 0;
    }

    /// <summary>
    ///     基础调用（带请求参数和返回参数）
    /// </summary>
    /// <typeparam name="TInput">请求参数类型</typeparam>
    /// <typeparam name="TOutput">返回参数类型</typeparam>
    /// <param name="resource">接口路径</param>
    /// <param name="input">请求数据</param>
    /// <returns>返回结果</returns>
    public async Task<TOutput> BaseRequest<TInput, TOutput>(string resource, TInput input)
        where TInput : new()
        where TOutput : new()
    {
        var result = await BaseRequest<TInput, TOutput>(resource, HttpMethod.Post, input);

        if (result == default)
            return default;

        return result.Status == 0 ? result.Data : default;
    }

    /// <summary>
    ///     基础调用
    /// </summary>
    /// <typeparam name="TInput">请求参数类型</typeparam>
    /// <typeparam name="TOutput">返回参数类型</typeparam>
    /// <param name="resource">接口路径</param>
    /// <param name="method">请求方式</param>
    /// <param name="input">请求数据</param>
    /// <returns>返回结果</returns>
    public async Task<OpenApiBaseOutput<TOutput>> BaseRequest<TInput, TOutput>(string resource, HttpMethod method,
        TInput input)
        where TInput : new()
        where TOutput : new()
    {
        HttpContent content;

        var request = new HttpRequestMessage(method, resource);

        if (input is SetResourceUploadInput uploadResourceInput)
        {
            using var form = new MultipartFormDataContent();
            byte[] fileBytes;
            if (Regex.IsMatch(uploadResourceInput.FilePath, "(http|https|ftp)://.*?"))
            {
                var downloadClient = new HttpClient();
                var downloadResponse = await downloadClient.GetAsync(uploadResourceInput.FilePath);
                var successResponse = downloadResponse.EnsureSuccessStatusCode();

                fileBytes = await successResponse.Content.ReadAsByteArrayAsync();
            }
            else
            {
                fileBytes = File.ReadAllBytes(uploadResourceInput.FilePath);
            }

            var fileContent = new ByteArrayContent(fileBytes);
            fileContent.Headers.ContentType = new MediaTypeHeaderValue("multipart/form-data");
            form.Add(fileContent, "file", uploadResourceInput.FilePath);
            content = form;
        }
        else
        {
            content = new StringContent(JsonSerializer.Serialize(input));
        }

        request.Content = content;

        Console.WriteLine($"请求接口：{resource}");
        Console.WriteLine($"请求参数：{JsonSerializer.Serialize(input)}");

        var response = await _httpClient.SendAsync(request);
        if (response.IsSuccessStatusCode is false) throw new HttpRequestException($"Failed, {response.StatusCode}");

        var body = await response.Content.ReadAsStreamAsync();
        var data = await JsonSerializer.DeserializeAsync<OpenApiBaseOutput<TOutput>>(body);

        Console.WriteLine($"返回参数：{response.Content}\n");

        if (data is null) throw new HttpRequestException($"Failed, data is null, {response.StatusCode}");

        if (data.Status != 0) throw new Exception(data.Message);

        return data;
    }

    #endregion
}
