namespace DoDo.Open.Sdk.Models.Gifts
{
    public class GetGiftMemberListOutput : OpenApiPageOutput<GetGiftMemberListItem>
    {
    }

    public class GetGiftMemberListItem
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
        /// 礼物数量
        /// </summary>
        public long GiftCount { get; set; }
    }
}
