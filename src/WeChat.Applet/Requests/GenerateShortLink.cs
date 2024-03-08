using Mediation.HttpClient;

using Microsoft.Extensions.DependencyInjection;

using System.Text.Json.Serialization;

#pragma warning disable CS8601

namespace WeChat.Applet;

/// <summary>
/// 【微信小程序】获取ShortLink
/// 
/// <para>文档：<a href="https://developers.weixin.qq.com/miniprogram/dev/OpenApiDoc/qrcode-link/short-link/generateShortLink.html"></a></para>
/// </summary>
public class GenerateShortLink
{
    public static string Endpoint = "/wxa/genwxashortlink?access_token={access_token}";

    public class Model : WeChatDictionary<object>
    {
        public Model()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageUrl">通过 Short Link 进入的小程序页面路径，必须是已经发布的小程序存在的页面，可携带 query，最大1024个字符</param>
        /// <param name="pageTitle">通过 Short Link 进入的小程序页面路径，必须是已经发布的小程序存在的页面，可携带 query，最大1024个字符</param>
        /// <param name="isPermanent">默认值 false。生成的 Short Link 类型，短期有效：false，永久有效：true</param>
        public Model(string pageUrl, string? pageTitle = default, bool? isPermanent = default)
        {
            PageUrl = pageUrl;
            PageTitle = pageTitle;
            IsPermanent = isPermanent;
        }

        /// <summary>
        /// 通过 Short Link 进入的小程序页面路径，必须是已经发布的小程序存在的页面，可携带 query，最大1024个字符
        /// </summary>
        public string PageUrl { get => GetValueOrDefault("page_url", string.Empty); set => this["page_url"] = value; }

        /// <summary>
        /// 通过 Short Link 进入的小程序页面路径，必须是已经发布的小程序存在的页面，可携带 query，最大1024个字符
        /// </summary>
        public string? PageTitle { get => GetValueOrDefault<string?>("page_title", null); set => this["page_title"] = value; }

        /// <summary>
        /// 默认值 false。生成的 Short Link 类型，短期有效：false，永久有效：true
        /// </summary>
        public bool? IsPermanent { get => GetValueOrDefault<bool?>("is_permanent", null); set => this["is_permanent"] = value; }
    }

    public class Response : WeChatAppletHttpResponse
    {
        /// <summary>
        /// 生成的小程序 URL Link
        /// </summary>
        [JsonPropertyName("url_link")]
        public string UrlLink { get; set; }
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
}