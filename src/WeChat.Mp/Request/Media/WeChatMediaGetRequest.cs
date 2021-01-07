
using Mediator.HttpClient;

using System.Threading.Tasks;

using WeChat.Mp.Response;

namespace WeChat.Mp.Request
{
    /// <summary>
    /// 获取临时素材 请求
    /// </summary>
    public class WeChatMediaGetRequest : WeChatHttpRequestBase<WeChatMediaGetResponse>, IEnableAccessToken
    {
        protected override string GetEndpointName() => WeChatMpEndpoints.MediaGet;

        /// <summary>
        /// 媒体文件Id
        /// </summary>
        public string MediaId { get; set; }

        protected override void ParameterHandler(WeChatConfiguration configuration)
        {
            Body
                .Set("media_id", MediaId);
        }

        public override async Task<WeChatMediaGetResponse> ParserAsync(IHttpResponseContext context)
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
