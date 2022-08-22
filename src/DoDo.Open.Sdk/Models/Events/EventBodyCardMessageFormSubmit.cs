using DoDo.Open.Sdk.Models.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoDo.Open.Sdk.Models.Events
{
    public class EventBodyCardMessageFormSubmit : EventBodyChannelBase
    {
        /// <summary>
        /// 交互自定义ID
        /// </summary>
        public string InteractCustomId { get; set; }

        /// <summary>
        /// 表单数据
        /// </summary>
        public List<MessageModelFormData> FormData { get; set; }
    }
}
