using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DoDo.Open.Sdk.Models.Events
{
    public class EventBodyMemberJoin
    {
        /// <summary>
        /// 来源群号
        /// </summary>
        [JsonProperty("islandId")]
        public string IslandId { get; set; }

        /// <summary>
        /// 来源DoDo号
        /// </summary>
        [JsonProperty("dodoId")]
        public string DodoId { get; set; }

        /// <summary>
        /// 变动时间
        /// </summary>
        [JsonProperty("modifyTime")]
        public string ModifyTime { get; set; }
    }
}
