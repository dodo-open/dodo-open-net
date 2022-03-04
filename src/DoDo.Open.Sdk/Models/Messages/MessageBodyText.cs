using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DoDo.Open.Sdk.Models.Messages
{
    public class MessageBodyText: MessageBodyBase
    {
        /// <summary>
        /// 文本内容
        /// </summary>
        [JsonProperty("content")]
        public string Content { get; set; }
    }
}
