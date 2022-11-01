namespace DoDo.Open.Sdk.Models.Members
{
    public  class GetMemberInvitationInfoInput
    {
        /// <summary>
        /// 群ID
        /// </summary>
        public string IslandSourceId { get; set; }

        /// <summary>
        /// DoDoID
        /// </summary>
        public string DodoSourceId { get; set; }
    }
}
