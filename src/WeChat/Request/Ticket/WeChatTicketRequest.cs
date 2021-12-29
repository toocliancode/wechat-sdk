
using Mediator.HttpClient;

namespace WeChat.Ticket;

/// <summary>
/// 微信 ticket 请求
/// 
/// https://developers.weixin.qq.com/doc/offiaccount/WeChat_Invoice/Nontax_Bill/API_list.html#2.1%20%E8%8E%B7%E5%8F%96ticket
/// </summary>
public class WeChatTicketRequest
    : WeChatHttpRequest<WeChatTicketResponse>
    , IHasAccessToken
{
    public static string Endpoint = "https://api.weixin.qq.com/cgi-bin/ticket/getticket";
    public const string EndpointFormat = "?access_token={0}&type={1}";

    /// <inheritdoc/>
    public string? AccessToken { get; set; }

    /// <summary>
    /// 凭证类型： jsapi、wx_card。
    /// 默认值：jsapi
    /// </summary>
    public string Type { get; set; } = "jsapi";

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatTicketRequest"/>
    /// </summary>
    public WeChatTicketRequest()
    {

    }

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatTicketRequest"/>
    /// </summary>
    /// <param name="accessToken"></param>
    /// <param name="type">凭证类型： jsapi、wx_card</param>
    public WeChatTicketRequest(
        string? accessToken = default,
        string type = "jsapi")
    {
        AccessToken = accessToken;
        Type = type;
    }

    protected override string GetRequestUri()
    {
        var body = new Dictionary<string, string?>
        {
            ["access_token"] = AccessToken,
            ["type"] = Type
        };

        return $"{Endpoint}?{HttpUtility.ToQuery(body)}";
    }
}
