namespace DoDo.Open.Sdk.Models.Members
{
    public class SetMemberBanAddInput
    {
        /// <summary>
        /// 群号
        /// </summary>
        public string IslandId { get; set; }

        /// <summary>
        /// DoDo号
        /// </summary>
        public string DodoId { get; set; }

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
