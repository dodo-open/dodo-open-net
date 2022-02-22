using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DoDo.Open.Sdk.Models.WebSockets
{
    public class GetWebSocketConnectionOutput
    {
        /// <summary>
        /// 连接节点
        /// </summary>
        [JsonProperty("endpoint")]
        public string Endpoint { get; set; }
    }
}
