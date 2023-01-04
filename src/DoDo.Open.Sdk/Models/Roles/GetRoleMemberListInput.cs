namespace DoDo.Open.Sdk.Models.Roles
{
    public class GetRoleMemberListInput : OpenApiPageInput
    {
        /// <summary>
        /// 群ID
        /// </summary>
        public string IslandSourceId { get; set; }

        /// <summary>
        /// 身份组ID
        /// </summary>
        public string RoleId { get; set; }
    }
}
