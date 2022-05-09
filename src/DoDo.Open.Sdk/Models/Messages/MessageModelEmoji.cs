using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DoDo.Open.Sdk.Models.Messages
{
    public class MessageModelEmoji
    {
        /// <summary>
        /// 表情类型，1：Emoji
        /// </summary>
        [JsonProperty("type")]
        public int Type { get; set; }

        /// <summary>
        /// 表情ID
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
