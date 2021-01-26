using Mediator.HttpClient;

using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WeChat.Applet.Request.QrCode
{
    /// <summary>
    /// 创建小程序二维码请求
    /// 适用于需要的码数量较少的业务场景。通过该接口生成的小程序码，永久有效，有数量限制
    /// https://developers.weixin.qq.com/miniprogram/dev/api-backend/open-api/qr-code/wxacode.createQRCode.html
    /// </summary>
    public class WeChatCreateWxaQrCodeRequest : WeChatHttpRequestBase<WeChatResponse>, IEnableAccessToken
    {
        /// <summary>
        /// 实例化一个新的 创建小程序二维码 请求
        /// </summary>
        /// <param name="path">扫码进入的小程序页面路径，最大长度 128 字节，不能为空；对于小游戏，可以只传入 query 部分，来实现传参效果，如：传入 "?foo=bar"，即可在 wx.getLaunchOptionsSync 接口中的 query 参数获取到 {foo:"bar"}。</param>
        /// <param name="width">二维码的宽度，单位 px。最小 280px，最大 1280px。默认值 430</param>
        public WeChatCreateWxaQrCodeRequest(string path, int? width = 430)
        {
            Path = path;
            Width = width;
        }

        protected override string GetEndpointName() => WeChatAppletEndpoints.CreateQrCode;
        protected override HttpMethod GetHttpMethod() => HttpMethod.Post;

        /// <summary>
        /// 扫码进入的小程序页面路径，最大长度 128 字节，不能为空；对于小游戏，可以只传入 query 部分，来实现传参效果，如：传入 "?foo=bar"，即可在 wx.getLaunchOptionsSync 接口中的 query 参数获取到 {foo:"bar"}。
        /// </summary>
        [JsonPropertyName("path")]
        public string Path { get; set; }

        /// <summary>
        /// 二维码的宽度，单位 px。最小 280px，最大 1280px。
        /// 默认值 430
        /// </summary>
        [JsonPropertyName("width")]
        public int? Width { get; set; }

        protected override void ParameterHandler(WeChatConfiguration configuration)
        {
            Body
                .Set("path", Path)
                .Set("width", Width);
        }

        public override async Task<WeChatResponse> Response(IHttpResponseContext context)
        {
            var data = await context.Message.Content.ReadAsByteArrayAsync();
            WeChatResponse response;

            // 判断是否是图片内容
            if (data.Length < 200)
            {
                response = JsonSerializer.Deserialize<WeChatResponse>(data);
            }
            else
            {
                response = new WeChatResponse();
            }

            response.Raw = data;
            return response;
        }
    }
}
