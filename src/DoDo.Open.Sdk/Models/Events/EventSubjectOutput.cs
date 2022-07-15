namespace DoDo.Open.Sdk.Models.Events
{
    public class EventSubjectOutput<T>
    where T : EventSubjectDataBase
    {
        /// <summary>
        /// 数据类型，0：业务数据
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 数据内容
        /// </summary>
        public T Data { get; set; }
    }
}
