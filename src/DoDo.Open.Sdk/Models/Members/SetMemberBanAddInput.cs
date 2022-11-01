namespace DoDo.Open.Sdk.Models.Members
{
    public class SetMemberBanAddInput
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
        /// 通知频道ID
        /// </summary>
        public string NoticeChannelId { get; set; }

        /// <summary>
        /// 封禁理由
        /// </summary>
        public string Reason { get; set; }
    }
}
