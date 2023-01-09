namespace DoDo.Open.Sdk.Models.Events
{
    public class EventBodyIntegralChange
    {
        /// <summary>
        /// 来源群ID
        /// </summary>
        public string IslandSourceId { get; set; }

        /// <summary>
        /// 来源DoDoID
        /// </summary>
        public string DodoSourceId { get; set; }

        /// <summary>
        /// 场景类型，1：签到，2：邀请，3：转账，4：购买商品，5：管理积分，6：退群
        /// </summary>
        public int OperateType { get; set; }

        /// <summary>
        /// 积分
        /// </summary>
        public long Integral { get; set; }
    }
}
