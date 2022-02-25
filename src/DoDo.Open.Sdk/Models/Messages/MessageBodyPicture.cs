using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DoDo.Open.Sdk.Models.Messages
{
    public class MessageBodyPicture : MessageBodyBase
    {
        /// <summary>
        /// 图片链接
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// 图片宽度
        /// </summary>
        [JsonProperty("width")]
        public int? Width { get; set; }

        /// <summary>
        /// 图片高度
        /// </summary>
        [JsonProperty("height")]
        public int? Height { get; set; }

        /// <summary>
        /// 是否原图，0：压缩图，1：原图
        /// </summary>
        [JsonProperty("isOriginal")]
        public int? IsOriginal { get; set; }
    }
}
