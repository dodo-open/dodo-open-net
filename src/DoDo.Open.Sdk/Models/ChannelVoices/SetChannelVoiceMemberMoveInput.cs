using System;
using System.Collections.Generic;
using System.Text;

namespace DoDo.Open.Sdk.Models.ChannelVoices
{
    public class SetChannelVoiceMemberMoveInput
    {
        /// <summary>
        /// 群ID
        /// </summary>
        public string IslandSourceId { get; set; }

        /// <summary>
        /// DoDoID
        /// </summary>
        public string DodoSourceId { get; set; }

        /// <summary>
        /// 目标语音频道ID
        /// </summary>
        public string ChannelId { get; set; }
    }
}
