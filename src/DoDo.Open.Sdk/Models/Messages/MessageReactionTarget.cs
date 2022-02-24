using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoDo.Open.Sdk.Models.Messages
{
    public class MessageReactionTarget
    {
        /// <summary>
        /// 目标类型，0：消息
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 目标ID，若目标类型为0，则代表消息ID
        /// </summary>
        public string Id { get; set; }
    }
}
