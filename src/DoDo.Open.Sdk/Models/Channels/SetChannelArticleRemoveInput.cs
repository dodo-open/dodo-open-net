using System;
using System.Collections.Generic;
using System.Text;

namespace DoDo.Open.Sdk.Models.Channels
{
    public class SetChannelArticleRemoveInput
    {
        /// <summary>
        /// 帖子频道ID
        /// </summary>
        public string ChannelId { get; set; }

        /// <summary>
        /// 类型，1：帖子，2：帖子评论，3：帖子评论回复
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// ID
        /// </summary>
        public string Id { get; set; }
    }
}
