using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DoDo.Open.Sdk.Models.Events
{
    public class EventSubjectOutput<T>
    where T : EventSubjectDataBase
    {
        /// <summary>
        /// 数据类型，0：业务数据
        /// </summary>
        [JsonProperty("type")]
        public int Type { get; set; }

        /// <summary>
        /// 数据内容
        /// </summary>
        [JsonProperty("data")]
        public T Data { get; set; }
    }
}
