namespace DoDo.Open.Sdk.Models.Messages
{
    public class MessageBodyVideo: MessageBodyBase
    {
        /// <summary>
        /// 视频链接
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 封面链接
        /// </summary>
        public string CoverUrl { get; set; }

        /// <summary>
        /// 视频时长
        /// </summary>
        public long? Duration { get; set; }

        /// <summary>
        /// 视频大小
        /// </summary>
        public long? Size { get; set; }
    }
}
