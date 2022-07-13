using System.Threading.Tasks;

namespace DoDo.Open.Sdk.Services;

/// <summary>
///     开放事件服务
/// </summary>
public interface IOpenEventService
{
    /// <summary>
    ///     接收事件消息
    /// </summary>
    /// <returns></returns>
    Task ReceiveAsync();

    /// <summary>
    ///     停止接收事件消息
    /// </summary>
    Task StopReceiveAsync();
}
