using System.Text;

#pragma warning disable CS8601

namespace WeChat.Applet;

/// <summary>
/// 【微信小程序】获取不限制的小程序码
/// 
/// <para>文档：<a href="https://developers.weixin.qq.com/miniprogram/dev/OpenApiDoc/qrcode-link/qr-code/getUnlimitedQRCode.html"></a></para>
/// </summary>
public class GetUnlimitedQRCode
{
    public static string Endpoint = "/wxa/getwxacodeunlimit?access_token={access_token}";

    /// <summary>
    /// 默认是{"r":0,"g":0,"b":0} 。auto_color 为 false 时生效，使用 rgb 设置颜色 例如 {"r":"xxx","g":"xxx","b":"xxx"} 十进制表示
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
            string scene,
            string page,
            bool? checkPath,
            int? width = default,
            bool? autoColor = default,
            LineColor? lineColor = null,
            bool isHyaline = false,
            string? envVersion = null)
        {
            Scene = scene;
            Page = page;
            CheckPath = checkPath;
            Width = width;
            AutoColor = autoColor;
            LineColor = lineColor;
            IsHyaline = isHyaline;
            EnvVersion = envVersion;
        }

        /// <summary>
        /// 最大32个可见字符，只支持数字，大小写英文以及部分特殊字符：!#$&amp;'()*+,/:;=?@-._~，其它字符请自行编码为合法字符（因不支持%，中文无法使用 urlencode 处理，请使用其他编码方式）
        /// </summary>
        public string? Scene { get => TryGetValue("scene", out var value) ? value?.ToString() : null; set => this["scene"] = value; }

        /// <summary>
        /// 默认是主页，页面 page，例如 pages/index/index，根路径前不要填加 /，不能携带参数（参数请放在scene字段里），如果不填写这个字段，默认跳主页面。scancode_time为系统保留参数，不允许配置
        /// </summary>
        public string? Page { get => TryGetValue("page", out var value) ? value?.ToString() : null; set => this["page"] = value; }

        /// <summary>
        /// 默认是true，检查page 是否存在，为 true 时 page 必须是已经发布的小程序存在的页面（否则报错）；为 false 时允许小程序未发布或者 page 不存在， 但page 有数量上限（60000个）请勿滥用。
        /// </summary>
        public bool? CheckPath { get => TryGetValue("check_path", out var value) && bool.TryParse(value?.ToString(), out var result) ? result : null; set => this["check_path"] = value; }

        /// <summary>
        /// 二维码的宽度，单位 px。默认值为430，最小 280px，最大 1280px
        /// </summary>
        public int? Width { get => TryGetValue("width", out var value) && int.TryParse(value?.ToString(), out var result) ? result : null; set => this["width"] = value; }

        /// <summary>
        /// 自动配置线条颜色，如果颜色依然是黑色，则说明不建议配置主色调，默认 false
        /// </summary>
        public bool? AutoColor { get => TryGetValue("auto_color", out var value) && bool.TryParse(value?.ToString(), out var result) ? result : null; set => this["auto_color"] = value; }

        /// <summary>
        /// 默认值{"r":0,"g":0,"b":0} ；auto_color 为 false 时生效，使用 rgb 设置颜色 例如 {"r":"xxx","g":"xxx","b":"xxx"} 十进制表示
        /// </summary>
        public LineColor? LineColor { get => TryGetValue("line_color", out var value) && value is LineColor color ? color : null; set => this["line_color"] = value; }

        /// <summary>
        /// 默认是false，是否需要透明底色，为 true 时，生成透明底色的小程序
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
    /// <param name="scene">最大32个可见字符，只支持数字，大小写英文以及部分特殊字符：!#$&amp;'()*+,/:;=?@-._~，其它字符请自行编码为合法字符（因不支持%，中文无法使用 urlencode 处理，请使用其他编码方式）</param>
    /// <param name="page">默认是主页，页面 page，例如 pages/index/index，根路径前不要填加 /，不能携带参数（参数请放在scene字段里），如果不填写这个字段，默认跳主页面。scancode_time为系统保留参数，不允许配置</param>
    /// <param name="checkPath">默认是true，检查page 是否存在，为 true 时 page 必须是已经发布的小程序存在的页面（否则报错）；为 false 时允许小程序未发布或者 page 不存在， 但page 有数量上限（60000个）请勿滥用。</param>
    /// <param name="width">二维码的宽度，单位 px。默认值为430，最小 280px，最大 1280px</param>
    /// <param name="autoColor">自动配置线条颜色，如果颜色依然是黑色，则说明不建议配置主色调，默认 false</param>
    /// <param name="lineColor">默认值{"r":0,"g":0,"b":0} ；auto_color 为 false 时生效，使用 rgb 设置颜色 例如 {"r":"xxx","g":"xxx","b":"xxx"} 十进制表示</param>
    /// <param name="isHyaline">默认是false，是否需要透明底色，为 true 时，生成透明底色的小程序</param>
    /// <param name="envVersion">要打开的小程序版本。正式版为 "release"，体验版为 "trial"，开发版为 "develop"。默认是正式版。</param>
    /// <returns></returns>
    public static Request ToRequest(
        string scene,
        string page,
        bool? checkPath,
        int? width = default,
        bool? autoColor = default,
        LineColor? lineColor = null,
        bool isHyaline = false,
        string? envVersion = null)
        => new(new(scene, page, checkPath, width, autoColor, lineColor, isHyaline, envVersion));
}
