namespace DoDo.Open.Sdk.Models
{
    public class OpenEventOptions
    {
        /// <summary>
        /// 是否异步处理
        /// </summary>
        public bool IsAsync { get; set; }

        /// <summary>
        /// 事件协议，0：WebSocket，1：WebHook
        /// </summary>
        public int Protocol { get; set; }

        /// <summary>
        /// 是否断线重连，目前仅WebSocket需要
        /// </summary>
        public bool IsReconnect { get; set; }

        /// <summary>
        /// 事件密钥，目前仅WebHook需要
        /// </summary>
        public string SecretKey { get; set; }
    }
}
