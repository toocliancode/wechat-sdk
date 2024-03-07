using Mediation.HttpClient;

using Microsoft.Extensions.DependencyInjection;

using System.Text.Json.Serialization;

#pragma warning disable CS8601

namespace WeChat.Applet;

/// <summary>
/// 【微信小程序】获取 NFC 的小程序 scheme
/// 
/// <para>文档：<a href="https://developers.weixin.qq.com/miniprogram/dev/OpenApiDoc/qrcode-link/url-scheme/generateNFCScheme.html"></a></para>
/// </summary>
public class GenerateNFCScheme
{
    public static string Endpoint = "/wxa/generatenfcscheme?access_token={access_token}";

    public class JumpWxa
    {
        /// <summary>
        /// 通过 scheme 码进入的小程序页面路径，必须是已经发布的小程序存在的页面，不可携带 query。path 为空时会跳转小程序主页
        /// </summary>
        [JsonPropertyName("path")]
        public string? Path { get; set; }

        /// <summary>
        /// 通过 scheme 码进入小程序时的 query，最大1024个字符，只支持数字，大小写英文以及部分特殊字符：`!#$&amp;'()*+,/:;=?@-._~%``
        /// </summary>
        [JsonPropertyName("query")]
        public string? Query { get; set; }

        /// <summary>
        /// 要打开的小程序版本。正式版为"release"，体验版为"trial"，开发版为"develop"，仅在微信外打开时生效
        /// </summary>
        [JsonPropertyName("env_version")]
        public string? EnvVersion { get; set; }
    }

    public class Model : WeChatDictionary<object>
    {
        public Model()
        {

        }
        public Model(string? modelId, string? sn)
        {
            ModelId = modelId;
            Sn = sn;
        }

        /// <summary>
        /// scheme对应的设备 model_id
        /// </summary>
        public string? ModelId { get => TryGetValue("model_id", out var value) ? value?.ToString() : null; set => this["model_id"] = value; }

        /// <summary>
        /// scheme对应的设备sn，仅一机一码时填写
        /// </summary>
        public string? Sn { get => TryGetValue("sn", out var value) ? value?.ToString() : null; set => this["sn"] = value; }

    }

    public class Response : WeChatAppletHttpResponse
    {
        /// <summary>
        /// 生成的小程序 scheme 码
        /// </summary>
        [JsonPropertyName("openlink")]
        public string OpenLink { get; set; }
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
