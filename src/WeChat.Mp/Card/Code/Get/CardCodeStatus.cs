namespace WeChat.Mp.Card;

/// <summary>
/// 当前code对应卡券的状态
/// </summary>
public static class CardCodeStatus
{
    /// <summary>
    /// 正常
    /// </summary>
    public const string NORMAL = "NORMAL";

    /// <summary>
    /// 已核销
    /// </summary>
    public const string CONSUMED = "CONSUMED";

    /// <summary>
    /// 已过期
    /// </summary>
    public const string EXPIRE = "EXPIRE";

    /// <summary>
    /// 转赠中
    /// </summary>
    public const string GIFTING = "GIFTING";

    /// <summary>
    /// 转赠超时
    /// </summary>
    public const string GIFT_TIMEOUT = "GIFT_TIMEOUT";

    /// <summary>
    /// 已删除
    /// </summary>
    public const string DELETE = "DELETE";

    /// <summary>
    /// 已失效
    /// </summary>
    public const string UNAVAILABLE = "UNAVAILABLE";
}
