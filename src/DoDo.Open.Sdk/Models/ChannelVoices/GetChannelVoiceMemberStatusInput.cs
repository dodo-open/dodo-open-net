using System;
using System.Collections.Generic;
using System.Text;

namespace DoDo.Open.Sdk.Models.ChannelVoices
{
    public class GetChannelVoiceMemberStatusInput
    {
        /// <summary>
        /// 群ID
        /// </summary>
        public string IslandSourceId { get; set; }

        /// <summary>
        /// DoDoID
        /// </summary>
        public string DodoSourceId { get; set; }
    }
}
