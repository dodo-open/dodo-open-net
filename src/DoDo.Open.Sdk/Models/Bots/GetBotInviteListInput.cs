using System;
using System.Collections.Generic;
using System.Text;

namespace DoDo.Open.Sdk.Models.Bots
{
    public class GetBotInviteListInput
    {
        /// <summary>
        /// 页大小
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 上一页最大ID值，为提升分页查询性能，需要传入上一页查询记录中的最大ID值，首页请传0
        /// </summary>
        public int MaxId { get; set; }
    }
}
