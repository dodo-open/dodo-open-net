﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DoDo.Open.Sdk.Models.Roles
{
    public class GetRoleListOutput
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

        /// <summary>
        /// 身份组颜色
        /// </summary>
        [JsonProperty("roleColor")]
        public string RoleColor { get; set; }

        /// <summary>
        /// 位置
        /// </summary>
        [JsonProperty("position")]
        public int Position { get; set; }

        /// <summary>
        /// 权限值
        /// </summary>
        [JsonProperty("permission")]
        public string Permission { get; set; }
    }
}
