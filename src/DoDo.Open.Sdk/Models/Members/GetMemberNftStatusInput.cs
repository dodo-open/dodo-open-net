using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DoDo.Open.Sdk.Models.Members
{
    public class GetMemberNftStatusInput
    {
        /// <summary>
        /// 群号
        /// </summary>
        [JsonProperty("islandId")]
        public string IslandId { get; set; }

        /// <summary>
        /// DoDo号
        /// </summary>
        [JsonProperty("dodoId")]
        public string DoDoId { get; set; }

        /// <summary>
        /// 数藏平台，upower：高能链，ubanquan：优版权，metamask：Opensea
        /// </summary>
        [JsonProperty("platform")]
        public string Platform { get; set; }

        /// <summary>
        /// 发行商
        /// </summary>
        [JsonProperty("issuer")]
        public string Issuer { get; set; }

        /// <summary>
        /// 系列
        /// </summary>
        [JsonProperty("series")]
        public string Series { get; set; }
    }
}
