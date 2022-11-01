namespace DoDo.Open.Sdk.Models.Members
{
    public class GetMemberUPowerchainInfoInput
    {
        /// <summary>
        /// 群ID
        /// </summary>
        public string IslandSourceId { get; set; }

        /// <summary>
        /// DoDoID
        /// </summary>
        public string DodoSourceId { get; set; }

        /// <summary>
        /// 发行商
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// 系列
        /// </summary>
        public string Series { get; set; }
    }
}
