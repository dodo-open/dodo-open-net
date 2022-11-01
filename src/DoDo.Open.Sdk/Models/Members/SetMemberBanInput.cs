namespace DoDo.Open.Sdk.Models.Members
{
    public class SetMemberBanInput
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
        /// 禁言时长（秒），最长7天
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// 禁言理由
        /// </summary>
        public string Reason { get; set; }
    }
}
