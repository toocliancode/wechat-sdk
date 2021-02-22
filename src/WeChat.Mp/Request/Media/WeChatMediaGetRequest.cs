
using Mediator.HttpClient;

using System.Text.Json.Serialization;
using System.Threading.Tasks;

using WeChat.Mp.Response;

namespace WeChat.Mp.Request
{
    /// <summary>
    /// 获取临时素材 请求
    /// </summary>
    public class WeChatMediaGetRequest : WeChatHttpRequestBase<WeChatMediaGetResponse>, IEnableAccessToken
    {
        /// <summary>
        /// 实例化一个新的 获取临时素材 请求
        /// </summary>
        /// <param name="mediaId">媒体文件Id</param>
        public WeChatMediaGetRequest(string mediaId)
        {
            MediaId = mediaId;
        }

        protected override string EndpointName => WeChatMpEndpoints.MediaGet;

        /// <summary>
        /// 媒体文件Id
        /// </summary>
        [JsonPropertyName("media_id")]
        public string MediaId { get; set; }

        public override async Task<WeChatMediaGetResponse> Response(IHttpResponseContext context)
        {
            var content = await context.Message.Content.ReadAsByteArrayAsync();
            WeChatMediaGetResponse response;
            if (content.Length < 200)
            {
                try
                {
                    response = System.Text.Json.JsonSerializer.Deserialize<WeChatMediaGetResponse>(content);
                }
                catch
                {
                    response = new WeChatMediaGetResponse();
                }
            }
            else
            {
                response = new WeChatMediaGetResponse();
            }

            response.Raw = content;
            response.ContentType = context.Message.Content?.Headers?.ContentType?.MediaType;
            return response;
        }
    }
}
