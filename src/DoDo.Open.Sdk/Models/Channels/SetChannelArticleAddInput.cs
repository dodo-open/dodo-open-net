using System;
using System.Collections.Generic;
using System.Text;

namespace DoDo.Open.Sdk.Models.Channels
{
    public class SetChannelArticleAddInput
    {
        /// <summary>
        /// 帖子频道ID
        /// </summary>
        public string ChannelId { get; set; }

        /// <summary>
        /// 标题，60个字符限制
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 内容，10000字符限制，支持菱形语法
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 图片链接，必须是官方的链接，通过上传资源图片接口可获得图片链接
        /// </summary>
        public string ImageUrl { get; set; }
    }
}
