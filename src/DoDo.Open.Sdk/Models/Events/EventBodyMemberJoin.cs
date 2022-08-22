namespace DoDo.Open.Sdk.Models.Events
{
    public class EventBodyMemberJoin : EventBodyBase
    {
        /// <summary>
        /// 来源群号
        /// </summary>
        public string IslandId { get; set; }

        /// <summary>
        /// 来源DoDo号
        /// </summary>
        public string DodoId { get; set; }

        /// <summary>
        /// 变动时间
        /// </summary>
        public string ModifyTime { get; set; }
    }
}
