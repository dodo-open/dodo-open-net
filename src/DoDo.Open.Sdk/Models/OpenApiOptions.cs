using Newtonsoft.Json;

namespace DoDo.Open.Sdk.Models
{
    public class OpenApiOptions
    {
        /// <summary>
        /// BaseApi地址
        /// </summary>
        public string BaseApi { get; set; }

        /// <summary>
        /// 机器人唯一标识
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// 鉴权token
        /// </summary>
        public string Token { get; set; }
    }
}
