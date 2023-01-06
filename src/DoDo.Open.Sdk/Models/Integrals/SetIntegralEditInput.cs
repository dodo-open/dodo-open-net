namespace DoDo.Open.Sdk.Models.Integrals
{
    public class SetIntegralEditInput
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
        /// 管理类型，1：发放积分，2：扣除积分
        /// </summary>
        public int OperateType { get; set; }

        /// <summary>
        /// 积分
        /// </summary>
        public decimal Integral { get; set; }
    }
}
