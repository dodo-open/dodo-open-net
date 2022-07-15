namespace DoDo.Open.Sdk.Models.Members
{
    public class GetMemberInvitationInfoOutput
    {
        /// <summary>
        /// DoDo号
        /// </summary>
        public string DodoId { get; set; }

        /// <summary>
        /// 群昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 邀请人数
        /// </summary>
        public int InvitationCount { get; set; }
        
    }
}
