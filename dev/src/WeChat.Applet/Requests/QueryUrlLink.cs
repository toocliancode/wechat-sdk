using Mediation.HttpClient;

using Microsoft.Extensions.DependencyInjection;

using System.Text.Json.Serialization;

#pragma warning disable CS8601

namespace WeChat.Applet;

/// <summary>
/// 【微信小程序】查询加密URLLink
/// 
/// <para>文档：<a href="https://developers.weixin.qq.com/miniprogram/dev/OpenApiDoc/qrcode-link/url-link/queryUrlLink.html"></a></para>
/// </summary>
public class QueryUrlLink
{
    public static string Endpoint = "/wxa/query_urllink?access_token={access_token}";
    public class Model : WeChatDictionary<object>
    {
        public Model()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="urlLink">小程序加密 url_link</param>
        /// <param name="queryType">查询类型。默认值0，查询 scheme 码信息：0， 查询每天剩余访问次数：1</param>
        public Model(string urlLink, int? queryType = default)
        {
            UrlLink = urlLink;
            QueryType = queryType;
        }

        /// <summary>
        /// 小程序加密 url_link
        /// </summary>
        public string? UrlLink { get => TryGetValue("url_link", out var value) ? value?.ToString() : null; set => this["url_link"] = value; }

        /// <summary>
        /// 查询类型。默认值0，查询 scheme 码信息：0， 查询每天剩余访问次数：1
        /// </summary>
        public int? QueryType { get => TryGetValue("query_type", out var value) && int.TryParse(value?.ToString(), out var result) ? result : null; set => this["query_type"] = value; }

    }

    public class UrlLinkInfo
    {
        /// <summary>
        /// 小程序 appid
        /// </summary>
        [JsonPropertyName("appid")]
        public string? AppId { get; set; }

        /// <summary>
        /// 小程序页面路径
        /// </summary>
        [JsonPropertyName("path")]
        public string? Path { get; set; }

        /// <summary>
        /// 小程序页面 query
        /// </summary>
        [JsonPropertyName("query")]
        public string? Query { get; set; }

        /// <summary>
        /// 创建时间，为 Unix 时间戳
        /// </summary>
        [JsonPropertyName("create_time")]
        public long? CreateTime { get; set; }

        /// <summary>
        /// 创建时间，为 Unix 时间戳
        /// </summary>
        [JsonPropertyName("expire_time")]
        public long? ExpireTime { get; set; }

        /// <summary>
        /// 要打开的小程序版本。正式版为"release"，体验版为"trial"，开发版为"develop"
        /// </summary>
        [JsonPropertyName("env_version")]
        public string? EnvVersion { get; set; }
    }

    /// <summary>
    /// quota 配置
    /// </summary>
    public class QuotaInfo
    {
        /// <summary>
        /// URL Scheme（加密+明文）/加密 URL Link 单天剩余访问次数
        /// </summary>
        [JsonPropertyName("remain_visit_quota")]
        public int? RemainVisitQuota { get; set; }
    }

    public class Response : WeChatAppletHttpResponse
    {
        /// <summary>
        /// url_link 配置
        /// </summary>
        [JsonPropertyName("url_link_info")]
        public UrlLinkInfo UrlLinkInfo { get; set; }

        /// <summary>
        /// quota 配置
        /// </summary>
        [JsonPropertyName("QuotaInfo")]
        public QuotaInfo QuotaInfo { get; set; }
    }

    public class Request : WeChatAppletHttpRequest<Response>
    {
        public Request() { }

        public Request(Model model) => Model = model;

        public Model Model { get; } = [];

        protected override async Task InitializeRequestMessageAsync(IHttpRequestContext context)
        {
            var token = await context.RequestServices.GetRequiredService<IWeChatAppletAccessTokenStore>().GetAsync();

            var url = $"{WeChatAppletProperties.Domain}{Endpoint}"
                .Replace("{access_token}", token)
                ;

            var content = WeChatSerializer.Serialize(Model);

            context.Message.Method = HttpMethod.Post;
            context.Message.RequestUri = new Uri(url);
            context.Message.Content = new StringContent(content);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="scheme">小程序 scheme 码。支持加密 scheme 和明文 scheme</param>
    /// <param name="queryType">查询类型。默认值0，查询 scheme 码信息：0， 查询每天剩余访问次数：1</param>
    /// <returns></returns>
    public static Request ToRequest(string scheme, int? queryType = default) => new(new(scheme, queryType));
}