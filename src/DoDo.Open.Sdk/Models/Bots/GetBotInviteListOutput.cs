namespace DoDo.Open.Sdk.Models.Bots
{
    public class GetBotInviteListOutput : OpenApiPageOutput<GetBotInviteListItem>
    {
    }

    public class GetBotInviteListItem
    {
        /// <summary>
        /// DoDoID
        /// </summary>
        public string DodoSourceId { get; set; }

        /// <summary>
        /// DoDo昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        public string AvatarUrl { get; set; }
    }
}
