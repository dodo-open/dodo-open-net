using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Runtime.InteropServices.ComTypes;
using DoDo.Open.Sdk.Models;
using DoDo.Open.Sdk.Models.Bots;
using DoDo.Open.Sdk.Models.Channels;
using DoDo.Open.Sdk.Models.Islands;
using DoDo.Open.Sdk.Models.Members;
using DoDo.Open.Sdk.Models.Messages;
using DoDo.Open.Sdk.Models.Resources;
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
        public SendChannelMessageOutput SendChannelMessage<T>(SendChannelMessageInput<T> input)
        where T : MessageBase
        {
            var result = BaseRequest<SendChannelMessageInput<T>, SendChannelMessageOutput>("/api/v1/channel/message/send", input);

            return result;
        }

        /// <summary>
        /// 置频道消息撤回
        /// </summary>
        /// <param name="input"></param>
        public bool WithdrawChannelMessage(WithdrawChannelMessageInput input)
        {
            var result = BaseRequest("/api/v1/channel/message/withdraw", input);

            return result;
        }

        #endregion

        #region 成员

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
        /// 置成员禁言
        /// </summary>
        /// <param name="input"></param>
        public bool SetMemberBan(SetMemberBanInput input)
        {
            var result = BaseRequest("/api/v1/member/ban/set", input);

            return result;
        }

        #endregion

        #region 资源

        /// <summary>
        /// 置资源图片上传接口
        /// </summary>
        /// <param name="input"></param>
        public UploadResourcePictureOutput UploadResourcePicture(UploadResourcePictureInput input)
        {
            var result = BaseRequest<UploadResourcePictureInput, UploadResourcePictureOutput>("/api/v1/resource/picture/upload", input, "multipart/form-data");

            return result;
        }

        #endregion

        #region WebSocket

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
        /// <param name="contentType">请求格式</param>
        /// <returns>返回结果</returns>
        public bool BaseRequest(string resource, string contentType = "application/json")
        {
            var result = BaseRequest<object, object>(resource, Method.POST, new object(), contentType);

            if (result == default)
                return default;

            return result.Status == 0;
        }

        /// <summary>
        /// 基础调用（带返回参数）
        /// </summary>
        /// <typeparam name="TOutput">返回参数类型</typeparam>
        /// <param name="resource">接口路径</param>
        /// <param name="contentType">请求格式</param>
        /// <returns>返回结果</returns>
        public TOutput BaseRequest<TOutput>(string resource, string contentType = "application/json")
            where TOutput : new()
        {
            var result = BaseRequest<object, TOutput>(resource, Method.POST, new object(), contentType);

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
        /// <param name="contentType">请求格式</param>
        /// <returns>返回结果</returns>
        public bool BaseRequest<TInput>(string resource, TInput input, string contentType = "application/json")
            where TInput : new()
        {
            var result = BaseRequest<TInput, object>(resource, Method.POST, input, contentType);

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
        /// <param name="contentType">请求格式</param>
        /// <returns>返回结果</returns>
        public TOutput BaseRequest<TInput, TOutput>(string resource, TInput input, string contentType = "application/json")
            where TInput : new()
            where TOutput : new()
        {
            var result = BaseRequest<TInput, TOutput>(resource, Method.POST, input, contentType);

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
        /// <param name="contentType">请求格式</param>
        /// <returns>返回结果</returns>
        public OpenApiBaseOutput<TOutput> BaseRequest<TInput, TOutput>(string resource, Method method, TInput input, string contentType = "application/json")
        where TInput : new()
        where TOutput : new()
        {
            try
            {
                var client = new RestClient(_openApiOptions.BaseApi);
                var request = new RestRequest(resource);

                request.AddHeader("Authorization", $"Bot {_openApiOptions.ClientId}.{_openApiOptions.Token}");

                if (contentType == "multipart/form-data")
                {
                    var fields = input.GetType().GetProperties();

                    foreach (var propertyInfo in fields)
                    {
                        if (propertyInfo.PropertyType.Name == "Byte[]")
                        {
                            request.AddFileBytes(propertyInfo.Name.ToLower(),
                                (byte[]) propertyInfo.GetValue(input) ?? Array.Empty<byte>(),
                                propertyInfo.Name);
                        }
                        else
                        {
                            request.AddParameter(propertyInfo.Name.ToLower(), propertyInfo.GetValue(input) ?? "");
                        }
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