namespace WeChat.Pay;

/// <summary>
/// 订单金额信息
/// </summary>    
[Serializable]
public class Amount
{
    /// <summary>
    /// 实例化一个订单金额信息
    /// </summary>
    public Amount()
    {
    }

    /// <summary>
    /// 实例化一个订单金额信息
    /// </summary>
    /// <param name="total">订单金额，单位为分。</param>
    /// <param name="currency">货币类型，CNY：人民币，境内商户号仅支持人民币。</param>
    public Amount(int total, string currency = "CNY")
    {
        Total = total;
        Currency = currency;
    }

    /// <summary>
    /// 订单总金额，单位为分。
    /// 示例值：100
    /// </summary>
    [JsonPropertyName("total")]
    public int Total { get; set; }

    /// <summary>
    /// 货币类型	
    /// CNY：人民币，境内商户号仅支持人民币。
    /// 示例值：CNY
    /// </summary>
    [JsonPropertyName("currency")]
    public string? Currency { get; set; }
}
