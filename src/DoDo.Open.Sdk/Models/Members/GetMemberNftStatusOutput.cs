namespace DoDo.Open.Sdk.Models.Members
{
    public class GetMemberNftStatusOutput
    {
        /// <summary>
        /// 是否已绑定该数藏平台，0：否，1：是
        /// </summary>
        public int IsBandPlatform { get; set; }

        /// <summary>
        /// 是否拥有该发行方的NFT，0：否，1：是
        /// </summary>
        public int IsHaveIssuer { get; set; }

        /// <summary>
        /// 是否拥有该系列的NFT，0：否，1：是
        /// </summary>
        public int IsHaveSeries { get; set; }
    }
}
