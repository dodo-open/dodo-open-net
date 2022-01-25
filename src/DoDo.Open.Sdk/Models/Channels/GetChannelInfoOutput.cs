using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DoDo.Open.Sdk.Models.Channels
{
    public class GetChannelInfoOutput
    {
        /// <summary>
        /// 频道号
        /// </summary>
        [JsonProperty("channelId")]
        public string ChannelId { get; set; }

        /// <summary>
        /// 频道名称
        /// </summary>
        [JsonProperty("channelName")]
        public string ChannelName { get; set; }

        /// <summary>
        /// 默认频道标识，0：是，1：否
        /// </summary>
        [JsonProperty("defaultFlag")]
        public int DefaultFlag { get; set; }

        /// <summary>
        /// 所属群号
        /// </summary>
        [JsonProperty("islandId")]
        public string IslandId { get; set; }
    }
}
