using System;
using System.Collections.Generic;
using System.Text;

namespace DoDo.Open.Sdk.Models.Events
{
    public class EventBodyChannelArticleEvent : EventBodyChannelBase
    {
        /// <summary>
        /// 帖子ID
        /// </summary>
        public string ArticleId { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

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
