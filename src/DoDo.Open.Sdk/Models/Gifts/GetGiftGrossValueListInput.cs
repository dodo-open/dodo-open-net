namespace DoDo.Open.Sdk.Models.Gifts
{
    public class GetGiftGrossValueListInput : OpenApiPageInput
    {
        /// <summary>
        /// 内容类型，1：消息，2：帖子
        /// </summary>
        public int TargetType { get; set; }

        /// <summary>
        /// 内容ID
        /// </summary>
        public string TargetId { get; set; }
    }
}
