using System.Collections.Generic;

namespace DoDo.Open.Sdk.Models.Events
{
    public class EventBodyGoodsPurchase
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
        /// 订单号
        /// </summary>
        public string OrderNo { get; set; }

        /// <summary>
        /// 商品类型，1：身份组，2：自定义商品
        /// </summary>
        public int GoodsType { get; set; }

        /// <summary>
        /// 商品ID
        /// </summary>
        public string GoodsId { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string GoodsName { get; set; }

        /// <summary>
        /// 商品图片列表
        /// </summary>
        public List<string> GoodsImageList { get; set; }
    }
}
