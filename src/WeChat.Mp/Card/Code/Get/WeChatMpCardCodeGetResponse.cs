namespace WeChat.Mp.Card;

public class WeChatMpCardCodeGetResponse
    : WeChatHttpResponse
{
    /// <summary>
    /// 用户openid
    /// </summary>
    [JsonPropertyName("openid")]
    public string OpenId { get; set; }

    /// <summary>
    /// 是否可以核销，true为可以核销，false为不可核销
    /// </summary>
    [JsonPropertyName("can_consume")]
    public bool CanConsume { get; set; }

    /// <summary>
    /// 当前code对应卡券的状态（<see cref="CardCodeStatus"/>）。
    /// code未被添加或被转赠领取的情况则统一报错：invalid serial code
    /// </summary>
    /// <value>
    /// NORMAL：正常；
    /// CONSUMED：已核销；
    /// EXPIRE：已过期；
    /// GIFTING：转赠中；
    /// GIFT_TIMEOUT：转赠超时；
    /// DELETE：已删除；
    /// UNAVAILABLE：已失效
    /// </value>
    [JsonPropertyName("user_card_status")]
    public string UserCardStatus { get; set; }

    /// <summary>
    /// 卡券有效时间信息
    /// </summary>
    [JsonPropertyName("card")]
    public CardCodeGetModel Card { get; set; }
}
