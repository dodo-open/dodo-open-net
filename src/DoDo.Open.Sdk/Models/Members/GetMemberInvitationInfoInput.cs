using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DoDo.Open.Sdk.Models.Members
{
    public  class GetMemberInvitationInfoInput
    {
        /// <summary>
        /// 群号
        /// </summary>
        [JsonProperty("islandId")]
        public string IslandId { get; set; }

        /// <summary>
        /// DoDo号
        /// </summary>
        [JsonProperty("dodoId")]
        public string DoDoId { get; set; }
    }
}
