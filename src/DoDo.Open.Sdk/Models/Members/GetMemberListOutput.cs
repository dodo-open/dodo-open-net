using System.Collections.Generic;
using Newtonsoft.Json;

namespace DoDo.Open.Sdk.Models.Members
{
    public class GetMemberListOutput
    {
        /// <summary>
        /// 最大ID值
        /// </summary>
        public long MaxId { get; set; }

        /// <summary>
        /// 成员列表
        /// </summary>
        public List<GetMemberListItem> List { get; set; }
    }

    public class GetMemberListItem
    {
        /// <summary>
        /// DoDo号
        /// </summary>
        [JsonProperty("dodoId")]
        public string DodoId { get; set; }

        /// <summary>
        /// 在群昵称
        /// </summary>
        [JsonProperty("nickName")]
        public string NickName { get; set; }

        /// <summary>
        /// 个人昵称
        /// </summary>
        [JsonProperty("personalNickName")]
        public string PersonalNickName { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        [JsonProperty("avatarUrl")]
        public string AvatarUrl { get; set; }

        /// <summary>
        /// 加群时间
        /// </summary>
        [JsonProperty("joinTime")]
        public string JoinTime { get; set; }

        /// <summary>
        /// 性别，-1：保密，0：女，1：男
        /// </summary>
        [JsonProperty("sex")]
        public int Sex { get; set; }

        /// <summary>
        /// 等级
        /// </summary>
        [JsonProperty("level")]
        public int Level { get; set; }

        /// <summary>
        /// 是否机器人
        /// </summary>
        [JsonProperty("isBot")]
        public int IsBot { get; set; }

        /// <summary>
        /// 在线设备
        /// </summary>
        [JsonProperty("onlineDevice")]
        public int OnlineDevice { get; set; }

        /// <summary>
        /// 在线状态
        /// </summary>
        [JsonProperty("onlineStatus")]
        public int OnlineStatus { get; set; }
    }
}
