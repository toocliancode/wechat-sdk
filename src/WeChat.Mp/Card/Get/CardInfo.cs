namespace WeChat.Mp.Card;

/// <summary>
/// 卡券信息
/// </summary>
public class CardInfo
{
    /// <summary>
    /// 卡券类型（<see cref="CardTypes"/>）
    /// </summary>
    [JsonPropertyName("card_type")]
    public string CardType { get; set; }

    /// <summary>
    /// 团购券（GROUPON）
    /// </summary>
    [JsonPropertyName("groupon")]
    public CardGeneralInfo Groupon { get; set; }

    /// <summary>
    /// 代金券（CASH）
    /// </summary>
    [JsonPropertyName("cash")]
    public CardGeneralInfo Cash { get; set; }

    /// <summary>
    /// 折扣券（DISCOUNT）
    /// </summary>
    [JsonPropertyName("discount")]
    public CardGeneralInfo Discount { get; set; }

    /// <summary>
    /// 兑换券（GIFT）
    /// </summary>
    [JsonPropertyName("gift")]
    public CardGeneralInfo Gift { get; set; }

    /// <summary>
    /// 会员卡(MEMBER_CARD)
    /// </summary>
    [JsonPropertyName("member_card")]
    public CardGeneralInfo MemberCard { get; set; }

    /// <summary>
    /// 礼品卡(GENERAL_CARD)
    /// </summary>
    [JsonPropertyName("general_card")]
    public CardGeneralInfo GeneralCard { get; set; }

    /// <summary>
    /// 会议门票（MEETING_TICKET）
    /// </summary>
    [JsonPropertyName("meeting_ticket")]
    public CardGeneralInfo MeetingTicket { get; set; }

    /// <summary>
    /// 景区门票（SCENIC_TICKET）
    /// </summary>
    [JsonPropertyName("movie_ticket")]
    public CardGeneralInfo ScenicTicket { get; set; }

    /// <summary>
    /// 电影票（MOVIE_TICKET）
    /// </summary>
    [JsonPropertyName("scenic_ticket")]
    public CardGeneralInfo MovieTicket { get; set; }

    /// <summary>
    /// 飞机票（BOARDING_PASS）
    /// </summary>
    [JsonPropertyName("boarding_ticket")]
    public CardGeneralInfo BoardingTicket { get; set; }
}
