namespace DoDo.Open.Sdk.Models.Roles
{
    public class SetRoleMemberAddInput
    {
        /// <summary>
        /// 群ID
        /// </summary>
        public string IslandSourceId { get; set; }

        /// <summary>
        /// DoDoID
        /// </summary>
        public string DodoSourceId { get; set; }

        /// <summary>
        /// 身份组ID
        /// </summary>
        public string RoleId { get; set; }
    }
}
