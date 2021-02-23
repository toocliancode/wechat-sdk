﻿
using WeChat.Mp.Response;

namespace WeChat.Mp.Request
{
    /// <summary>
    /// 获取微信callback IP地址
    /// </summary>
    public class WeChatCallbackIpRequest : WeChatMpHttpRequestBase<WeChatIpResponse>, IEnableAccessToken
    {
        protected override string EndpointName => WeChatMpEndpoints.CallbackIp;
    }
}
