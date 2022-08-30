namespace DoDo.Open.Sdk.Models.Messages
{
    public class MessageBodyCard : MessageBodyBase
    {
        /// <summary>
        /// 附加文本，支持Markdown语法、菱形语法
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 卡片，限制10000个字符，支持Markdown语法，不支持菱形语法
        /// </summary>
        public MessageModelCard Card { get; set; }
    }
}
