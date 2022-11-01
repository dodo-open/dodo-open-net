namespace DoDo.Open.Sdk.Models.Messages
{
    public class MessageModelReference
    {
        /// <summary>
        /// 被回复消息ID
        /// </summary>
        public string MessageId { get; set; }

        /// <summary>
        /// 被回复者DoDoID
        /// </summary>
        public string DodoSourceId { get; set; }

        /// <summary>
        /// 被回复者群昵称
        /// </summary>
        public string NickName { get; set; }
    }
}
