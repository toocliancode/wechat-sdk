using System.Text.Json.Serialization;

namespace WeChat.Mp.Card;

/// <summary>
/// 使用时段限制
/// </summary>
public class WeChatMpCardCreateAbstracTimeLimit
{
    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpCardCreateAbstracTimeLimit"/>
    /// </summary>
    public WeChatMpCardCreateAbstracTimeLimit()
    {

    }

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpCardCreateAbstracTimeLimit"/>
    /// </summary>
    /// <param name="type">限制类型枚举值（<see cref="DayOfWeek"/> 转字符串大写）, 此处只控制显示，不控制实际使用逻辑，不填默认不显示</param>
    /// <param name="beginHour">当前type类型下的起始时间（小时），如当前结构体内填写了MONDAY，此处填写了10，则此处表示周一10:00可用</param>
    /// <param name="beginMinute">当前type类型下的起始时间（分钟），如当前结构体内填写了MONDAY，begin_hour填写10，此处填写了59，则此处表示周一10:59可用</param>
    /// <param name="endHour">当前type类型下的结束时间（小时） ，如当前结构体内填写了MONDAY，此处填写了20，则此处表示周一10:00-20:00可用</param>
    /// <param name="endMinute">当前type类型下的结束时间（分钟） ，如当前结构体内填写了MONDAY，begin_hour填写10，此处填写了59，则此处表示周一10:59-00:59可用</param>
    public WeChatMpCardCreateAbstracTimeLimit(
        DayOfWeek? type = default,
        ushort? beginHour = default,
        ushort? beginMinute = default,
        ushort? endHour = default,
        ushort? endMinute = default)
    {
        Type = type?.ToString()?.ToUpperInvariant();
        BeginHour = beginHour;
        BeginMinute = beginMinute;
        EndHour = endHour;
        EndMinute = endMinute;
    }

    /// <summary>
    /// 限制类型枚举值（<see cref="DayOfWeek"/> 转字符串大写）, 此处只控制显示，不控制实际使用逻辑，不填默认不显示
    /// </summary>
    /// <value>
    /// MONDAY：周一；
    /// TUESDAY：周二；
    /// WEDNESDAY：周三；
    /// THURSDAY：周四；
    /// FRIDAY：周五；
    /// SATURDAY：周六；
    /// SUNDAY：周日
    /// </value>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>
    /// 当前type类型下的起始时间（小时），如当前结构体内填写了MONDAY，此处填写了10，则此处表示周一10:00可用
    /// </summary>
    [JsonPropertyName("begin_hour")]
    public ushort? BeginHour { get; set; }

    /// <summary>
    /// 当前type类型下的起始时间（分钟），如当前结构体内填写了MONDAY，begin_hour填写10，此处填写了59，则此处表示周一10:59可用
    /// </summary>
    [JsonPropertyName("begin_minute")]
    public ushort? BeginMinute { get; set; }

    /// <summary>
    /// 当前type类型下的结束时间（小时） ，如当前结构体内填写了MONDAY，此处填写了20，则此处表示周一10:00-20:00可用
    /// </summary>
    [JsonPropertyName("end_hour")]
    public ushort? EndHour { get; set; }

    /// <summary>
    /// 当前type类型下的结束时间（分钟） ，如当前结构体内填写了MONDAY，begin_hour填写10，此处填写了59，则此处表示周一10:59-00:59可用
    /// </summary>
    [JsonPropertyName("end_minute")]
    public ushort? EndMinute { get; set; }
}