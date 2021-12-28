
using System;

namespace WeChat;

/// <summary>
/// 微信请求上下文
/// </summary>
public interface IWeChatRequetHandleContext
{
    /// <summary>
    /// 服务提供程序
    /// </summary>
    IServiceProvider RequestServices { get; }
}
