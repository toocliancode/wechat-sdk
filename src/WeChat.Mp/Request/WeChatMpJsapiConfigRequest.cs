
using Mediator.HttpClient;

using System.Text.Json.Serialization;

namespace WeChat.Mp;

/// <summary>
/// JS-SDK使用权限签名算法(微信jssdk配置)
/// 
/// https://developers.weixin.qq.com/doc/offiaccount/OA_Web_Apps/JS-SDK.html#62
/// </summary>
public class WeChatMpJsapiConfigRequest
    : WeChatRequestBase<WeChatMpJsapiConfigResponse>
{
    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpJsapiConfigRequest"/>
    /// </summary>
    public WeChatMpJsapiConfigRequest()
    {

    }

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpJsapiConfigRequest"/>
    /// </summary>
    /// <param name="appId">微信应用号</param>
    /// <param name="jsapiTicket">公众号用于调用微信JS接口的临时票据</param>
    /// <param name="url">需要微信jssdk配置 的页面链接</param>
    public WeChatMpJsapiConfigRequest(
        string appId,
        string jsapiTicket,
        string url)
    {
        AppId = appId;
        JsapiTicket = jsapiTicket;
        Url = url;
    }

    /// <summary>
    /// 微信应用号
    /// </summary>
    [JsonPropertyName("appid")]
    public string AppId { get; set; }

    /// <summary>
    /// 公众号用于调用微信JS接口的临时票据
    /// </summary>
    [JsonPropertyName("jsapi_ticket")]
    public string JsapiTicket { get; set; }

    /// <summary>
    /// 需要微信jssdk配置 的页面链接
    /// </summary>
    [JsonPropertyName("url")]
    public string Url { get; set; }

    public override Task<WeChatMpJsapiConfigResponse> Handle(IWeChatRequetHandleContext context)
    {
        // 设置随机字符串
        var noncestr = HttpUtility.GenerateNonceStr();
        // 设置时间戳
        var timestamp = HttpUtility.GetTimeStamp();

        var dictionary = new WeChatDictionary
            {
                {"noncestr",noncestr },
                {"timestamp",timestamp },
                {"url",Url },
                {"jsapi_ticket",JsapiTicket }
            };

        var response = new WeChatMpJsapiConfigResponse(AppId, timestamp, noncestr)
        {
            Signature = WeChatSignature.Sign(dictionary, WeChatSignType.SHA1)
        };
        return Task.FromResult(response);
    }
}
