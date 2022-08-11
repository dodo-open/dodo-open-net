using System;
using System.Collections.Generic;
using System.Text;

namespace DoDo.Open.Sdk.Models.Messages
{
    public class MessageBodyCard : MessageBodyBase
    {
        /// <summary>
        /// 卡片数据
        /// </summary>
        public object Card { get; set; }

        /// <summary>
        /// 附加文本
        /// </summary>
        public string Content { get; set; }
    }
}
