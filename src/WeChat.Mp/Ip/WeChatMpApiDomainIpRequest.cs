
using System.Text.Json.Serialization;

namespace WeChat.Mp.Ip;

/// <summary>
/// 微信API接口IP地址 请求
/// 
/// https://developers.weixin.qq.com/doc/offiaccount/Basic_Information/Get_the_WeChat_server_IP_address.html
/// </summary>
public class WeChatMpApiDomainIpRequest
    : WeChatHttpRequest<WeChatMpApiDomainIpResponse>
    , IHasAccessToken
{
    public static string Endpoint = "https://api.weixin.qq.com/cgi-bin/get_api_domain_ip";

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpApiDomainIpRequest"/>
    /// </summary>
    public WeChatMpApiDomainIpRequest()
    {

    }

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpApiDomainIpRequest"/>
    /// </summary>
    /// <param name="accessToken">微信API access_token</param>
    public WeChatMpApiDomainIpRequest(string accessToken)
    {
        AccessToken = accessToken;
    }

    /// <summary>
    /// 微信API access_token
    /// </summary>
    [JsonIgnore]
    public string? AccessToken { get; set; }

    protected override string GetRequestUri() => $"{Endpoint}?access_token={AccessToken}";
}
