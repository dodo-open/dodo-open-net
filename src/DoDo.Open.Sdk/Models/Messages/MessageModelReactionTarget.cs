using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoDo.Open.Sdk.Models.Messages
{
    public class MessageModelReactionTarget
    {
        /// <summary>
        /// 对象类型，0：消息
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 对象ID，若对象类型为0，则代表消息ID
        /// </summary>
        public string Id { get; set; }
    }
}
