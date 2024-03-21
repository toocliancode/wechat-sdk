using System.Text;

namespace WeChat.Mp;

/// <summary>
/// 【微信公众号】获取临时素材
/// 
/// <para>文档：<a href="https://developers.weixin.qq.com/doc/offiaccount/Asset_Management/Get_temporary_materials.html"></a></para>
/// </summary>
public class MediaGet
{
    public static string Endpoint = "/cgi-bin/media/get?access_token={access_token}&media_id={media_id}";

    public class Response : WeChatMpHttpResponse
    {
        /// <summary>
        /// 内容类型
        /// </summary>
        public string? ContentType { get; set; }

        /// <summary>
        /// 视频格式时有值
        /// </summary>
        [JsonPropertyName("video_url")]
        public string? VideoUrl { get; set; }
    }

    /// <summary>
    /// 请求
    /// </summary>
    /// <param name="mediaId">媒体文件Id</param>
    public class Request(string mediaId) : WeChatMpHttpRequest<Response>
    {
        protected override async Task InitializeRequestMessageAsync(IHttpRequestContext context)
        {
            var token = await GetAccessTokenAsync();
            var url = $"{WeChatMpProperties.Domain}{Endpoint}".Replace("{access_token}", token).Replace("{media_id}", mediaId);

            context.Message.RequestUri = new Uri(url);
        }

        public override async Task<Response> Response(IHttpResponseContext context)
        {
            var content = await context.Message.Content.ReadAsStringAsync();
            Response? response = null;

            if (content != null && content.StartsWith("{") && content.EndsWith("}"))
            {
                try
                {
                    response = WeChatSerializer.Deserialize<Response>(content);
                }
                catch { }
            }

            response ??= new();
            response.Raw = Encoding.UTF8.GetBytes(content ?? string.Empty);
            response.StatusCode = context.Message.StatusCode;
            response.ContentType = context.Message.Content?.Headers?.ContentType?.MediaType;

            return response;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mediaId">媒体文件Id</param>
    /// <returns></returns>
    public static Request ToRequest(string mediaId) => new(mediaId);
}