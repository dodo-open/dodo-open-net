using System.Text.Json.Serialization;

namespace DoDo.Open.Sdk.Models.Messages
{
    public class MessageBodyFile : MessageBodyBase
    {
        /// <summary>
        /// 文件链接
        /// </summary>
        [JsonPropertyName("url")]
        public string Url { get; set; }

        /// <summary>
        /// 文件名称
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// 文件大小
        /// </summary>
        [JsonPropertyName("size")]
        public long? Size { get; set; }
    }
}
