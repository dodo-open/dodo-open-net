using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DoDo.Open.Sdk.Models.Members
{
    public class GetMemberInvitationInfoOutput
    {
        /// <summary>
        /// DoDo号
        /// </summary>
        [JsonProperty("dodoId")]
        public string DodoId { get; set; }

        /// <summary>
        /// 群昵称
        /// </summary>
        [JsonProperty("nickName")]
        public string NickName { get; set; }

        /// <summary>
        /// 邀请人数
        /// </summary>
        [JsonProperty("invitationCount")]
        public int InvitationCount { get; set; }
        
    }
}
