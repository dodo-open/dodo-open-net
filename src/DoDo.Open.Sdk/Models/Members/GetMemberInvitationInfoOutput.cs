namespace DoDo.Open.Sdk.Models.Members
{
    public class GetMemberInvitationInfoOutput
    {
        /// <summary>
        /// DoDoID
        /// </summary>
        public string DodoSourceId { get; set; }

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
