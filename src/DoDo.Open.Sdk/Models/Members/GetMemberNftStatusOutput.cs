using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DoDo.Open.Sdk.Models.Members
{
    public class GetMemberNftStatusOutput
    {
        /// <summary>
        /// 是否已绑定该数藏平台，0：否，1：是
        /// </summary>
        [JsonProperty("isBandPlatform")]
        public int IsBandPlatform { get; set; }

        /// <summary>
        /// 是否拥有该发行方的NFT，0：否，1：是
        /// </summary>
        [JsonProperty("isHaveIssuer")]
        public int IsHaveIssuer { get; set; }

        /// <summary>
        /// 是否拥有该系列的NFT，0：否，1：是
        /// </summary>
        [JsonProperty("isHaveSeries")]
        public int IsHaveSeries { get; set; }
    }
}
