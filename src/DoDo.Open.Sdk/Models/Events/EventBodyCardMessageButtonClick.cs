using DoDo.Open.Sdk.Models.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoDo.Open.Sdk.Models.Events
{
    public class EventBodyCardMessageButtonClick : EventBodyChannelBase
    {
        /// <summary>
        /// 交互自定义ID
        /// </summary>
        public string InteractCustomId { get; set; }

        /// <summary>
        /// Value
        /// </summary>
        public string Value { get; set; }
    }
}
