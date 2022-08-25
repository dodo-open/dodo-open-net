using System;
using System.Collections.Generic;
using System.Text;
using DoDo.Open.Sdk.Models.Messages;

namespace DoDo.Open.Sdk.Models.Events
{
    public class EventBodyChannelBase : EventBodyBase
    {
        /// <summary>
        /// 来源群号
        /// </summary>
        public string IslandId { get; set; }

        /// <summary>
        /// 来源频道ID
        /// </summary>
        public string ChannelId { get; set; }

        /// <summary>
        /// 来源DoDo号
        /// </summary>
        public string DodoId { get; set; }

        /// <summary>
        /// 消息ID
        /// </summary>
        public string MessageId { get; set; }

        /// <summary>
        /// 个人信息
        /// </summary>
        public MessageModelPersonal Personal { get; set; }

        /// <summary>
        /// 成员信息
        /// </summary>
        public MessageModelMember Member { get; set; }
    }
}
