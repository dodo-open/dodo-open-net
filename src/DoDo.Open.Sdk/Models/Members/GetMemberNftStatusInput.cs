namespace DoDo.Open.Sdk.Models.Members
{
    public class GetMemberNftStatusInput
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
        /// 数藏平台，upower：高能链，ubanquan：优版权，metamask：Opensea
        /// </summary>
        public string Platform { get; set; }

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
