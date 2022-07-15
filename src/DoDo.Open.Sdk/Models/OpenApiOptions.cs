using System;

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
        /// 日志回调，可为空
        /// </summary>
        public Action<string> Log { get; set; }
    }
}
