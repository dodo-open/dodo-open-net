using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DoDo.Open.Sdk.Models.Members
{
    public class GetIslandLevelRankListOutput
    {
        /// <summary>
        /// DoDo号
        /// </summary>
        [JsonProperty("dodoId")]
        public string DodoId { get; set; }

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
        /// 排名，返回前100名
        /// </summary>
        [JsonProperty("rank")]
        public int Rank { get; set; }
    }
}
