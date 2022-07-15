using System.Text.Json.Serialization;

namespace DoDo.Open.Sdk.Models.Messages
{
    public class MessageModelPersonal
    {
        /// <summary>
        /// DoDo昵称
        /// </summary>
        [JsonPropertyName("nickName")]
        public string NickName { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        [JsonPropertyName("avatarUrl")]
        public string AvatarUrl { get; set; }

        /// <summary>
        /// 性别，-1：保密，0：女，1：男
        /// </summary>
        [JsonPropertyName("sex")]
        public int Sex { get; set; }
    }
}
