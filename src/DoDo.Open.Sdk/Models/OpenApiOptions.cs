using System;
using Newtonsoft.Json;

namespace DoDo.Open.Sdk.Models
{
    public class OpenApiOptions
    {
        /// <summary>
        /// 接口地址
        /// </summary>
        public string BaseApi { get; set; }

        /// <summary>
        /// 机器人唯一标识
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// 机器人鉴权Token
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// 接口回调，可用于日志记录，可以为空
        /// </summary>
        public Action<OpenApiCallback> Callback { get; set; }
    }
}
