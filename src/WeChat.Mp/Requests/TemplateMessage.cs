namespace WeChat.Mp;

/// <summary>
/// 模板消息
/// </summary>
public class TemplateMessage
{
    public class SendResponse : WeChatMpHttpResponse
    {
        /// <summary>
        /// 消息Id
        /// </summary>
        [JsonPropertyName("msgid")]
        public long MsgId { get; set; }
    }

    public class SendModel
    {
        /// <summary>
        /// 接收者openid
        /// </summary>
        [JsonPropertyName("touser")]
        public string ToUser { get; set; }

        /// <summary>
        /// 模板Id
        /// </summary>
        [JsonPropertyName("template_id")]
        public string TemplateId { get; set; }

        /// <summary>
        /// 模板跳转链接（海外帐号没有跳转能力）
        /// </summary>
        [JsonPropertyName("url")]
        public string? Url { get; set; }

        /// <summary>
        /// 跳小程序所需数据，不需跳小程序可不用传该数据
        /// appid:所需跳转到的小程序appid（该小程序appid必须与发模板消息的公众号是绑定关联关系，暂不支持小游戏）
        /// pagepath:所需跳转到小程序的具体页面路径，支持带参数,（示例index?foo=bar），要求该小程序已发布，暂不支持小游戏
        /// </summary>
        [JsonPropertyName("miniprogram")]
        public IDictionary<string, string>? MiniProgram { get; set; }

        /// <summary>
        /// 模板数据
        /// name:{
        ///     value:"",
        ///     color:""
        /// }
        /// </summary>
        [JsonPropertyName("data")]
        public IDictionary<string, IDictionary<string, string>> Data { get; set; }

        /// <summary>
        /// 防重入id。对于同一个openid + client_msg_id, 只发送一条消息,10分钟有效,超过10分钟不保证效果。若无防重入需求，可不填
        /// </summary>
        [JsonPropertyName("client_msg_id")]
        public string? ClientMsgId { get; set; }
    }

    /// <summary>
    /// 【微信服务号】发送模板消息
    /// 
    /// <para>文档：<a href="https://developers.weixin.qq.com/doc/service/api/notify/template/api_sendtemplatemessage.html"></a></para>
    /// </summary>
    public class SendRequest : WeChatMpHttpRequest<SendResponse>
    {
        public static string Endpoint = "/cgi-bin/message/template/send?access_token={access_token}";

        private SendModel _model;

        protected override async Task InitializeRequestMessageAsync(IHttpRequestContext context)
        {
            var token = await GetAccessTokenAsync();
            var url = $"{WeChatMpProperties.Domain}{Endpoint}".Replace("{access_token}", token);
            context.Message.RequestUri = new Uri(url);
            context.Message.Method = HttpMethod.Post;
            context.Message.Content = new StringContent(WeChatSerializer.Serialize(_model), System.Text.Encoding.UTF8, "application/json");
        }

        public SendRequest WithModel(SendModel model)
        {
            _model = model;
            return this;
        }
    }
}