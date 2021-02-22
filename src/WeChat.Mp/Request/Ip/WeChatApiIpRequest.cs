
using WeChat.Mp.Response;

namespace WeChat.Mp.Request
{
    /// <summary>
    /// 微信API接口IP地址 请求
    /// </summary>
    public class WeChatApiIpRequest : WeChatHttpRequestBase<WeChatIpResponse>, IEnableAccessToken
    {
        protected override string EndpointName => WeChatMpEndpoints.ApiIp;
    }
}
