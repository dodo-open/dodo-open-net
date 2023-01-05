using DoDo.Open.Sdk.Models.Messages;
namespace DoDo.Open.Sdk.Models.Events
{
    public class EventBodyGiftSend : EventBodyBase
    {
        /// <summary>
        /// 来源群ID
        /// </summary>
        public string IslandSourceId { get; set; }

        /// <summary>
        /// 来源频道ID
        /// </summary>
        public string ChannelId { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderNo { get; set; }

        /// <summary>
        /// 内容类型，1：消息，2：帖子
        /// </summary>
        public int TargetType { get; set; }

        /// <summary>
        /// 内容ID
        /// </summary>
        public string TargetId { get; set; }

        /// <summary>
        /// 礼物总价值（铃钱）
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// 礼物信息
        /// </summary>
        public MessageModelGift Gift { get; set; }

        /// <summary>
        /// 群分成（百分比）
        /// </summary>
        public decimal IslandRatio { get; set; }

        /// <summary>
        /// 群收入（里程）
        /// </summary>
        public decimal IslandIncome { get; set; }

        /// <summary>
        /// 赠礼人DoDoID
        /// </summary>
        public string DodoSourceId { get; set; }

        /// <summary>
        /// 赠礼人群昵称
        /// </summary>
        public string DodoIslandNickName { get; set; }

        /// <summary>
        /// 被赠礼人DoDoID
        /// </summary>
        public string ToDodoSourceId { get; set; }

        /// <summary>
        /// 被赠礼人群昵称
        /// </summary>
        public string ToDodoIslandNickName { get; set; }

        /// <summary>
        /// 被赠礼人分成（百分比）
        /// </summary>
        public decimal ToDodoRatio { get; set; }

        /// <summary>
        /// 被赠礼人收入（里程）
        /// </summary>
        public decimal ToDodoIncome { get; set; }
    }
}
