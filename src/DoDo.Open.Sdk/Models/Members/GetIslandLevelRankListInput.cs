using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DoDo.Open.Sdk.Models.Members
{
    public class GetIslandLevelRankListInput
    {
        /// <summary>
        /// 群号
        /// </summary>
        [JsonProperty("islandId")]
        public string IslandId { get; set; }
    }
}
