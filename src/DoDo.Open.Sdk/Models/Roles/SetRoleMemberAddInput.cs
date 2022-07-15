namespace DoDo.Open.Sdk.Models.Roles
{
    public class SetRoleMemberAddInput
    {
        /// <summary>
        /// 群号
        /// </summary>
        public string IslandId { get; set; }

        /// <summary>
        /// DoDo号
        /// </summary>
        public string DodoId { get; set; }

        /// <summary>
        /// 身份组ID
        /// </summary>
        public string RoleId { get; set; }
    }
}
