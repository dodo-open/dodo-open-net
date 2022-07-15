namespace DoDo.Open.Sdk.Models.Channels
{
    public class SetChannelMessageWithdrawInput
    {
        /// <summary>
        /// 消息ID
        /// </summary>
        public string MessageId { get; set; }

        /// <summary>
        /// 撤回理由
        /// </summary>
        public string Reason { get; set; }
    }
}
