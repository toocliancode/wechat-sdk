namespace WeChat.Mp.Card;

public class CardLandingPageModel
{
    /// <summary>
    /// 实例化一个新的 <see cref="CardLandingPageModel"/>
    /// </summary>
    public CardLandingPageModel()
    {
    }

    /// <summary>
    /// 实例化一个新的 <see cref="CardLandingPageModel"/>
    /// </summary>
    /// <param name="cardId">所要在页面投放的card_id</param>
    /// <param name="thumbUrl">缩略图url</param>
    public CardLandingPageModel(string cardId, string thumbUrl)
    {
        CardId = cardId;
        ThumbUrl = thumbUrl;
    }

    /// <summary>
    /// 所要在页面投放的card_id
    /// </summary>
    [JsonPropertyName("card_id")]
    public string CardId { get; set; }

    /// <summary>
    /// 缩略图url
    /// </summary>
    [JsonPropertyName("thumb_url")]
    public string ThumbUrl { get; set; }
}
