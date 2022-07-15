namespace DoDo.Open.Sdk.Models.Members
{
    public class GetMemberRoleListOutput
    {
        /// <summary>
        /// 身份组ID
        /// </summary>
        public string RoleId { get; set; }

        /// <summary>
        /// 身份组名称
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        /// 身份组颜色
        /// </summary>
        public string RoleColor { get; set; }

        /// <summary>
        /// 位置
        /// </summary>
        public int Position { get; set; }

        /// <summary>
        /// 权限值
        /// </summary>
        public string Permission { get; set; }
    }
}
