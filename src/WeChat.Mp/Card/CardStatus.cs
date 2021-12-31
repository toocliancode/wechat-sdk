namespace WeChat.Mp.Card;

/// <summary>
/// 卡券存在的状态
/// </summary>
public static class CardStatus
{
    /// <summary>
    /// 待审核
    /// </summary>
    public const string CARD_STATUS_NOT_VERIFY = "CARD_STATUS_NOT_VERIFY";

    /// <summary>
    /// 审核失败
    /// </summary>
    public const string CARD_STATUS_VERIFY_FAIL = "CARD_STATUS_VERIFY_FAIL";

    /// <summary>
    /// 通过审核
    /// </summary>
    public const string CARD_STATUS_VERIFY_OK = "CARD_STATUS_VERIFY_OK";

    /// <summary>
    /// 卡券被商户删除
    /// </summary>
    public const string CARD_STATUS_DELETE = "CARD_STATUS_DELETE";

    /// <summary>
    /// 在公众平台投放过的卡券
    /// </summary>
    public const string CARD_STATUS_DISPATCH = "CARD_STATUS_DISPATCH";
}