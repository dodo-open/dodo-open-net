using System.Collections.Generic;

namespace DoDo.Open.Sdk.Models.Messages
{
    public class MessageBodyRedPacket : MessageBodyBase
    {
        /// <summary>
        /// 红包类型，1：拼手气红包，2：普通红包
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 领取对象类型，1：全体成员，2：身份组
        /// </summary>
        public int ReceiverType { get; set; }

        /// <summary>
        /// 身份组ID列表
        /// </summary>
        public List<string> RoleIdList { get; set; }
    }
}
