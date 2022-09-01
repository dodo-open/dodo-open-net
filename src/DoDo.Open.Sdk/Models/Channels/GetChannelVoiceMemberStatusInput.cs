using System;
using System.Collections.Generic;
using System.Text;

namespace DoDo.Open.Sdk.Models.Channels
{
    public class GetChannelVoiceMemberStatusInput
    {
        /// <summary>
        /// 群号
        /// </summary>
        public string IslandId { get; set; }

        /// <summary>
        /// DoDo号
        /// </summary>
        public string DodoId { get; set; }
    }
}
