namespace WeChat.Mp.Card;

/// <summary>
/// 【卡券】图文消息群发卡券内容
/// </summary>
/// <remarks>
/// 支持开发者调用该接口获取卡券嵌入图文消息的标准格式代码，将返回代码填入 新增临时素材中content字段，即可获取嵌入卡券的图文消息素材。
/// 特别注意：目前该接口仅支持填入非自定义code的卡券,自定义code的卡券需先进行code导入后调用。
/// </remarks>
public class WeChatMpCardMpNewsGetHtmlRequest
    : WeChatHttpRequest<WeChatMpCardMpNewsGetHtmlResponse>
    , IHasAccessToken
{
    public static string Endpoint = "/card/mpnews/gethtml?access_token={access_token}";

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpCardMpNewsGetHtmlRequest"/>
    /// </summary>
    public WeChatMpCardMpNewsGetHtmlRequest()
        : base(HttpMethod.Post)
    {
    }

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpCardMpNewsGetHtmlRequest"/>
    /// </summary>
    /// <param name="cardId">需要进行导入code的卡券Id</param>
    public WeChatMpCardMpNewsGetHtmlRequest(string cardId)
        : base(HttpMethod.Post)
    {
        CardId = cardId;
    }

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpCardMpNewsGetHtmlRequest"/>
    /// </summary>
    /// <param name="cardId">卡券Id</param>
    /// <param name="accessToken"></param>
    public WeChatMpCardMpNewsGetHtmlRequest(
        string cardId,
        string accessToken)
        : base(HttpMethod.Post)
    {
        AccessToken = accessToken;
        CardId = cardId;
    }

    [JsonIgnore]
    public string? AccessToken { get; set; }

    /// <summary>
    /// 卡券Id
    /// </summary>
    [JsonPropertyName("CardId")]
    public string CardId { get; set; }

    protected override string GetRequestUri() => $"{WeChatProperties.Domain}{Endpoint}"
        .Replace("{access_token}", AccessToken);
}