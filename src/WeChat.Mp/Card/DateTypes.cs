namespace WeChat.Mp.Card;

/// <summary>
/// 卡券使用时间的类型
/// </summary>
public static class DateTypes
{
    /// <summary>
    /// 固定日期区间
    /// </summary>
    public const string DATE_TYPE_FIX_TIME_RANGE = "DATE_TYPE_FIX_TIME_RANGE";

    /// <summary>
    /// 固定时长（自领取后按天算）
    /// </summary>
    public const string DATE_TYPE_FIX_TERM = "DATE_TYPE_FIX_TERM";

    /// <summary>
    /// 永久有效
    /// </summary>
    public const string DATE_TYPE_PERMANENT = "DATE_TYPE_PERMANENT";
}
