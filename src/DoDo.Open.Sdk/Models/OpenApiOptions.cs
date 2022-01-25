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
        [JsonProperty("clientId")]
        public string ClientId { get; set; }
        
        /// <summary>
        /// 密钥,切勿泄漏,验证签名使用
        /// </summary>
        [JsonProperty("clientSecret")]
        public string ClientSecret { get; set; }

        /// <summary>
        /// 鉴权token
        /// </summary>
        [JsonProperty("token")]
        public string Token { get; set; }

        /// <summary>
        /// 公钥,后续验证签名使用
        /// </summary>
        [JsonProperty("publicKey")]
        public string PublicKey { get; set; }
    }
}
