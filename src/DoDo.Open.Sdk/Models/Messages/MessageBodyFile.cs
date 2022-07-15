namespace DoDo.Open.Sdk.Models.Messages
{
    public class MessageBodyFile : MessageBodyBase
    {
        /// <summary>
        /// 文件链接
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 文件名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 文件大小
        /// </summary>
        public long? Size { get; set; }
    }
}
