namespace WeChat.Mp;

/// <summary>
/// 【微信公众号】 ticket 请求
/// 
/// <para>文档：<a href="https://developers.weixin.qq.com/doc/offiaccount/WeChat_Invoice/Nontax_Bill/API_list.html#2.1%20%E8%8E%B7%E5%8F%96ticket"></a></para>
/// </summary>
public class Ticket
{
    public static string Endpoint = "/cgi-bin/ticket/getticket?access_token={access_token}&type={type}";

    public class Response : WeChatMpHttpResponse
    {
        /// <summary>
        /// 获取到的凭证
        /// </summary>
        [JsonPropertyName("ticket")]
        public string Ticket { get; set; }

        /// <summary>
        /// 凭证有效时间，单位：秒
        /// </summary>
        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; set; }
    }

    /// <summary>
    /// 实例化一个新的【微信 ticket 请求】
    /// </summary>
    /// <param name="type">
    /// 凭证类型。
    /// 可选值：jsapi、wx_card。
    /// 默认值：jsapi
    /// </param>
    public class Request(string type = "jsapi") : WeChatMpHttpRequest<Response>
    {
        protected override async Task InitializeRequestMessageAsync(IHttpRequestContext context)
        {
            var token = await GetAccessTokenAsync();
            var url = $"{WeChatMpProperties.Domain}{Endpoint}".Replace("{access_token}", token).Replace("{type}", type);

            context.Message.RequestUri = new Uri(url);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="type">
    /// 凭证类型。
    /// 可选值：jsapi、wx_card。
    /// 默认值：jsapi
    /// </param>
    /// <returns></returns>
    public static Request ToRequest(string type = "jsapi") => new(type);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="options"></param>
    /// <param name="type">
    /// 凭证类型。
    /// 可选值：jsapi、wx_card。
    /// 默认值：jsapi
    /// </param>
    /// <returns></returns>
    public static Request ToRequest(WeChatMpOptions options, string type = "jsapi")
    {
        var request = ToRequest(type);
        request.WithOptions(options);
        return request;
    }
}
