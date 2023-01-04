using System;
using System.Collections.Generic;
using System.Text;

namespace DoDo.Open.Sdk.Models.ChannelVoices
{
    public class GetChannelVoiceMemberStatusOutput
    {
        /// <summary>
        /// 所在语音频道ID
        /// </summary>
        public string ChannelId { get; set; }

        /// <summary>
        /// 语音输出状态（扬声器的状态），0：关闭，1：开启
        /// </summary>
        public int SpkStatus { get; set; }

        /// <summary>
        /// 语音输入状态（麦的状态），0：关闭，1：开启
        /// </summary>
        public int MicStatus { get; set; }

        /// <summary>
        /// 麦序模式状态，1：在麦下，2：请求上麦，3：在麦上，自由模式时统一为在麦上
        /// </summary>
        public int MicSortStatus { get; set; }
    }
}
