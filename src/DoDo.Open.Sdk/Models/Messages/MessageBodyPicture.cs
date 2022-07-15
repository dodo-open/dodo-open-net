namespace DoDo.Open.Sdk.Models.Messages
{
    public class MessageBodyPicture : MessageBodyBase
    {
        /// <summary>
        /// 图片链接
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 图片宽度
        /// </summary>
        public int? Width { get; set; }

        /// <summary>
        /// 图片高度
        /// </summary>
        public int? Height { get; set; }

        /// <summary>
        /// 是否原图，0：压缩图，1：原图
        /// </summary>
        public int? IsOriginal { get; set; }
    }
}
