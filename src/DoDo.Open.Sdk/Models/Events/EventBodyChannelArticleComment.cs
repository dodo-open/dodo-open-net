using System;
using System.Collections.Generic;
using System.Text;

namespace DoDo.Open.Sdk.Models.Events
{
    public class EventBodyChannelArticleComment : EventBodyChannelBase
    {
        /// <summary>
        /// 帖子ID
        /// </summary>
        public string ArticleId { get; set; }

        /// <summary>
        /// 帖子评论ID
        /// </summary>
        public string CommentId { get; set; }

        /// <summary>
        /// 帖子评论回复ID，为空时：为评论事件，不为空时：为评论回复事件
        /// </summary>
        public string ReplyId { get; set; }

        /// <summary>
        /// 图片列表
        /// </summary>
        public List<string> ImageList { get; set; }

        /// <summary>
        /// 文本内容
        /// </summary>
        public string Content { get; set; }
    }
}
