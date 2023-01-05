namespace DoDo.Open.Sdk.Models.Gifts
{
    public class GetGiftListOutput
    {
        /// <summary>
        /// 礼物ID
        /// </summary>
        public string GiftId { get; set; }

        /// <summary>
        /// 礼物数量
        /// </summary>
        public long GiftCount { get; set; }

        /// <summary>
        /// 礼物总价值（铃钱）
        /// </summary>
        public decimal GiftTotalAmount { get; set; }
    }
}
