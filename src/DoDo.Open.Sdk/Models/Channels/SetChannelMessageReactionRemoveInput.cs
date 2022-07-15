using DoDo.Open.Sdk.Models.Messages;
namespace DoDo.Open.Sdk.Models.Channels
{
    public class SetChannelMessageReactionRemoveInput
    {
        /// <summary>
        /// 消息ID
        /// </summary>
        public string MessageId { get; set; }

        /// <summary>
        /// 反应表情
        /// </summary>
        public MessageModelEmoji Emoji { get; set; }

        /// <summary>
        /// DoDo号，不传或传空时表示移除机器人自身的反应
        /// </summary>
        public string DodoId { get; set; }
    }
}
