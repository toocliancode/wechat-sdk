using System.Text;

#pragma warning disable CS8601

namespace WeChat.Applet;

/// <summary>
/// 【微信小程序】获取小程序码
/// 
/// <para>文档：<a href="https://developers.weixin.qq.com/miniprogram/dev/OpenApiDoc/qrcode-link/qr-code/getQRCode.html"></a></para>
/// </summary>
public class GetQRCode
{
    public static string Endpoint = "/wxa/getwxacode?access_token={access_token}";

    /// <summary>
    /// 默认值{"r":0,"g":0,"b":0} ；auto_color 为 false 时生效，使用 rgb 设置颜色 例如 {"r":"xxx","g":"xxx","b":"xxx"} 十进制表示
    /// </summary>
    public class LineColor
    {
        [JsonPropertyName("r")]
        public int R { get; set; }

        [JsonPropertyName("g")]
        public int G { get; set; }

        [JsonPropertyName("b")]
        public int B { get; set; }
    }

    public class Model : WeChatDictionary<object>
    {
        public Model()
        {

        }
        public Model(
            string path,
            int? width = null,
            bool autoColor = false,
            LineColor? lineColor = null,
            bool isHyaline = false,
            string? envVersion = null)
        {
            Path = path;
            Width = width;
            AutoColor = autoColor;
            LineColor = lineColor;
            IsHyaline = isHyaline;
            EnvVersion = envVersion;
        }

        /// <summary>
        /// 扫码进入的小程序页面路径，最大长度 1024 个字符，不能为空，scancode_time为系统保留参数，不允许配置；对于小游戏，可以只传入 query 部分，来实现传参效果，如：传入 "?foo=bar"，即可在 wx.getLaunchOptionsSync 接口中的 query 参数获取到 {foo:"bar"}。
        /// </summary>
        public string? Path { get => TryGetValue("path", out var value) ? value?.ToString() : null; set => this["path"] = value; }

        /// <summary>
        /// 二维码的宽度，单位 px。默认值为430，最小 280px，最大 1280px
        /// </summary>
        public int? Width { get => TryGetValue("width", out var value) && int.TryParse(value?.ToString(), out var result) ? result : null; set => this["width"] = value; }

        /// <summary>
        /// 默认值false；自动配置线条颜色，如果颜色依然是黑色，则说明不建议配置主色调
        /// </summary>
        public bool? AutoColor { get => TryGetValue("auto_color", out var value) && bool.TryParse(value?.ToString(), out var result) ? result : null; set => this["auto_color"] = value; }

        /// <summary>
        /// 默认值{"r":0,"g":0,"b":0} ；auto_color 为 false 时生效，使用 rgb 设置颜色 例如 {"r":"xxx","g":"xxx","b":"xxx"} 十进制表示
        /// </summary>
        public LineColor? LineColor { get => TryGetValue("line_color", out var value) && value is LineColor color ? color : null; set => this["line_color"] = value; }

        /// <summary>
        /// 默认值false；是否需要透明底色，为 true 时，生成透明底色的小程序码
        /// </summary>
        public bool? IsHyaline { get => TryGetValue("is_hyaline", out var value) && bool.TryParse(value?.ToString(), out var result) ? result : null; set => this["is_hyaline"] = value; }

        /// <summary>
        /// 要打开的小程序版本。正式版为 "release"，体验版为 "trial"，开发版为 "develop"。默认是正式版。
        /// </summary>
        public string? EnvVersion { get => TryGetValue("env_version", out var value) ? value?.ToString() : null; set => this["env_version"] = value; }

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
    /// <param name="path">扫码进入的小程序页面路径，最大长度 1024 个字符，不能为空，scancode_time为系统保留参数，不允许配置；对于小游戏，可以只传入 query 部分，来实现传参效果，如：传入 "?foo=bar"，即可在 wx.getLaunchOptionsSync 接口中的 query 参数获取到 {foo:"bar"}。</param>
    /// <param name="width">二维码的宽度，单位 px。默认值为430，最小 280px，最大 1280px</param>
    /// <param name="autoColor">默认值false；自动配置线条颜色，如果颜色依然是黑色，则说明不建议配置主色调</param>
    /// <param name="lineColor">默认值{"r":0,"g":0,"b":0} ；auto_color 为 false 时生效，使用 rgb 设置颜色 例如 {"r":"xxx","g":"xxx","b":"xxx"} 十进制表示</param>
    /// <param name="isHyaline">默认值false；是否需要透明底色，为 true 时，生成透明底色的小程序码</param>
    /// <param name="envVersion"> 要打开的小程序版本。正式版为 "release"，体验版为 "trial"，开发版为 "develop"。默认是正式版。</param>
    /// <returns></returns>
    public static Request ToRequest(
        string path,
        int? width = null,
        bool autoColor = false,
        LineColor? lineColor = null,
        bool isHyaline = false,
        string? envVersion = null)
        => new(new(path, width, autoColor, lineColor, isHyaline, envVersion));
}
