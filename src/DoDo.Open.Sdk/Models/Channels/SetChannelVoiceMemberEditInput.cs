using System;
using System.Collections.Generic;
using System.Text;

namespace DoDo.Open.Sdk.Models.Channels
{
    public class SetChannelVoiceMemberEditInput
    {
        /// <summary>
        /// 帖子频道ID
        /// </summary>
        public string ChannelId { get; set; }

        /// <summary>
        /// DoDo号
        /// </summary>
        public string DodoId { get; set; }

        /// <summary>
        /// 执行管理
        /// 0：下麦，自由模式：无作用；麦序模式：设置下麦或拒绝上麦
        /// 1：上麦，自由模式：无作用；麦序模式：同意上麦或邀请上麦
        /// 2：闭麦，自由模式：闭麦该成员；麦序模式：闭麦该成员
        /// 3：移出语音频道
        /// </summary>
        public int OperateType { get; set; }
    }
}
