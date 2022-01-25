using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoDo.Open.Sdk.Services
{
    /// <summary>
    /// 事件处理服务
    /// </summary>
    public interface IEventProcessService
    {
        /// <summary>
        /// 接收消息
        /// </summary>
        /// <param name="message"></param>
        void Received(string message);

        /// <summary>
        /// 连接成功
        /// </summary>
        /// <param name="message"></param>
        void Connected(string message);

        /// <summary>
        /// 连接断开
        /// </summary>
        /// <param name="message"></param>
        void Disconnected(string message);

        /// <summary>
        /// 断线重连
        /// </summary>
        /// <param name="message"></param>
        void Reconnected(string message);

        /// <summary>
        /// 发生异常
        /// </summary>
        /// <param name="message"></param>
        void Exception(string message);
    }
}
