
using System;
using System.Net.Http;
using System.Text.Json.Serialization;

using WeChat.Applet.Response;

namespace WeChat.Applet.Request
{
    /// <summary>
    /// 获取小程序 scheme 码，适用于短信、邮件、外部网页、微信内等拉起小程序的业务场景。通过该接口，可以选择生成到期失效和永久有效的小程序码
    /// https://developers.weixin.qq.com/miniprogram/dev/api-backend/open-api/url-scheme/urlscheme.generate.html
    /// </summary>
    public class WeChatAppletGenerateSchemeRequest
        : WeChatAppletHttpRequestBase<WeChatAppletGenerateSchemeResponse>
        , IEnableAccessToken
    {
        protected override string EndpointName => WeChatAppletEndpoints.GenerateScheme;
        protected override HttpMethod Method => HttpMethod.Post;

        /// <summary>
        /// 跳转到的目标小程序信息
        /// </summary>
        [JsonPropertyName("jump_wxa")]
        public GenerateSchemeJumpWxa JumpWxa { get; set; }

        /// <summary>
        /// 生成的 scheme 码类型，到期失效：true，永久有效：false
        /// </summary>
        [JsonPropertyName("is_expire")]
        public bool IsExpire { get; set; }

        /// <summary>
        /// 到期失效的 scheme 码失效类型，失效时间：0，失效间隔天数：1
        /// </summary>
        [JsonPropertyName("expire_type")]
        public int ExpireType { get; set; }

        /// <summary>
        /// 到期失效的 scheme 码的失效时间，为 Unix 时间戳。生成的到期失效 scheme 码在该时间前有效。最长有效期为1年。is_expire 为 true 且 expire_type 为 0 时必填
        /// </summary>
        [JsonPropertyName("expire_time")]
        public DateTime? ExpireTime { get; set; }

        /// <summary>
        /// 到期失效的 scheme 码的失效间隔天数。生成的到期失效 scheme 码在该间隔时间到达前有效。最长间隔天数为365天。is_expire 为 true 且 expire_type 为 1 时必填
        /// </summary>
        [JsonPropertyName("expire_interval")]
        public int? ExpireInterval { get; set; }

        //public override async Task Request(IHttpRequestContext context)
        //{
        //    var options = context.RequestServices.GetRequiredService<IOptions<WeChatOptions>>().Value;

        //    if (string.IsNullOrWhiteSpace(Configuration.AppId))
        //    {
        //        var configuration = options.GetConfiguration(Configuration.Name);
        //        Configuration.Configure(configuration.AppId, configuration.Secret);
        //    }

        //    var dict = new Dictionary<string, object>();
        //    if (JumpWxa != null)
        //    {
        //        dict["jump_wxa"] = JumpWxa;
        //    }
        //    if (IsExpire)
        //    {
        //        dict["is_expire"] = true;
        //    }
        //    if (ExpireType == 1)
        //    {
        //        dict["expire_type"] = 1;
        //    }
        //    if (IsExpire && ExpireType == 0)
        //    {
        //        ExpireTime ??= DateTime.Now.AddYears(1);
        //        dict["expire_time"] = new DateTimeOffset(ExpireTime.Value).ToUnixTimeSeconds();
        //    }
        //    if (IsExpire && ExpireType == 1)
        //    {
        //        ExpireInterval ??= 365;
        //        dict["expire_interval"] = ExpireInterval;
        //    }
        //    var endpoint = options.GetEndpoint(EndpointName);

        //    var token = await context.RequestServices.GetRequiredService<IWeChatAccessTokenStore>()
        //        .GetAsync(Configuration.AppId, Configuration.Secret);
        //    context.Message.RequestUri = new Uri($"{endpoint}?access_token={token}");
        //    context.Message.Content = new StringContent(JsonSerializer.Serialize(dict, SerializerOptions));
        //    context.Message.Method = Method;
        //}
    }

    /// <summary>
    /// 跳转到的目标小程序信息
    /// </summary>
    public class GenerateSchemeJumpWxa
    {
        /// <summary>
        /// 通过 scheme 码进入的小程序页面路径，必须是已经发布的小程序存在的页面，不可携带 query。path 为空时会跳转小程序主页。
        /// </summary>
        [JsonPropertyName("path")]
        public string Path { get; set; }

        /// <summary>
        /// 通过 scheme 码进入小程序时的 query，最大1024个字符，只支持数字，大小写英文以及部分特殊字符：!#$&amp;'()*+,/:;=?@-._~%
        /// </summary>
        [JsonPropertyName("query")]
        public string Query { get; set; }
    }
}
