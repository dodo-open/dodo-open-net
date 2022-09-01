using DoDo.Open.Sdk.Models.Members;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoDo.Open.Sdk.Models.Bots
{
    public class GetBotInviteListOutput
    {
        public GetBotInviteListOutput()
        {
            List = new List<GetBotInviteListItem>();
        }

        /// <summary>
        /// 最大ID值
        /// </summary>
        public long MaxId { get; set; }

        /// <summary>
        /// 成员列表
        /// </summary>
        public List<GetBotInviteListItem> List { get; set; }
    }

    public class GetBotInviteListItem
    {
        /// <summary>
        /// DoDo号
        /// </summary>
        public string DodoId { get; set; }

        /// <summary>
        /// DoDo昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        public string AvatarUrl { get; set; }
    }
}
