namespace DoDo.Open.Sdk.Models.Events
{
    public class EventSubjectDataBusiness<T> : EventSubjectDataBase
    {
        /// <summary>
        /// 事件ID
        /// </summary>
        public string EventId { get; set; }

        /// <summary>
        /// 事件类型，EventTypeConst.
        /// </summary>
        public string EventType { get; set; }

        /// <summary>
        /// 事件内容，事件类型不同，内容也会不同
        /// </summary>
        public T EventBody { get; set; }

        /// <summary>
        /// 发送时间戳
        /// </summary>
        public long Timestamp { get; set; }
    }
}
