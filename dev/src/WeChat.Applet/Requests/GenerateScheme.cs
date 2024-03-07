using Mediation.HttpClient;

using Microsoft.Extensions.DependencyInjection;

using System.Text.Json.Serialization;

#pragma warning disable CS8601

namespace WeChat.Applet;

/// <summary>
/// 【微信小程序】获取加密 scheme 码
/// 
/// <para>文档：<a href="https://developers.weixin.qq.com/miniprogram/dev/OpenApiDoc/qrcode-link/url-scheme/generateScheme.html"></a></para>
/// </summary>
public class GenerateScheme
{
    public static string Endpoint = "/wxa/generatescheme?access_token={access_token}";

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
        public Model(long? expireTime = default, long? expireType = default, long? expireInterval = default)
        {
            ExpireTime = expireTime;
            ExpireType = expireType;
            ExpireInterval = expireInterval;
        }

        /// <summary>
        /// 到期失效的 scheme 码的失效时间，为 Unix 时间戳。生成的到期失效 scheme 码在该时间前有效。最长有效期为30天。is_expire 为 true 且 expire_type 为 0 时必填
        /// </summary>
        public long? ExpireTime { get => TryGetValue("expire_time", out var value) && long.TryParse(value?.ToString(), out var result) ? result : null; set => this["expire_time"] = value; }

        /// <summary>
        /// 默认值0，到期失效的 scheme 码失效类型，失效时间：0，失效间隔天数：1
        /// </summary>
        public long? ExpireType { get => TryGetValue("expire_type", out var value) && long.TryParse(value?.ToString(), out var result) ? result : null; set => this["expire_type"] = value; }

        /// <summary>
        /// 到期失效的 scheme 码的失效间隔天数。生成的到期失效 scheme 码在该间隔时间到达前有效。最长间隔天数为30天。is_expire 为 true 且 expire_type 为 1 时必填
        /// </summary>
        public long? ExpireInterval { get => TryGetValue("expire_interval", out var value) && long.TryParse(value?.ToString(), out var result) ? result : null; set => this["expire_interval"] = value; }

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