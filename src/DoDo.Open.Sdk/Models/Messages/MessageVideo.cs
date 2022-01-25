using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DoDo.Open.Sdk.Models.Messages
{
    public class MessageVideo: MessageBase
    {
        /// <summary>
        /// 视频链接
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// 封面链接
        /// </summary>
        [JsonProperty("coverUrl")]
        public string CoverUrl { get; set; }

        /// <summary>
        /// 视频时长
        /// </summary>
        [JsonProperty("duration")]
        public long? Duration { get; set; }

        /// <summary>
        /// 视频尺寸
        /// </summary>
        [JsonProperty("size")]
        public long? Size { get; set; }
    }
}
