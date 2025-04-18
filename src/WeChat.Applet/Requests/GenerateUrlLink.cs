#pragma warning disable CS8601

namespace WeChat.Applet;

/// <summary>
/// 【微信小程序】获取加密URLLink
/// 
/// <para>文档：<a href="https://developers.weixin.qq.com/miniprogram/dev/OpenApiDoc/qrcode-link/url-link/generateUrlLink.html"></a></para>
/// </summary>
public class GenerateUrlLink
{
    public static string Endpoint = "/wxa/generate_urllink?access_token={access_token}";

    /// <summary>
    /// 云开发静态网站自定义 H5 配置参数，可配置中转的云开发 H5 页面。不填默认用官方 H5 页面
    /// </summary>
    public class CloudBase
    {
        /// <summary>
        /// 云开发环境
        /// </summary>
        [JsonPropertyName("env")]
        public string Env { get; set; }

        /// <summary>
        /// 静态网站自定义域名，不填则使用默认域名
        /// </summary>
        [JsonPropertyName("domain")]
        public string? Domain { get; set; }

        /// <summary>
        /// 云开发静态网站 H5 页面路径，不可携带 query
        /// </summary>
        [JsonPropertyName("path")]
        public string? Path { get; set; }

        /// <summary>
        /// 云开发静态网站 H5 页面 query 参数，最大 1024 个字符，只支持数字，大小写英文以及部分特殊字符：!#$&amp;'()*+,/:;=?@-._~%`
        /// </summary>
        [JsonPropertyName("query")]
        public string? Query { get; set; }

        /// <summary>
        /// 第三方批量代云开发时必填，表示创建该 env 的 appid （小程序/第三方平台）
        /// </summary>
        [JsonPropertyName("resource_appid")]
        public string? ResourceAppId { get; set; }
    }

    public class Model : WeChatDictionary<object>
    {
        public Model()
        {

        }

        /// <param name="expireTime">期失效的 scheme 码的失效时间，为 Unix 时间戳。生成的到期失效 scheme 码在该时间前有效。最长有效期为30天。is_expire 为 true 且 expire_type 为 0 时必填</param>
        /// <param name="expireType">默认值0，到期失效的 scheme 码失效类型，失效时间：0，失效间隔天数：1</param>
        /// <param name="expireInterval">到期失效的 scheme 码的失效间隔天数。生成的到期失效 scheme 码在该间隔时间到达前有效。最长间隔天数为30天。is_expire 为 true 且 expire_type 为 1 时必填</param>
        /// <param name="cloudBase">云开发静态网站自定义 H5 配置参数，可配置中转的云开发 H5 页面。不填默认用官方 H5 页面</param>
        /// <param name="envVersion">默认值"release"。要打开的小程序版本。正式版为 "release"，体验版为"trial"，开发版为"develop"，仅在微信外打开时生效。</param>
        public Model(long? expireTime = default, long? expireType = default, long? expireInterval = default, CloudBase? cloudBase = default, string? envVersion = null)
        {
            ExpireTime = expireTime;
            ExpireType = expireType;
            ExpireInterval = expireInterval;
            CloudBase = cloudBase;
            EnvVersion = envVersion;
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

        /// <summary>
        /// 云开发静态网站自定义 H5 配置参数，可配置中转的云开发 H5 页面。不填默认用官方 H5 页面
        /// </summary>
        public CloudBase? CloudBase { get => GetValueOrDefault<CloudBase?>("cloud_base", null); set => this["cloud_base"] = value; }

        /// <summary>
        /// 默认值"release"。要打开的小程序版本。正式版为 "release"，体验版为"trial"，开发版为"develop"，仅在微信外打开时生效。
        /// </summary>
        public string? EnvVersion { get => TryGetValue("env_version", out var value) ? value?.ToString() : null; set => this["env_version"] = value; }
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
            var token = await GetAccessTokenAsync();

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
    /// <param name="expireTime">期失效的 scheme 码的失效时间，为 Unix 时间戳。生成的到期失效 scheme 码在该时间前有效。最长有效期为30天。is_expire 为 true 且 expire_type 为 0 时必填</param>
    /// <param name="expireType">默认值0，到期失效的 scheme 码失效类型，失效时间：0，失效间隔天数：1</param>
    /// <param name="expireInterval">到期失效的 scheme 码的失效间隔天数。生成的到期失效 scheme 码在该间隔时间到达前有效。最长间隔天数为30天。is_expire 为 true 且 expire_type 为 1 时必填</param>
    /// <param name="cloudBase">云开发静态网站自定义 H5 配置参数，可配置中转的云开发 H5 页面。不填默认用官方 H5 页面</param>
    /// <param name="envVersion">默认值"release"。要打开的小程序版本。正式版为 "release"，体验版为"trial"，开发版为"develop"，仅在微信外打开时生效。</param>
    /// <returns></returns>
    public static Request ToRequest(
        long? expireTime = default,
        long? expireType = default,
        long? expireInterval = default,
        CloudBase? cloudBase = default,
        string? envVersion = null)
        => new(new(expireTime, expireType, expireInterval, cloudBase, envVersion));
}