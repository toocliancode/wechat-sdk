using System.Text;

#pragma warning disable CS8601

namespace WeChat.Applet;

/// <summary>
/// 【微信小程序】获取小程序二维码
/// 
/// <para>文档：<a href="https://developers.weixin.qq.com/miniprogram/dev/OpenApiDoc/qrcode-link/qr-code/createQRCode.html"></a></para>
/// </summary>
public class CreateQRCode
{
    public static string Endpoint = "/cgi-bin/wxaapp/createwxaqrcode?access_token={access_token}";
    public class Model : WeChatDictionary<object>
    {
        public Model()
        {

        }
        public Model(
            string path,
            int? width = default)
        {
            Path = path;
            Width = width;
        }

        /// <summary>
        /// 扫码进入的小程序页面路径，最大长度 128 个字符，不能为空；对于小游戏，可以只传入 query 部分，来实现传参效果，如：传入 "?foo=bar"，即可在 wx.getLaunchOptionsSync 接口中的 query 参数获取到 {foo:"bar"}。scancode_time为系统保留参数，不允许配置。
        /// </summary>
        public string? Path { get => TryGetValue("path", out var value) ? value?.ToString() : null; set => this["path"] = value; }

        /// <summary>
        /// 二维码的宽度，单位 px。最小 280px，最大 1280px;默认是430
        /// </summary>
        public int? Width { get => TryGetValue("width", out var value) && int.TryParse(value?.ToString(), out var result) ? result : null; set => this["width"] = value; }

    }

    public class Request : WeChatAppletHttpRequest<WeChatAppletHttpResponse>
    {
        public Request() { }

        public Request(Model model) => Model = model;

        public Model Model { get; } = [];

        protected override async Task InitializeRequestMessageAsync(IHttpRequestContext context)
        {
            var token = await GetAccessTokenAsync();

            var url = $"{WeChatAppletProperties.Domain}{Endpoint}"
                .Replace("{access_token}", token)
                ;

            var content = WeChatSerializer.Serialize(Model);

            context.Message.Method = HttpMethod.Post;
            context.Message.RequestUri = new Uri(url);
            context.Message.Content = new StringContent(content);
        }
        public override async Task<WeChatAppletHttpResponse> Response(IHttpResponseContext context)
        {
            var content = await context.Message.Content.ReadAsStringAsync();
            WeChatAppletHttpResponse? response = null;

            if (content != null && content.StartsWith("{") && content.EndsWith("}"))
            {
                try
                {
                    response = WeChatSerializer.Deserialize<WeChatAppletHttpResponse>(content);
                }
                catch { }
            }

            response ??= new();
            response.Raw = Encoding.UTF8.GetBytes(content ?? string.Empty);
            response.StatusCode = context.Message.StatusCode;

            return response;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="path">扫码进入的小程序页面路径，最大长度 128 个字符，不能为空；对于小游戏，可以只传入 query 部分，来实现传参效果，如：传入 "?foo=bar"，即可在 wx.getLaunchOptionsSync 接口中的 query 参数获取到 {foo:"bar"}。scancode_time为系统保留参数，不允许配置。</param>
    /// <param name="width">二维码的宽度，单位 px。最小 280px，最大 1280px;默认是430</param>
    /// <returns></returns>
    public static Request ToRequest(string path, int? width = default) => new(new(path, width));
}