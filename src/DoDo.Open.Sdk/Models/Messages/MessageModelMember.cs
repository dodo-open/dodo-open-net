using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DoDo.Open.Sdk.Models.Messages
{
    public class MessageModelMember
    {
        /// <summary>
        /// 群昵称
        /// </summary>
        [JsonProperty("nickName")]
        public string NickName { get; set; }

        /// <summary>
        /// 等级
        /// </summary>
        [JsonProperty("level")]
        public int Level { get; set; }

        /// <summary>
        /// 在群时间
        /// </summary>
        [JsonProperty("joinTime")]
        public string JoinTime { get; set; }
    }
}
