using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DoDo.Open.Sdk.Models.Members
{
    public class GetMemberRoleListOutput
    {
        /// <summary>
        /// 身份组ID
        /// </summary>
        [JsonProperty("roleId")]
        public string RoleId { get; set; }

        /// <summary>
        /// 身份组名称
        /// </summary>
        [JsonProperty("roleName")]
        public string RoleName { get; set; }
    }
}
