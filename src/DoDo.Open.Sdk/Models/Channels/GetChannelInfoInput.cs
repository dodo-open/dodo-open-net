using System.Text.Json.Serialization;

namespace DoDo.Open.Sdk.Models.Channels
{
    public class GetChannelInfoInput
    {
        /// <summary>
        /// 频道ID
        /// </summary>
        [JsonPropertyName("channelId")]
        public string ChannelId { get; set; }
    }
}
