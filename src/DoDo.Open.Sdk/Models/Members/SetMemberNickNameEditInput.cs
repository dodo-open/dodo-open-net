namespace DoDo.Open.Sdk.Models.Members
{
    public class SetMemberNickNameEditInput
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
        /// 群昵称
        /// </summary>
        public string NickName { get; set; }
    }
}
