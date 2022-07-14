using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DoDo.Open.Sdk.Models.Events
{
    public class EventSubjectDataBusiness<T> : EventSubjectDataBase
    {
        /// <summary>
        /// 事件ID
        /// </summary>
        [JsonProperty("eventId")]
        public string EventId { get; set; }

        /// <summary>
        /// 事件类型，EventTypeConst.
        /// </summary>
        [JsonProperty("eventType")]
        public string EventType { get; set; }

        /// <summary>
        /// 事件内容，事件类型不同，内容也会不同
        /// </summary>
        [JsonProperty("eventBody")]
        public T EventBody { get; set; }

        /// <summary>
        /// 发送时间戳
        /// </summary>
        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }
    }
}
