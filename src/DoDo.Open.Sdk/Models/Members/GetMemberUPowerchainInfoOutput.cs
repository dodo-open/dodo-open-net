using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DoDo.Open.Sdk.Models.Members
{
    public class GetMemberUPowerchainInfoOutput
    {
        /// <summary>
        /// DoDo号
        /// </summary>
        [JsonProperty("dodoId")]
        public string DodoId { get; set; }

        /// <summary>
        /// 在群昵称
        /// </summary>
        [JsonProperty("nickName")]
        public string NickName { get; set; }

        /// <summary>
        /// 个人昵称
        /// </summary>
        [JsonProperty("personalNickName")]
        public string PersonalNickName { get; set; }

        /// <summary>
        /// 是否拥有该发行方的NFT，0：否，1：是
        /// </summary>
        [JsonProperty("isHaveIssuer")]
        public string IsHaveIssuer { get; set; }

        /// <summary>
        /// 是否拥有该系列的NFT，0：否，1：是
        /// </summary>
        [JsonProperty("isHaveSeries")]
        public string IsHaveSeries { get; set; }

        /// <summary>
        /// 拥有的该系列下NFT数量
        /// </summary>
        [JsonProperty("nftCount")]
        public string NftCount { get; set; }
    }
}
