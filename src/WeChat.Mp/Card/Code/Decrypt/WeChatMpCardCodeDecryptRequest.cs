namespace WeChat.Mp.Card;

/// <summary>
/// 【卡券】加密Code解码
/// <a href="https://developers.weixin.qq.com/doc/offiaccount/Cards_and_Offer/Redeeming_a_coupon_voucher_or_card.html#5"></a>
/// </summary>
/// <remarks>
/// 加密code解码接口支持两种场景：
/// <para>1.商家获取choos_card_info后，将card_id和encrypt_code字段通过解码接口，获取真实code。</para>
/// <para>2.卡券内跳转外链的签名中会对code进行加密处理，通过调用解码接口获取真实code。</para>
/// </remarks>
public class WeChatMpCardCodeDecryptRequest
    : WeChatHttpRequest<WeChatMpCardCodeDecryptResponse>
    , IHasAccessToken
{
    public static string Endpoint = "/card/code/decrypt?access_token={access_token}";

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpCardCodeDecryptRequest"/>
    /// </summary>
    public WeChatMpCardCodeDecryptRequest()
        : base(HttpMethod.Post)
    {

    }

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpCardCodeDecryptRequest"/>
    /// </summary>
    /// <param name="encryptCode">经过加密的Code码</param>
    public WeChatMpCardCodeDecryptRequest(
        string encryptCode)
        : base(HttpMethod.Post)
    {
        EncryptCode = encryptCode;
    }

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpCardCodeDecryptRequest"/>
    /// </summary>
    /// <param name="encryptCode">经过加密的Code码</param>
    /// <param name="accessToken"></param>
    public WeChatMpCardCodeDecryptRequest(
        string encryptCode,
        string accessToken)
        : base(HttpMethod.Post)
    {
        AccessToken = accessToken;
        EncryptCode = encryptCode;
    }

    [JsonIgnore]
    public string? AccessToken { get; set; }

    /// <summary>
    /// 经过加密的Code码
    /// </summary>
    [JsonPropertyName("encrypt_code")]
    public string EncryptCode { get; set; }

    protected override string GetRequestUri() => $"{WeChatProperties.Domain}{Endpoint}"
        .Replace("{access_token}", AccessToken);
}