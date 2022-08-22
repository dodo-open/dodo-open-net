using System;
using System.Collections.Generic;
using System.Text;

namespace DoDo.Open.Sdk.Models.Messages
{
    public class MessageBodyShare : MessageBodyBase
    {
        /// <summary>
        /// 跳转链接
        /// </summary>
        public string JumpUrl { get; set; }
    }
}
