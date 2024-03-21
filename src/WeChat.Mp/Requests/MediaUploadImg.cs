using System.Net.Http.Headers;

namespace WeChat.Mp;

/// <summary>
/// 【微信公众号】上传图文消息内的图片获取URL
/// 
/// <para>文档：<a href="https://developers.weixin.qq.com/doc/offiaccount/Cards_and_Offer/Create_a_Coupon_Voucher_or_Card.html#5"></a></para>
/// </summary>
public class MediaUploadImg
{
    public static string Endpoint = "/cgi-bin/media/uploadimg?access_token={access_token}";

    public class Response : WeChatMpHttpResponse
    {
        /// <summary>
        /// 商户图片 url，用于创建卡券接口中填入。
        /// 特别注意：该链接仅用于微信相关业务，不支持引用。
        /// </summary>
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

    public class Request(byte[] buffer) : WeChatMpHttpRequest<Response>
    {
        protected override async Task InitializeRequestMessageAsync(IHttpRequestContext context)
        {
            var token = await GetAccessTokenAsync();
            var url = $"{WeChatMpProperties.Domain}{Endpoint}".Replace("{access_token}", token);
            var boundary = Guid.NewGuid().ToString();
            var body = new MultipartFormDataContent(boundary);

            body.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data;boundary=" + boundary);
            body.Add(new ByteArrayContent(buffer));

            context.Message.Method = HttpMethod.Post;
            context.Message.RequestUri = new Uri(url);
            context.Message.Content = body;
        }
    }

    public static Request ToRequest(byte[] buffer) => new(buffer);
}