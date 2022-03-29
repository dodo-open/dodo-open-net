using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DoDo.Open.Sdk.Models.Events
{
    public class EventBodyMemberLeave
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
        /// 退出类型，1：主动，2：被踢
        /// </summary>
        [JsonProperty("leaveType")]
        public int LeaveType { get; set; }

        /// <summary>
        /// 操作者DoDo号（执行踢出操作的人）
        /// </summary>
        [JsonProperty("operateDoDoId")]
        public string OperateDoDoId { get; set; }

        /// <summary>
        /// 变动时间
        /// </summary>
        [JsonProperty("modifyTime")]
        public string ModifyTime { get; set; }
    }
}
