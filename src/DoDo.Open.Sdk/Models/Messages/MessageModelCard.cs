using System.Collections.Generic;

namespace DoDo.Open.Sdk.Models.Messages
{
    public class MessageModelCard
    {
        /// <summary>
        /// 类型，固定填写card
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 卡片风格，grey，red，orange，yellow ，green，indigo，blue，purple，black，default
        /// </summary>
        public string Theme { get; set; }

        /// <summary>
        /// 卡片标题，只支持普通文本，可以为空字符串
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 内容组件
        /// </summary>
        public List<object> Components { get; set; }
    }
}
