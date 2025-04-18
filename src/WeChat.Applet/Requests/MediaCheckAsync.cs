namespace WeChat.Applet;

/// <summary>
/// 【微信小程序】多媒体内容安全识别
/// 
/// <para>文档：<a href="https://developers.weixin.qq.com/miniprogram/dev/OpenApiDoc/sec-center/sec-check/mediaCheckAsync.html"></a></para>
/// </summary>
public class MediaCheckAsync
{

    public static string Endpoint = "/wxa/media_check_async?access_token={access_token}";

    public class Response : WeChatAppletHttpResponse
    {
        /// <summary>
        /// 唯一请求标识，标记单次请求
        /// </summary>
        [JsonPropertyName("trace_id")]
        public string TraceId { get; set; }
    }

    public class Model : WeChatDictionary<object>
    {
        /// <summary>
        /// 要检测的图片或音频的url，支持图片格式包括jpg, jpeg, png, bmp, gif（取首帧），支持的音频格式包括mp3, aac, ac3, wma, flac, vorbis, opus, wav
        /// </summary>
        public string? MediaUrl { get => TryGetValue("media_url", out var value) ? value?.ToString() : null; set => this["media_url"] = value; }

        /// <summary>
        /// 1:音频;2:图片
        /// </summary>
        public string? MediaType { get => TryGetValue("media_type", out var value) ? value?.ToString() : null; set => this["media_type"] = value; }

        /// <summary>
        /// 接口版本号，2.0版本为固定值2
        /// </summary>
        public int? Version { get => TryGetValue("version", out var value) && int.TryParse(value?.ToString(), out var result) ? result : null; set => this["version"] = value; }

        /// <summary>
        /// 场景枚举值（1 资料；2 评论；3 论坛；4 社交日志）
        /// </summary>
        public int? Scene { get => TryGetValue("scene", out var value) && int.TryParse(value?.ToString(), out var result) ? result : null; set => this["scene"] = value; }

        /// <summary>
        /// 用户的 openid（用户需在近两小时访问过小程序）
        /// </summary>
        public string? OpenId { get => TryGetValue("openid", out var value) ? value?.ToString() : null; set => this["openid"] = value; }

        public Model()
        {
            Version = 2;
        }

        /// <param name="mediaUrl">要检测的图片或音频的url，支持图片格式包括jpg, jpeg, png, bmp, gif（取首帧），支持的音频格式包括mp3, aac, ac3, wma, flac, vorbis, opus, wav</param>
        /// <param name="mediaType">1:音频;2:图片</param>
        /// <param name="scene">场景枚举值（1 资料；2 评论；3 论坛；4 社交日志）</param>
        /// <param name="openId">用户的 openid（用户需在近两小时访问过小程序）</param>
        public Model(string mediaUrl, string mediaType, int scene, string openId) : base()
        {
            MediaUrl = mediaUrl;
            MediaType = mediaType;
            Scene = scene;
            OpenId = openId;
        }
    }

    public class Request : WeChatAppletHttpRequest<Response>
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
    }

    public static Request ToRequest() => new();

    /// <param name="mediaUrl">要检测的图片或音频的url，支持图片格式包括jpg, jpeg, png, bmp, gif（取首帧），支持的音频格式包括mp3, aac, ac3, wma, flac, vorbis, opus, wav</param>
    /// <param name="mediaType">1:音频;2:图片</param>
    /// <param name="scene">场景枚举值（1 资料；2 评论；3 论坛；4 社交日志）</param>
    /// <param name="openId">用户的 openid（用户需在近两小时访问过小程序）</param>
    public static Request ToRequest(string mediaUrl, string mediaType, int scene, string openId)
    {
        var model = new Model(mediaUrl, mediaType, scene, openId);
        var request = new Request(model);

        return request;
    }
}