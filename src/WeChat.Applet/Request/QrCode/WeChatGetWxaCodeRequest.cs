using Mediator.HttpClient;

using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

using WeChat.Applet.Response.QrCode;

namespace WeChat.Applet.Request.QrCode
{
    /// <summary>
    /// 获取小程序码，适用于需要的码数量较少的业务场景。通过该接口生成的小程序码，永久有效，有数量限制。
    /// https://developers.weixin.qq.com/miniprogram/dev/api-backend/open-api/qr-code/wxacode.get.html
    /// </summary>
    public class WeChatGetWxaCodeRequest : WeChatHttpRequestBase<WeChatResponse>, IEnableAccessToken
    {
        /// <summary>
        /// 实例化一个新的 获取小程序码 请求
        /// </summary>
        /// <param name="path">扫码进入的小程序页面路径，最大长度 128 字节，不能为空；对于小游戏，可以只传入 query 部分，来实现传参效果，如：传入 "?foo=bar"，即可在 wx.getLaunchOptionsSync 接口中的 query 参数获取到 {foo:"bar"}。</param>
        /// <param name="width">二维码的宽度，单位 px。最小 280px，最大 1280px</param>
        /// <param name="autoColor">自动配置线条颜色，如果颜色依然是黑色，则说明不建议配置主色调</param>
        /// <param name="lineColor">auto_color 为 false 时生效，使用 rgb 设置颜色 例如 {"r":"xxx","g":"xxx","b":"xxx"} 十进制表示</param>
        /// <param name="isHyaline">是否需要透明底色，为 true 时，生成透明底色的小程序码</param>
        public WeChatGetWxaCodeRequest(
            string path,
            int width = 430,
            bool autoColor = false,
            QrCodeLineColor lineColor = null,
            bool isHyaline = false)
        {
            Path = path;
            Width = width;
            AutoColor = autoColor;
            LineColor = lineColor;
            IsHyaline = isHyaline;
        }

        protected override string EndpointName => WeChatAppletEndpoints.GetWxaCode;

        protected override HttpMethod Method => HttpMethod.Post;

        /// <summary>
        /// 扫码进入的小程序页面路径，最大长度 128 字节，不能为空；对于小游戏，可以只传入 query 部分，来实现传参效果，如：传入 "?foo=bar"，即可在 wx.getLaunchOptionsSync 接口中的 query 参数获取到 {foo:"bar"}。
        /// </summary>
        [JsonPropertyName("path")]
        public string Path { get; set; }

        /// <summary>
        /// 二维码的宽度，单位 px。最小 280px，最大 1280px
        /// </summary>
        [JsonPropertyName("width")]
        public int Width { get; set; } = 430;

        /// <summary>
        /// 自动配置线条颜色，如果颜色依然是黑色，则说明不建议配置主色调
        /// </summary>
        [JsonPropertyName("auto_color")]
        public bool AutoColor { get; set; }

        /// <summary>
        /// auto_color 为 false 时生效，使用 rgb 设置颜色 例如 {"r":"xxx","g":"xxx","b":"xxx"} 十进制表示
        /// </summary>
        [JsonPropertyName("line_color")]
        public QrCodeLineColor LineColor { get; set; }

        /// <summary>
        /// 是否需要透明底色，为 true 时，生成透明底色的小程序码
        /// </summary>
        [JsonPropertyName("is_hyaline")]
        public bool IsHyaline { get; set; }

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
