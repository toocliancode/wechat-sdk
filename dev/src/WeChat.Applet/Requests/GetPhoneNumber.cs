using Mediation.HttpClient;

using Microsoft.Extensions.DependencyInjection;

using System.Text.Json.Serialization;

namespace WeChat.Applet;

/// <summary>
/// 【微信小程序】获取手机号
/// 
/// <para>文档：<a href="https://developers.weixin.qq.com/miniprogram/dev/OpenApiDoc/user-info/phone-number/getPhoneNumber.html"></a></para>
/// </summary>
public class GetPhoneNumber
{
    public static string Endpoint = "/wxa/business/getuserphonenumber?access_token={access_token}&code={code}&openid={openid}";

    public class PhoneNumberInfo
    {
        /// <summary>
        /// 用户绑定的手机号（国外手机号会有区号）
        /// </summary>
        [JsonPropertyName("phoneNumber")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 没有区号的手机号
        /// </summary>
        [JsonPropertyName("purePhoneNumber")]
        public string PurePhoneNumber { get; set; }

        /// <summary>
        /// 区号
        /// </summary>
        [JsonPropertyName("countryCode")]
        public string CountryCode { get; set; }

        /// <summary>
        /// 数据水印
        /// </summary>
        [JsonPropertyName("watermark")]
        public Watermark Watermark { get; set; }
    }

    public class Watermark
    {
        /// <summary>
        /// 小程序appid
        /// </summary>
        [JsonPropertyName("appid")]
        public string AppId { get; set; }

        /// <summary>
        /// 用户获取手机号操作的时间戳
        /// </summary>
        [JsonPropertyName("timestamp")]
        public long Timestamp { get; set; }
    }

    public class Response : WeChatAppletHttpResponse
    {
        /// <summary>
        /// 用户手机号信息
        /// </summary>
        [JsonPropertyName("phone_info")]
        public PhoneNumberInfo PhoneInfo { get; set; }
    }

    /// <param name="code">手机号获取凭证</param>
    /// <param name="openid">用户唯一标识</param>
    public class Request(string code, string? openid = default) : WeChatAppletHttpRequest<Response>
    {
        protected override async Task InitializeRequestMessageAsync(IHttpRequestContext context)
        {
            var token = await context.RequestServices.GetRequiredService<IWeChatAppletAccessTokenStore>().GetAsync();

            var url = $"{WeChatAppletProperties.Domain}{Endpoint}"
                .Replace("{access_token}", token)
                .Replace("{code}", code)
                .Replace("{openid}", openid)
                ;

            context.Message.Method = HttpMethod.Get;
            context.Message.RequestUri = new Uri(url);
        }
    }
}