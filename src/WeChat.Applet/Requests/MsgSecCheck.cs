namespace WeChat.Applet;

/// <summary>
/// 【微信小程序】文本内容安全识别
/// 
/// <para>文档：<a href="https://developers.weixin.qq.com/miniprogram/dev/OpenApiDoc/sec-center/sec-check/msgSecCheck.html"></a></para>
/// </summary>
public class MsgSecCheck
{
    public static string Endpoint = "/wxa/msg_sec_check?access_token={access_token}";

    public class DetailInfo
    {
        /// <summary>
        /// 策略类型
        /// </summary>
        [JsonPropertyName("strategy")]
        public string? Strategy { get; set; }

        /// <summary>
        /// 错误码，仅当该值为0时，该项结果有效
        /// </summary>
        [JsonPropertyName("errcode")]
        public int? ErrCode { get; set; }

        /// <summary>
        /// 建议，有risky、pass、review三种值
        /// </summary>
        [JsonPropertyName("suggest")]
        public string? Suggest { get; set; }

        /// <summary>
        /// 命中标签枚举值，
        /// 100 正常；
        /// 10001 广告；
        /// 20001 时政；
        /// 20002 色情；
        /// 20003 辱骂；
        /// 20006 违法犯罪；
        /// 20008 欺诈；
        /// 20012 低俗；
        /// 20013 版权；
        /// 21000 其他
        /// </summary>
        [JsonPropertyName("label")]
        public int? Label { get; set; }

        /// <summary>
        /// 命中的自定义关键词
        /// </summary>
        [JsonPropertyName("keyword")]
        public string? Keyword { get; set; }

        /// <summary>
        /// 0-100，代表置信度，越高代表越有可能属于当前返回的标签（label）
        /// </summary>
        [JsonPropertyName("prob")]
        public int? Prob { get; set; }
    }

    public class ResultInfo
    {
        /// <summary>
        /// 建议，有risky、pass、review三种值
        /// </summary>
        [JsonPropertyName("suggest")]
        public string? Suggest { get; set; }

        /// <summary>
        /// 命中标签枚举值，
        /// 100 正常；
        /// 10001 广告；
        /// 20001 时政；
        /// 20002 色情；
        /// 20003 辱骂；
        /// 20006 违法犯罪；
        /// 20008 欺诈；
        /// 20012 低俗；
        /// 20013 版权；
        /// 21000 其他
        /// </summary>
        [JsonPropertyName("label")]
        public int? Label { get; set; }
    }

    public class Response : WeChatAppletHttpResponse
    {
        /// <summary>
        /// 唯一请求标识，标记单次请求
        /// </summary>
        [JsonPropertyName("trace_id")]
        public string TraceId { get; set; }

        /// <summary>
        /// 详细检测结果
        /// </summary>
        [JsonPropertyName("detail")]
        public List<DetailInfo>? Detail { get; set; }

        /// <summary>
        /// 综合结果
        /// </summary>
        [JsonPropertyName("result")]
        public ResultInfo? Result { get; set; }
    }

    public class Model : WeChatDictionary<object>
    {
        /// <summary>
        /// 需检测的文本内容，文本字数的上限为2500字，需使用UTF-8编码
        /// </summary>
        public string? Content { get => TryGetValue("content", out var value) ? value?.ToString() : null; set => this["content"] = value; }

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

        /// <summary>
        /// 文本标题，需使用UTF-8编码
        /// </summary>
        public string? Title { get => TryGetValue("title", out var value) ? value?.ToString() : null; set => this["title"] = value; }

        /// <summary>
        /// 用户昵称，需使用UTF-8编码
        /// </summary>
        public string? NickName { get => TryGetValue("nickname", out var value) ? value?.ToString() : null; set => this["nickname"] = value; }

        /// <summary>
        /// 个性签名，该参数仅在资料类场景有效(scene=1)，需使用UTF-8编码
        /// </summary>
        public string? Signature { get => TryGetValue("signature", out var value) ? value?.ToString() : null; set => this["signature"] = value; }

        public Model()
        {
            Version = 2;
        }

        /// <param name="content">需检测的文本内容，文本字数的上限为2500字，需使用UTF-8编码</param>
        /// <param name="scene">场景枚举值（1 资料；2 评论；3 论坛；4 社交日志）</param>
        /// <param name="openId">用户的 openid（用户需在近两小时访问过小程序）</param>
        public Model(string content, int scene, string openId) : base()
        {
            Content = content;
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

    /// <param name="content">需检测的文本内容，文本字数的上限为2500字，需使用UTF-8编码</param>
    /// <param name="scene">场景枚举值（1 资料；2 评论；3 论坛；4 社交日志）</param>
    /// <param name="openId">用户的 openid（用户需在近两小时访问过小程序）</param>
    public static Request ToRequest(string content, int scene, string openId)
    {
        var model = new Model(content, scene, openId);
        var request = new Request(model);

        return request;
    }
}