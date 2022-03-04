using Newtonsoft.Json;

namespace DoDo.Open.Sdk.Models.Bots
{
    public class GetBotInfoOutput
    {
        /// <summary>
        /// 机器人唯一标识
        /// </summary>
        [JsonProperty("clientId")]
        public string ClientId { get; set; }

        /// <summary>
        /// 机器人DoDo号
        /// </summary>
        [JsonProperty("dodoId")]
        public string DodoId { get; set; }

        /// <summary>
        /// 机器人昵称
        /// </summary>
        [JsonProperty("nickName")]
        public string NickName { get; set; }

        /// <summary>
        /// 机器人头像
        /// </summary>
        [JsonProperty("avatarUrl")]
        public string AvatarUrl { get; set; }
    }
}
