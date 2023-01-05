namespace DoDo.Open.Sdk.Models.Roles
{
    public class GetRoleMemberListOutput : OpenApiPageOutput<GetRoleMemberListItem>
    {
    }

    public class GetRoleMemberListItem
    {
        /// <summary>
        /// DoDoID
        /// </summary>
        public string DodoSourceId { get; set; }

        /// <summary>
        /// 群昵称
        /// </summary>
        public string NickName { get; set; }
    }
}
