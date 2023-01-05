namespace DoDo.Open.Sdk.Models.Gifts
{
    public class GetGiftGrossValueListOutput : OpenApiPageOutput<GetGiftGrossValueListItem>
    {

    }

    public class GetGiftGrossValueListItem
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
        /// 赠礼总值（铃钱）
        /// </summary>
        public decimal GiftTotalAmount { get; set; }
    }
}
