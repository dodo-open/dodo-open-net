﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DoDo.Open.Sdk.Models.Channels
{
    public class GetChannelListInput
    {
        /// <summary>
        /// 群号
        /// </summary>
        [JsonProperty("islandId")]
        public string IslandId { get; set; }
    }
}
