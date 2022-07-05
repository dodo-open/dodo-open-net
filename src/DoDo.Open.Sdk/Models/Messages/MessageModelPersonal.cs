using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DoDo.Open.Sdk.Models.Messages
{
    public class MessageModelPersonal
    {
        /// <summary>
        /// DoDo昵称
        /// </summary>
        [JsonProperty("nickName")]
        public string NickName { get; set; }

        /// <summary>
        /// 个人头像
        /// </summary>
        [JsonProperty("avatarUrl")]
        public string AvatarUrl { get; set; }

        /// <summary>
        /// 个人性别，-1：保密，0：女，1：男
        /// </summary>
        [JsonProperty("sex")]
        public int Sex { get; set; }
    }
}
