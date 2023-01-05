namespace DoDo.Open.Sdk.Models.Bots
{
    public class GetBotInfoOutput
    {
        /// <summary>
        /// 机器人唯一标识
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// 机器人DoDoID
        /// </summary>
        public string DodoSourceId { get; set; }

        /// <summary>
        /// 机器人昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 机器人头像
        /// </summary>
        public string AvatarUrl { get; set; }
    }
}
