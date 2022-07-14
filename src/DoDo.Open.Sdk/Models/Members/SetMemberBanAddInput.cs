using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DoDo.Open.Sdk.Models.Members
{
    public class SetMemberBanAddInput
    {
        /// <summary>
        /// 群号
        /// </summary>
        [JsonProperty("islandId")]
        public string IslandId { get; set; }

        /// <summary>
        /// DoDo号
        /// </summary>
        [JsonProperty("dodoId")]
        public string DodoId { get; set; }

        /// <summary>
        /// 通知频道ID
        /// </summary>
        [JsonProperty("noticeChannelId")]
        public string NoticeChannelId { get; set; }

        /// <summary>
        /// 封禁理由
        /// </summary>
        [JsonProperty("reason")]
        public string Reason { get; set; }
    }
}
