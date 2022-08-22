namespace DoDo.Open.Sdk.Models.Roles
{
    public class SetRoleAddInput
    {
        /// <summary>
        /// 群号
        /// </summary>
        public string IslandId { get; set; }

        /// <summary>
        /// 身份组名称
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        /// 身份组颜色
        /// </summary>
        public string RoleColor { get; set; }

        /// <summary>
        /// 身份组排序位置
        /// </summary>
        public int Position { get; set; }

        /// <summary>
        /// 身份组权限值（16进制）
        /// </summary>
        public string Permission { get; set; }
    }
}
