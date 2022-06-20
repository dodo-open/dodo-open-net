using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
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
using Newtonsoft.Json;
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
        /// 取机器人配置
        /// </summary>
        /// <returns></returns>
        public OpenApiOptions GetBotOptions()
        {
            return _openApiOptions;
        }

        /// <summary>
        /// 取机器人信息
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isThrowException"></param>
        public GetBotInfoOutput GetBotInfo(GetBotInfoInput input,bool isThrowException = false)
        {
            var result = BaseRequest<GetBotInfoInput, GetBotInfoOutput>("/api/v1/bot/info", input, isThrowException);

            return result;
        }

        /// <summary>
        /// 置机器人群退出
        /// </summary>
        /// <param name="input"></param>
        public bool SetBotIslandLeave(SetBotIslandLeaveInput input, bool isThrowException = false)
        {
            var result = BaseRequest<SetBotIslandLeaveInput>("/api/v1/bot/island/leave", input, isThrowException);

            return result;
        }

        #endregion

        #region 群

        /// <summary>
        /// 取群列表
        /// </summary>
        /// <param name="input"></param>
        public List<GetIslandListOutput> GetIslandList(GetIslandListInput input, bool isThrowException = false)
        {
            var result = BaseRequest<GetIslandListInput, List<GetIslandListOutput>>("/api/v1/island/list", input, isThrowException);

            return result;
        }

        /// <summary>
        /// 取群信息
        /// </summary>
        /// <param name="input"></param>
        public GetIslandInfoOutput GetIslandInfo(GetIslandInfoInput input, bool isThrowException = false)
        {
            var result = BaseRequest<GetIslandInfoInput, GetIslandInfoOutput>("/api/v1/island/info", input, isThrowException);

            return result;
        }
        
        #endregion

        #region 频道

        /// <summary>
        /// 取频道列表
        /// </summary>
        /// <param name="input"></param>
        public List<GetChannelListOutput> GetChannelList(GetChannelListInput input, bool isThrowException = false)
        {
            var result = BaseRequest<GetChannelListInput, List<GetChannelListOutput>>("/api/v1/channel/list", input, isThrowException);

            return result;
        }

        /// <summary>
        /// 取频道信息
        /// </summary>
        /// <param name="input"></param>
        public GetChannelInfoOutput GetChannelInfo(GetChannelInfoInput input, bool isThrowException = false)
        {
            var result = BaseRequest<GetChannelInfoInput, GetChannelInfoOutput>("/api/v1/channel/info", input, isThrowException);

            return result;
        }
        
        #endregion

        #region 文字频道
        
        /// <summary>
        /// 置频道消息发送
        /// </summary>
        /// <param name="input"></param>
        public SetChannelMessageSendOutput SetChannelMessageSend<T>(SetChannelMessageSendInput<T> input, bool isThrowException = false)
        where T : MessageBodyBase
        {
            var result = BaseRequest<SetChannelMessageSendInput<T>, SetChannelMessageSendOutput>("/api/v1/channel/message/send", input, isThrowException);

            return result;
        }

        /// <summary>
        /// 置频道消息编辑
        /// </summary>
        /// <param name="input"></param>
        public bool SetChannelMessageEdit<T>(SetChannelMessageEditInput<T> input, bool isThrowException = false)
            where T : MessageBodyBase
        {
            var result = BaseRequest("/api/v1/channel/message/edit", input, isThrowException);

            return result;
        }

        /// <summary>
        /// 置频道消息撤回
        /// </summary>
        /// <param name="input"></param>
        public bool SetChannelMessageWithdraw(SetChannelMessageWithdrawInput input, bool isThrowException = false)
        {
            var result = BaseRequest("/api/v1/channel/message/withdraw", input, isThrowException);

            return result;
        }

        /// <summary>
        /// 置频道消息反应
        /// </summary>
        /// <param name="input"></param>
        [Obsolete("该方法已弃用，请使用 SetChannelMessageReactionAdd 和 SetChannelMessageReactionRemove 替代")]
        public bool SetChannelMessageReaction(SetChannelMessageReactionInput input, bool isThrowException = false)
        {
            var result = BaseRequest("/api/v1/channel/message/reaction", input, isThrowException);

            return result;
        }

        /// <summary>
        /// 置频道消息反应新增
        /// </summary>
        /// <param name="input"></param>
        public bool SetChannelMessageReactionAdd(SetChannelMessageReactionAddInput input, bool isThrowException = false)
        {
            var result = BaseRequest("/api/v1/channel/message/reaction/add", input, isThrowException);

            return result;
        }

        /// <summary>
        /// 置频道消息反应移除
        /// </summary>
        /// <param name="input"></param>
        public bool SetChannelMessageReactionRemove(SetChannelMessageReactionRemoveInput input, bool isThrowException = false)
        {
            var result = BaseRequest("/api/v1/channel/message/reaction/remove", input, isThrowException);

            return result;
        }

        #endregion

        #region 身份组

        /// <summary>
        /// 取身份组列表
        /// </summary>
        /// <param name="input"></param>
        public List<GetRoleListOutput> GetRoleList(GetRoleListInput input, bool isThrowException = false)
        {
            var result = BaseRequest<GetRoleListInput, List<GetRoleListOutput>>("/api/v1/role/list", input, isThrowException);

            return result;
        }

        /// <summary>
        /// 置身份组成员新增
        /// </summary>
        /// <param name="input"></param>
        public bool SetRoleMemberAdd(SetRoleMemberAddInput input, bool isThrowException = false)
        {
            var result = BaseRequest("/api/v1/role/member/add", input, isThrowException);

            return result;
        }

        /// <summary>
        /// 置身份组成员移除
        /// </summary>
        /// <param name="input"></param>
        public bool SetRoleMemberRemove(SetRoleMemberRemoveInput input, bool isThrowException = false)
        {
            var result = BaseRequest("/api/v1/role/member/remove", input, isThrowException);

            return result;
        }

        #endregion

        #region 成员

        /// <summary>
        /// 取成员列表
        /// </summary>
        /// <param name="input"></param>
        public GetMemberListOutput GetMemberList(GetMemberListInput input, bool isThrowException = false)
        {
            var result = BaseRequest<GetMemberListInput, GetMemberListOutput>("/api/v1/member/list", input, isThrowException);

            return result;
        }

        /// <summary>
        /// 取成员信息
        /// </summary>
        /// <param name="input"></param>
        public GetMemberInfoOutput GetMemberInfo(GetMemberInfoInput input, bool isThrowException = false)
        {
            var result = BaseRequest<GetMemberInfoInput, GetMemberInfoOutput>("/api/v1/member/info", input, isThrowException);

            return result;
        }

        /// <summary>
        /// 取成员身份组列表
        /// </summary>
        /// <param name="input"></param>
        public List<GetMemberRoleListOutput> GetMemberRoleList(GetMemberRoleListInput input, bool isThrowException = false)
        {
            var result = BaseRequest<GetMemberRoleListInput, List<GetMemberRoleListOutput>>("/api/v1/member/role/list", input, isThrowException);

            return result;
        }

        /// <summary>
        /// 取成员邀请信息
        /// </summary>
        /// <param name="input"></param>
        public GetMemberInvitationInfoOutput GetMemberInvitationInfo(GetMemberInvitationInfoInput input, bool isThrowException = false)
        {
            var result = BaseRequest<GetMemberInvitationInfoInput, GetMemberInvitationInfoOutput>("/api/v1/member/invitation/info", input, isThrowException);

            return result;
        }

        /// <summary>
        /// 取成员高能链数字藏品信息
        /// </summary>
        /// <param name="input"></param>
        public GetMemberUPowerchainInfoOutput GetMemberUPowerchainInfo(GetMemberUPowerchainInfoInput input, bool isThrowException = false)
        {
            var result = BaseRequest<GetMemberUPowerchainInfoInput, GetMemberUPowerchainInfoOutput>("/api/v1/member/upowerchain/info", input, isThrowException);

            return result;
        }

        /// <summary>
        /// 置成员昵称
        /// </summary>
        /// <param name="input"></param>
        public bool SetMemberNick(SetMemberNickInput input, bool isThrowException = false)
        {
            var result = BaseRequest("/api/v1/member/nick/set", input, isThrowException);

            return result;
        }

        /// <summary>
        /// 置成员禁言
        /// </summary>
        /// <param name="input"></param>
        public bool SetMemberBan(SetMemberBanInput input, bool isThrowException = false)
        {
            var result = BaseRequest("/api/v1/member/ban/set", input, isThrowException);

            return result;
        }

        #endregion

        #region 个人

        /// <summary>
        /// 置个人消息发送
        /// </summary>
        /// <param name="input"></param>
        public SetPersonalMessageSendOutput SetPersonalMessageSend<T>(SetPersonalMessageSendInput<T> input, bool isThrowException = false)
            where T : MessageBodyBase
        {
            var result = BaseRequest<SetPersonalMessageSendInput<T>, SetPersonalMessageSendOutput>("/api/v1/personal/message/send", input, isThrowException);

            return result;
        }

        #endregion

        #region 资源

        /// <summary>
        /// 置资源图片上传
        /// </summary>
        /// <param name="input"></param>
        public SetResourcePictureUploadOutput SetResourcePictureUpload(SetResourceUploadInput input, bool isThrowException = false)
        {
            var result = BaseRequest<SetResourceUploadInput, SetResourcePictureUploadOutput>("/api/v1/resource/picture/upload", input, isThrowException);

            return result;
        }

        #endregion

        #region 事件

        /// <summary>
        /// 取WebSocket连接
        /// </summary>
        /// <param name="input"></param>
        public GetWebSocketConnectionOutput GetWebSocketConnection(GetWebSocketConnectionInput input, bool isThrowException = false)
        {
            var result = BaseRequest<GetWebSocketConnectionInput, GetWebSocketConnectionOutput>("/api/v1/websocket/connection", input, isThrowException);

            return result;
        }

        #endregion

        #region 基础调用

        /// <summary>
        /// 基础调用（什么也不带）
        /// </summary>
        /// <param name="resource">接口路径</param>
        /// <param name="isThrowException">是否抛出异常</param>
        /// <returns>返回结果</returns>
        public bool BaseRequest(string resource, bool isThrowException)
        {
            var result = BaseRequest<object, object>(resource, Method.POST, new object(), isThrowException);

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
        public TOutput BaseRequest<TOutput>(string resource, bool isThrowException)
            where TOutput : new()
        {
            var result = BaseRequest<object, TOutput>(resource, Method.POST, new object(), isThrowException);

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
        public bool BaseRequest<TInput>(string resource, TInput input, bool isThrowException)
            where TInput : new()
        {
            var result = BaseRequest<TInput, object>(resource, Method.POST, input,isThrowException);

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
        public TOutput BaseRequest<TInput, TOutput>(string resource, TInput input, bool isThrowException)
            where TInput : new()
            where TOutput : new()
        {
            var result = BaseRequest<TInput, TOutput>(resource, Method.POST, input,isThrowException);

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
        public OpenApiBaseOutput<TOutput> BaseRequest<TInput, TOutput>(string resource, Method method, TInput input, bool isThrowException)
        where TInput : new()
        where TOutput : new()
        {
            try
            {
                var client = new RestClient(_openApiOptions.BaseApi);
                var request = new RestRequest(resource);

                request.AddHeader("Authorization", $"Bot {_openApiOptions.ClientId}.{_openApiOptions.Token}");

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
                    request.AddJsonBody(JsonConvert.SerializeObject(input));
                }
                
                Console.WriteLine($"请求接口：{resource}");
                Console.WriteLine($"请求参数：{JsonConvert.SerializeObject(input)}");

                var response = client.Execute<OpenApiBaseOutput<TOutput>>(request, method);

                Console.WriteLine($"返回参数：{response.Content}\n");

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