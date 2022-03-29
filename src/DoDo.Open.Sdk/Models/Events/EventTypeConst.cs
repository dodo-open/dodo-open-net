﻿ using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoDo.Open.Sdk.Models.Events
{
    public class EventTypeConst
    {
        /// <summary>
        /// 个人消息事件
        /// </summary>
        public static int PersonalMessage = 1001;

        /// <summary>
        /// 频道消息事件
        /// </summary>
        public static int ChannelMessage = 2001;

        /// <summary>
        /// 消息反应事件
        /// </summary>
        public static int MessageReaction = 3001;

        /// <summary>
        /// 成员加入事件
        /// </summary>
        public static int MemberJoin = 4001;

        /// <summary>
        /// 成员退出事件
        /// </summary>
        public static int MemberLeave = 4002;
    }
}
