using System.Net.Http;
using System.Text.Json.Serialization;

using WeChat.Applet.Response;

namespace WeChat.Applet.Request
{
    /// <summary>
    /// 获取小程序 URL Link，适用于短信、邮件、网页、微信内等拉起小程序的业务场景。通过该接口，可以选择生成到期失效和永久有效的小程序链接
    /// https://developers.weixin.qq.com/miniprogram/dev/api-backend/open-api/url-link/urllink.generate.html
    /// </summary>
    public class WeChatAppletGenerateUrlLinkRequest
           : WeChatAppletHttpRequestBase<WeChatAppletGenerateUrlLinkResponse>
        , IEnableAccessToken
    {
        protected override string EndpointName => WeChatAppletEndpoints.GenerateUrlLink;
        protected override HttpMethod Method => HttpMethod.Post;

        /// <summary>
        /// 通过 URL Link 进入的小程序页面路径，必须是已经发布的小程序存在的页面，不可携带 query 。path 为空时会跳转小程序主页
        /// </summary>
        [JsonPropertyName("path")]
        public string Path { get; set; }

        /// <summary>
        /// 通过 URL Link 进入小程序时的query，最大1024个字符，只支持数字，大小写英文以及部分特殊字符：!#$&amp;'()*+,/:;=?@-._~%
        /// </summary>
        [JsonPropertyName("query")]
        public string Query { get; set; }

        /// <summary>
        /// 生成的 URL Link 类型，到期失效：true，永久有效：false
        /// </summary>
        [JsonPropertyName("is_expire")]
        public bool? IsExpire { get; set; }

        /// <summary>
        /// 小程序 URL Link 失效类型，失效时间：0，失效间隔天数：1
        /// </summary>
        [JsonPropertyName("expire_type")]
        public int? ExpireType { get; set; }

        /// <summary>
        /// 到期失效的 URL Link 的失效时间，为 Unix 时间戳。生成的到期失效 URL Link 在该时间前有效。最长有效期为1年。expire_type 为 0 必填
        /// </summary>
        [JsonPropertyName("expire_time")]
        public long? ExpireTime { get; set; }

        /// <summary>
        /// 到期失效的URL Link的失效间隔天数。生成的到期失效URL Link在该间隔时间到达前有效。最长间隔天数为365天。expire_type 为 1 必填
        /// </summary>
        [JsonPropertyName("expire_interval")]
        public int? ExpireInterval { get; set; }

        /// <summary>
        /// 云开发静态网站自定义 H5 配置参数，可配置中转的云开发 H5 页面。不填默认用官方 H5 页面
        /// </summary>
        [JsonPropertyName("cloud_base")]
        public GenerateUrlLinkCcloudBase CcloudBase { get; set; }
    }


    /// <summary>
    /// 云开发静态网站自定义 H5 配置参数
    /// </summary>
    public class GenerateUrlLinkCcloudBase
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
        public string Domain { get; set; }

        /// <summary>
        /// 云开发静态网站 H5 页面路径，不可携带 query
        /// </summary>
        [JsonPropertyName("path")]
        public string Path { get; set; } = "/";

        /// <summary>
        /// 云开发静态网站 H5 页面 query 参数，最大 1024 个字符，只支持数字，大小写英文以及部分特殊字符：!#$&amp;'()*+,/:;=?@-._~%
        /// </summary>
        [JsonPropertyName("query")]
        public string Query { get; set; }

        /// <summary>
        /// 第三方批量代云开发时必填，表示创建该 env 的 appid （小程序/第三方平台）
        /// </summary>
        [JsonPropertyName("resource_appid")]
        public string ResourceAppid { get; set; }
    }
}
