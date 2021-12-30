namespace WeChat.Mp.Card;

/// <summary>
/// 卡券使用日期，有效期的信息。
/// </summary>
public class CardDateInfo
{
    /// <summary>
    /// 实例化一个新的 <see cref="CardDateInfo"/>。
    /// 使用类型 <see cref="DateTypes.DATE_TYPE_FIX_TIME_RANGE"/>
    /// </summary>
    /// <param name="beginTime">
    /// <see cref="Type"/> = <see cref="DateTypes.DATE_TYPE_FIX_TIME_RANGE"/> 时专用，表示起用时间。
    /// 从1970年1月1日00:00:00至起用时间的秒数，最终需转换为字符串形态传入。（东八区时间,UTC+8，单位为秒
    /// </param>
    /// <param name="endTime">
    /// <see cref="Type"/> = <see cref="DateTypes.DATE_TYPE_FIX_TIME_RANGE"/> 或 <see cref="DateTypes.DATE_TYPE_FIX_TERM"/> 时专用，表示结束时间。
    /// 建议设置为截止日期的23:59:59过期。（ 东八区时间,UTC+8，单位为秒 ）
    /// </param>
    public CardDateInfo(
        DateTime beginTime,
        DateTime endTime)
    {
        Type = DateTypes.DATE_TYPE_FIX_TIME_RANGE;
        // 转为 东八区时间,UTC+8
        BeginTimeStamp = (ulong)(new DateTimeOffset(beginTime).ToUnixTimeSeconds() + 28800);
        EndTimeStamp = (ulong)(new DateTimeOffset(endTime).ToUnixTimeSeconds() + 28800);
    }

    /// <summary>
    /// 实例化一个新的 <see cref="CardDateInfo"/>。
    /// 使用类型 <see cref="DateTypes.DATE_TYPE_FIX_TERM"/>
    /// </summary>
    /// <param name="fixedTime">
    /// <see cref="Type"/> = <see cref="DateTypes.DATE_TYPE_FIX_TERM"/> 时专用，表示自领取后多少天内有效，不支持填写0。（单位为天）
    /// </param>
    /// <param name="fixedBeginTerm">
    /// <see cref="Type"/> = <see cref="DateTypes.DATE_TYPE_FIX_TERM"/> 时专用，表示自领取后多少天开始生效，领取后当天生效填写0。（单位为天）
    /// </param>
    /// <param name="endTime">
    /// 表示卡券统一过期时间 ， 建议设置为截止日期的23:59:59过期。（ 东八区时间,UTC+8，单位为秒 ）。
    /// 设置了 <see cref="FixedTerm"/> 卡券，当时间达到 <see cref="EndTimeStamp"/> 时卡券统一过期
    /// </param>
    public CardDateInfo(
        uint fixedTime,
        uint fixedBeginTerm,
        DateTime? endTime)
    {
        FixedTime = fixedTime;
        FixedBeginTerm = fixedBeginTerm;
        if (endTime.HasValue)
        {
            // 转为 东八区时间,UTC+8
            EndTimeStamp = (ulong)(new DateTimeOffset(endTime.Value).ToUnixTimeSeconds() + 28800);
        }
    }

    /// <summary>
    /// 使用时间的类型，旧文档采用的1和2依然生效。
    /// 
    /// </summary>
    /// <remarks>
    /// 示例值："DATE_TYPE_FIX_TIME_RANGE"。
    /// </remarks>
    /// <value>
    /// DATE_TYPE_FIX_TIME_RANGE：固定日期区间；
    /// DATE_TYPE_FIX_TERM：固定时长（自领取后按天算）；
    /// DATE_TYPE_PERMANENT：永久有效
    /// </value>
    [JsonPropertyName("type")]
    public string Type { get; set; }

    /// <summary>
    /// <see cref="Type"/> = <see cref="DateTypes.DATE_TYPE_FIX_TIME_RANGE"/> 时专用，表示起用时间。
    /// 从1970年1月1日00:00:00至起用时间的秒数，最终需转换为字符串形态传入。（东八区时间,UTC+8，单位为秒）
    /// </summary>
    /// <value>
    /// 示例值：14300000
    /// </value>
    [JsonPropertyName("begin_timestamp")]
    public ulong? BeginTimeStamp { get; set; }

    /// <summary>
    /// <see cref="Type"/> = <see cref="DateTypes.DATE_TYPE_FIX_TIME_RANGE"/> 或 <see cref="DateTypes.DATE_TYPE_FIX_TERM"/> 时专用，表示结束时间。
    /// 建议设置为截止日期的23:59:59过期。（ 东八区时间,UTC+8，单位为秒 ）
    /// </summary>
    /// <remarks>
    /// 当 <see cref="Type"/> = <see cref="DateTypes.DATE_TYPE_FIX_TERM"/> 时值为可选。
    /// 设置了 <see cref="FixedTerm"/> 卡券，当时间达到 <see cref="EndTimeStamp"/> 时卡券统一过期
    /// </remarks>
    /// /// <value>
    /// 示例值：15300000
    /// </value>
    [JsonPropertyName("end_timestamp")]
    public ulong? EndTimeStamp { get; set; }

    /// <summary>
    /// <see cref="Type"/> = <see cref="DateTypes.DATE_TYPE_FIX_TERM"/> 时专用，表示自领取后多少天内有效，不支持填写0。（单位为天）
    /// </summary>
    [JsonPropertyName("fixed_time")]
    public uint? FixedTerm { get; set; }

    /// <summary>
    /// <see cref="Type"/> = <see cref="DateTypes.DATE_TYPE_FIX_TERM"/> 时专用，表示自领取后多少天开始生效，领取后当天生效填写0。（单位为天）
    /// </summary>
    [JsonPropertyName("fixed_begin_term")]
    public uint? FixedBeginTerm { get; set; }
    public uint FixedTime { get; }
}
