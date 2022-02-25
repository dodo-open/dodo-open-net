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
        public GetBotInfoOutput GetBotInfo(GetBotInfoInput input)
        {
            var result = BaseRequest<GetBotInfoInput, GetBotInfoOutput>("/api/v1/bot/info", input);

            return result;
        }

        /// <summary>
        /// 置机器人群退出
        /// </summary>
        /// <param name="input"></param>
        public bool SetBotIslandLeave(SetBotIslandLeaveInput input)
        {
            var result = BaseRequest<SetBotIslandLeaveInput>("/api/v1/bot/island/leave", input);

            return result;
        }

        #endregion

        #region 群

        /// <summary>
        /// 取群列表
        /// </summary>
        /// <param name="input"></param>
        public List<GetIslandListOutput> GetIslandList(GetIslandListInput input)
        {
            var result = BaseRequest<GetIslandListInput, List<GetIslandListOutput>>("/api/v1/island/list", input);

            return result;
        }

        /// <summary>
        /// 取群信息
        /// </summary>
        /// <param name="input"></param>
        public GetIslandInfoOutput GetIslandInfo(GetIslandInfoInput input)
        {
            var result = BaseRequest<GetIslandInfoInput, GetIslandInfoOutput>("/api/v1/island/info", input);

            return result;
        }

        /// <summary>
        /// 取群成员列表
        /// </summary>
        /// <param name="input"></param>
        public GetIslandMemberListOutput GetIslandMemberList(GetIslandMemberListInput input)
        {
            var result = BaseRequest<GetIslandMemberListInput, GetIslandMemberListOutput>("/api/v1/island/member/list", input);

            return result;
        }

        #endregion

        #region 频道

        /// <summary>
        /// 取频道列表
        /// </summary>
        /// <param name="input"></param>
        public List<GetChannelListOutput> GetChannelList(GetChannelListInput input)
        {
            var result = BaseRequest<GetChannelListInput, List<GetChannelListOutput>>("/api/v1/channel/list", input);

            return result;
        }

        /// <summary>
        /// 取频道信息
        /// </summary>
        /// <param name="input"></param>
        public GetChannelInfoOutput GetChannelInfo(GetChannelInfoInput input)
        {
            var result = BaseRequest<GetChannelInfoInput, GetChannelInfoOutput>("/api/v1/channel/info", input);

            return result;
        }

        /// <summary>
        /// 置频道消息发送
        /// </summary>
        /// <param name="input"></param>
        public SetChannelMessageSendOutput SetChannelMessageSend<T>(SetChannelMessageSendInput<T> input)
        where T : MessageBodyBase
        {
            var result = BaseRequest<SetChannelMessageSendInput<T>, SetChannelMessageSendOutput>("/api/v1/channel/message/send", input);

            return result;
        }

        /// <summary>
        /// 置频道消息编辑
        /// </summary>
        /// <param name="input"></param>
        public SetChannelMessageEditOutput SetChannelMessageModify<T>(SetChannelMessageEditInput<T> input)
            where T : MessageBodyBase
        {
            var result = BaseRequest<SetChannelMessageEditInput<T>, SetChannelMessageEditOutput>("/api/v1/channel/message/edit", input);

            return result;
        }

        /// <summary>
        /// 置频道消息撤回
        /// </summary>
        /// <param name="input"></param>
        public bool SetChannelMessageWithdraw(SetChannelMessageWithdrawInput input)
        {
            var result = BaseRequest("/api/v1/channel/message/withdraw", input);

            return result;
        }

        #endregion

        #region 身份组

        /// <summary>
        /// 取身份组列表
        /// </summary>
        /// <param name="input"></param>
        public List<GetRoleListOutput> GetRoleList(GetRoleListInput input)
        {
            var result = BaseRequest<GetRoleListInput, List<GetRoleListOutput>>("/api/v1/role/list", input);

            return result;
        }

        /// <summary>
        /// 置身份组成员新增
        /// </summary>
        /// <param name="input"></param>
        public bool SetRoleMemberAdd(SetRoleMemberAddInput input)
        {
            var result = BaseRequest("/api/v1/role/member/add", input);

            return result;
        }

        /// <summary>
        /// 置身份组成员移除
        /// </summary>
        /// <param name="input"></param>
        public bool SetRoleMemberRemove(SetRoleMemberRemoveInput input)
        {
            var result = BaseRequest("/api/v1/role/member/remove", input);

            return result;
        }

        #endregion

        #region 成员

        /// <summary>
        /// 取成员身份组列表
        /// </summary>
        /// <param name="input"></param>
        public List<GetMemberRoleListOutput> GetMemberRoleList(GetMemberRoleListInput input)
        {
            var result = BaseRequest<GetMemberRoleListInput, List<GetMemberRoleListOutput>>("/api/v1/member/role/list", input);

            return result;
        }

        /// <summary>
        /// 取成员信息
        /// </summary>
        /// <param name="input"></param>
        public GetMemberInfoOutput GetMemberInfo(GetMemberInfoInput input)
        {
            var result = BaseRequest<GetMemberInfoInput, GetMemberInfoOutput>("/api/v1/member/info", input);

            return result;
        }

        /// <summary>
        /// 置成员昵称
        /// </summary>
        /// <param name="input"></param>
        public bool SetMemberNick(SetMemberNickInput input)
        {
            var result = BaseRequest("/api/v1/member/nick/set", input);

            return result;
        }

        /// <summary>
        /// 置成员禁言
        /// </summary>
        /// <param name="input"></param>
        public bool SetMemberBan(SetMemberBanInput input)
        {
            var result = BaseRequest("/api/v1/member/ban/set", input);

            return result;
        }

        #endregion

        #region 个人

        /// <summary>
        /// 置个人消息发送
        /// </summary>
        /// <param name="input"></param>
        public SetPersonalMessageSendOutput SetPersonalMessageSend<T>(SetPersonalMessageSendInput<T> input)
            where T : MessageBodyBase
        {
            var result = BaseRequest<SetPersonalMessageSendInput<T>, SetPersonalMessageSendOutput>("/api/v1/personal/message/send", input);

            return result;
        }

        #endregion

        #region 资源

        /// <summary>
        /// 置资源图片上传接口
        /// </summary>
        /// <param name="input"></param>
        public SetResourcePictureUploadOutput UploadResourcePicture(SetResourceUploadInput input)
        {
            var result = BaseRequest<SetResourceUploadInput, SetResourcePictureUploadOutput>("/api/v1/resource/picture/upload", input);

            return result;
        }

        #endregion

        #region 事件

        /// <summary>
        /// 取WebSocket连接
        /// </summary>
        /// <param name="input"></param>
        public GetWebSocketConnectionOutput GetWebSocketConnection(GetWebSocketConnectionInput input)
        {
            var result = BaseRequest<GetWebSocketConnectionInput, GetWebSocketConnectionOutput>("/api/v1/websocket/connection", input);

            return result;
        }

        #endregion

        #region 基础调用

        /// <summary>
        /// 基础调用（什么也不带）
        /// </summary>
        /// <param name="resource">接口路径</param>
        /// <returns>返回结果</returns>
        public bool BaseRequest(string resource)
        {
            var result = BaseRequest<object, object>(resource, Method.POST, new object());

            if (result == default)
                return default;

            return result.Status == 0;
        }

        /// <summary>
        /// 基础调用（带返回参数）
        /// </summary>
        /// <typeparam name="TOutput">返回参数类型</typeparam>
        /// <param name="resource">接口路径</param>
        /// <returns>返回结果</returns>
        public TOutput BaseRequest<TOutput>(string resource)
            where TOutput : new()
        {
            var result = BaseRequest<object, TOutput>(resource, Method.POST, new object());

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
        /// <returns>返回结果</returns>
        public bool BaseRequest<TInput>(string resource, TInput input)
            where TInput : new()
        {
            var result = BaseRequest<TInput, object>(resource, Method.POST, input);

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
        /// <returns>返回结果</returns>
        public TOutput BaseRequest<TInput, TOutput>(string resource, TInput input)
            where TInput : new()
            where TOutput : new()
        {
            var result = BaseRequest<TInput, TOutput>(resource, Method.POST, input);

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
        /// <returns>返回结果</returns>
        public OpenApiBaseOutput<TOutput> BaseRequest<TInput, TOutput>(string resource, Method method, TInput input)
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

                return response.Data;
            }
            catch (Exception e)
            {
                return default;
            }

        }

        #endregion

    }
}