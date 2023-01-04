using System;
using System.Collections.Generic;
using System.Text;

namespace DoDo.Open.Sdk.Models.Channels
{
    public class SetChannelMessageTopInput
    {
        /// <summary>
        /// 消息ID
        /// </summary>
        public string MessageId { get; set; }

        /// <summary>
        /// 操作类型，0：取消置顶，1：置顶
        /// </summary>
        public int OperateType { get; set; }
    }
}
