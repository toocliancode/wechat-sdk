
using Mediator.HttpClient;

using System.Text.Json.Serialization;
using System.Threading.Tasks;

using WeChat.Mp.Response;

namespace WeChat.Mp.Request
{
    /// <summary>
    /// 获取临时素材 请求
    /// </summary>
    public class WeChatMpMediaGetRequest : WeChatMpHttpRequestBase<WeChatMpMediaGetResponse>, IEnableAccessToken
    {
        /// <summary>
        /// 实例化一个新的 获取临时素材 请求
        /// </summary>
        /// <param name="mediaId">媒体文件Id</param>
        public WeChatMpMediaGetRequest(string mediaId)
        {
            MediaId = mediaId;
        }

        protected override string EndpointName => WeChatMpEndpoints.MediaGet;

        /// <summary>
        /// 媒体文件Id
        /// </summary>
        [JsonPropertyName("media_id")]
        public string MediaId { get; set; }

        public override async Task<WeChatMpMediaGetResponse> Response(IHttpResponseContext context)
        {
            var content = await context.Message.Content.ReadAsByteArrayAsync();
            WeChatMpMediaGetResponse response;
            if (content.Length < 200)
            {
                try
                {
                    response = System.Text.Json.JsonSerializer.Deserialize<WeChatMpMediaGetResponse>(content);
                }
                catch
                {
                    response = new WeChatMpMediaGetResponse();
                }
            }
            else
            {
                response = new WeChatMpMediaGetResponse();
            }

            response.Raw = content;
            response.ContentType = context.Message.Content?.Headers?.ContentType?.MediaType;
            return response;
        }
    }
}
