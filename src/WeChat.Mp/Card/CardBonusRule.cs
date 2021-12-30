namespace WeChat.Mp.Card;

/// <summary>
/// 积分规则
/// </summary>
public class CardBonusRule
{
    /// <summary>
    /// 实例化一个新的 <see cref="CardBonusRule"/>
    /// </summary>
    public CardBonusRule()
    {
    }

    /// <summary>
    /// 实例化一个新的 <see cref="CardBonusRule"/>
    /// </summary>
    /// <param name="costMoneyUnit">消费金额。以分为单位</param>
    /// <param name="increaseBonus">对应增加的积分</param>
    /// <param name="maxIncreaseBonus">用户单次可获取的积分上限</param>
    /// <param name="initIncreaseBonus">初始设置积分</param>
    /// <param name="costBonusUnit">每使用 <see cref="CostBonusUnit"/> 积分</param>
    /// <param name="reduceMoney">抵扣 <see cref="ReduceMoney"/>/100 元，（这里以分为单位）</param>
    /// <param name="leastMoneyToUseBonus">抵扣条件，满 <see cref="LeastMoneyToUseBonus"/>/100 元（这里以分为单位）可用</param>
    /// <param name="maxReduceBonus">抵扣条件，单笔最多使用 <see cref="MaxReduceBonus"/> 积分</param>
    public CardBonusRule(
        int? costMoneyUnit = default,
        int? increaseBonus = default,
        int? maxIncreaseBonus = default,
        int? initIncreaseBonus = default,
        int? costBonusUnit = default,
        int? reduceMoney = default,
        int? leastMoneyToUseBonus = default,
        int? maxReduceBonus = default)
    {
        CostMoneyUnit = costMoneyUnit;
        IncreaseBonus = increaseBonus;
        MaxIncreaseBonus = maxIncreaseBonus;
        InitIncreaseBonus = initIncreaseBonus;
        CostBonusUnit = costBonusUnit;
        ReduceMoney = reduceMoney;
        LeastMoneyToUseBonus = leastMoneyToUseBonus;
        MaxReduceBonus = maxReduceBonus;
    }

    /// <summary>
    /// 消费金额。以分为单位
    /// </summary>
    [JsonPropertyName("cost_money_unit")]
    public int? CostMoneyUnit { get; set; }

    /// <summary>
    /// 对应增加的积分
    /// </summary>
    [JsonPropertyName("increase_bonus")]
    public int? IncreaseBonus { get; set; }

    /// <summary>
    /// 用户单次可获取的积分上限
    /// </summary>
    [JsonPropertyName("max_increase_bonus")]
    public int? MaxIncreaseBonus { get; set; }

    /// <summary>
    /// 初始设置积分
    /// </summary>
    [JsonPropertyName("init_increase_bonus")]
    public int? InitIncreaseBonus { get; set; }

    /// <summary>
    /// 每使用 <see cref="CostBonusUnit"/> 积分
    /// </summary>
    [JsonPropertyName("cost_bonus_unit")]
    public int? CostBonusUnit { get; set; }

    /// <summary>
    /// 抵扣 <see cref="ReduceMoney"/>/100 元，（这里以分为单位）
    /// </summary>
    [JsonPropertyName("reduce_money")]
    public int? ReduceMoney { get; set; }

    /// <summary>
    /// 抵扣条件，满 <see cref="LeastMoneyToUseBonus"/>/100 元（这里以分为单位）可用
    /// </summary>
    [JsonPropertyName("least_money_to_use_bonus")]
    public int? LeastMoneyToUseBonus { get; set; }

    /// <summary>
    /// 抵扣条件，单笔最多使用 <see cref="MaxReduceBonus"/> 积分
    /// </summary>
    [JsonPropertyName("max_reduce_bonus")]
    public int? MaxReduceBonus { get; set; }
}