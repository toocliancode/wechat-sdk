namespace WeChat.Mp.Card;

/// <summary>
/// 礼品卡列表，标识该主题可选择的面额
/// </summary>
public class CardGift
{
    /// <summary>
    /// 实例化一个新的 <see cref="CardGift"/>
    /// </summary>
    public CardGift()
    {
    }

    /// <summary>
    /// 实例化一个新的 <see cref="CardGift"/>
    /// </summary>
    /// <param name="cardId">待上架的card_id</param>
    /// <param name="title">商品名，不填写默认为卡名称</param>
    /// <param name="picUrl">商品缩略图，1000像素*600像素以下</param>
    /// <param name="desc">商品简介</param>
    public CardGift(
        string cardId,
        string title,
        string picUrl,
        string desc)
    {
        CardId = cardId;
        Title = title;
        PicUrl = picUrl;
        Desc = desc;
    }

    /// <summary>
    /// 待上架的card_id
    /// </summary>
    [JsonPropertyName("card_id")]
    public string CardId { get; set; }

    /// <summary>
    /// 商品名，不填写默认为卡名称
    /// </summary>
    [JsonPropertyName("title")]
    public string Title { get; set; }

    /// <summary>
    /// 商品缩略图，1000像素*600像素以下
    /// </summary>
    [JsonPropertyName("pic_url")]
    public string PicUrl { get; set; }

    /// <summary>
    /// 商品简介
    /// </summary>
    [JsonPropertyName("商品简介")]
    public string Desc { get; set; }
}
