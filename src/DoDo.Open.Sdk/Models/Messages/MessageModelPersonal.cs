namespace DoDo.Open.Sdk.Models.Messages
{
    public class MessageModelPersonal
    {
        /// <summary>
        /// DoDo昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        public string AvatarUrl { get; set; }

        /// <summary>
        /// 性别，-1：保密，0：女，1：男
        /// </summary>
        public int Sex { get; set; }
    }
}
