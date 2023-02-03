using System.Text.Json.Serialization;

namespace DoDo.Open.Sdk.Models.WebHooks
{
    public class OpenWebHookOutput
    {
        /// <summary>
        /// 返回码，0：正常，-9999：异常
        /// </summary>
        [JsonPropertyName("status")]
        public int Status { get; set; }

        /// <summary>
        /// 返回信息
        /// </summary>
        [JsonPropertyName("message")]
        public string Message { get; set; }
    }

    public class OpenWebHookOutput<T> : OpenWebHookOutput
    {
        /// <summary>
        /// 返回数据
        /// </summary>
        [JsonPropertyName("data")]
        public T Data { get; set; }
    }
}
