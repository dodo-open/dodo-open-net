namespace DoDo.Open.Sdk.Models.Events
{
    public class EventBodyMemberJoin : EventBodyBase
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
        /// 变动时间
        /// </summary>
        public string ModifyTime { get; set; }
    }
}
