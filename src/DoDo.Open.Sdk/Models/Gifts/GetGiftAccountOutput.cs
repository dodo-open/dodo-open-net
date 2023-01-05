namespace DoDo.Open.Sdk.Models.Gifts
{
    public class GetGiftAccountOutput
    {
        /// <summary>
        /// 总收入（里程）
        /// </summary>
        public decimal TotalIncome { get; set; }

        /// <summary>
        /// 待结算收入（里程）
        /// </summary>
        public decimal SettlableIncome { get; set; }

        /// <summary>
        /// 可转账收入（里程）
        /// </summary>
        public decimal TransferableIncome { get; set; }
    }
}
