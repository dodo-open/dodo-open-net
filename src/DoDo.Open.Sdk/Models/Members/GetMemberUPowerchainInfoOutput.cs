namespace DoDo.Open.Sdk.Models.Members
{
    public class GetMemberUPowerchainInfoOutput
    {
        /// <summary>
        /// DoDoID
        /// </summary>
        public string DodoSourceId { get; set; }

        /// <summary>
        /// 群昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// DoDo昵称
        /// </summary>
        public string PersonalNickName { get; set; }

        /// <summary>
        /// 是否拥有该发行方的NFT，0：否，1：是
        /// </summary>
        public int IsHaveIssuer { get; set; }

        /// <summary>
        /// 是否拥有该系列的NFT，0：否，1：是
        /// </summary>
        public int IsHaveSeries { get; set; }

        /// <summary>
        /// 拥有的该系列下NFT数量
        /// </summary>
        public int NftCount { get; set; }
    }
}
