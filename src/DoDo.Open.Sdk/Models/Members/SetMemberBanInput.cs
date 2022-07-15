namespace DoDo.Open.Sdk.Models.Members
{
    public class SetMemberBanInput
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
        /// 禁言时长（秒），最长7天
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// 禁言理由
        /// </summary>
        public string Reason { get; set; }
    }
}
