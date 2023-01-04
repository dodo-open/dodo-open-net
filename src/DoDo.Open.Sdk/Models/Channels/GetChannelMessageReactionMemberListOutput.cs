using System;
using System.Collections.Generic;
using System.Text;

namespace DoDo.Open.Sdk.Models.Channels
{
    public class GetChannelMessageReactionMemberListOutput : OpenApiPageOutput<GetChannelMessageReactionMemberListItem>
    {

    }

    public class GetChannelMessageReactionMemberListItem
    {
        /// <summary>
        /// DoDoID
        /// </summary>
        public string DodoSourceId { get; set; }

        /// <summary>
        /// 群昵称
        /// </summary>
        public string NickName { get; set; }
    }
}
