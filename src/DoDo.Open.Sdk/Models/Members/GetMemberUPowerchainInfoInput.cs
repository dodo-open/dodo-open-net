namespace DoDo.Open.Sdk.Models.Members
{
    public class GetMemberUPowerchainInfoInput
    {
        /// <summary>
        /// 群号
        /// </summary>
        public string IslandId { get; set; }

        /// <summary>
        /// DoDo号
        /// </summary>
        public string DodoId { get; set; }

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
