using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DoDo.Open.Sdk.Models.Channels
{
    public class GetChannelInfoInput
    {
        /// <summary>
        /// 频道ID
        /// </summary>
        [JsonProperty("channelId")]
        public string ChannelId { get; set; }
    }
}
