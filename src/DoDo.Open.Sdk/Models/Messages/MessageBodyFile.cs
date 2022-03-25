using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DoDo.Open.Sdk.Models.Messages
{
    public class MessageBodyFile : MessageBodyBase
    {
        /// <summary>
        /// 文件链接
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// 文件名称
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 文件大小
        /// </summary>
        [JsonProperty("size")]
        public long? Size { get; set; }
    }
}
