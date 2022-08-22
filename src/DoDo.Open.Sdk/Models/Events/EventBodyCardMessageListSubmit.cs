using DoDo.Open.Sdk.Models.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoDo.Open.Sdk.Models.Events
{
    public class EventBodyCardMessageListSubmit : EventBodyChannelBase
    {
        /// <summary>
        /// 交互自定义ID
        /// </summary>
        public string InteractCustomId { get; set; }

        /// <summary>
        /// 列表数据
        /// </summary>
        public List<MessageModelListData> ListData { get; set; }
    }
}
