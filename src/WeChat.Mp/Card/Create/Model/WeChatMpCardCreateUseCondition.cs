using System.Text.Json.Serialization;

namespace WeChat.Mp.Card;

/// <summary>
/// 使用门槛（条件）字段，
/// 若不填写使用条件则在券面拼写：无最低消费限制，全场通用，不限品类；
/// 并在使用说明显示： 可与其他优惠共享
/// </summary>
public class WeChatMpCardCreateUseCondition
{
    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpCardCreateUseCondition"/>
    /// </summary>
    public WeChatMpCardCreateUseCondition()
    {

    }

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpCardCreateUseCondition"/>
    /// </summary>
    /// <param name="acceptCategory">指定可用的商品类目，仅用于代金券类型 ，填入后将在券面拼写适用于 <see cref="AcceptCategory"/></param>
    /// <param name="rejectCategory">指定不可用的商品类目，仅用于代金券类型 ，填入后将在券面拼写不适用于 <see cref="RejectCategory"/></param>
    /// <param name="leastCost">满减门槛字段，可用于兑换券和代金券 ，填入后将在全面拼写消费满 <see cref="LeastCost"/> 元可用</param>
    /// <param name="objectUseFor">购买 <see cref="ObjectUseFor"/> 可用类型门槛，仅用于兑换 ，填入后自动拼写购买 <see cref="ObjectUseFor"/> 可用</param>
    /// <param name="canUseWithOtherDiscount">
    /// 不可以与其他类型共享门槛 ，填写false时系统将在使用须知里 拼写“不可与其他优惠共享”， 
    /// 填写true时系统将在使用须知里 拼写“可与其他优惠共享”， 默认为true
    /// </param>
    public WeChatMpCardCreateUseCondition(
        string? acceptCategory = default,
        string? rejectCategory = default,
        int? leastCost = default,
        string? objectUseFor = default,
        bool? canUseWithOtherDiscount = default)
    {
        AcceptCategory = acceptCategory;
        RejectCategory = rejectCategory;
        LeastCost = leastCost;
        ObjectUseFor = objectUseFor;
        CanUseWithOtherDiscount = canUseWithOtherDiscount;
    }



    /// <summary>
    /// 指定可用的商品类目，仅用于代金券类型 ，填入后将在券面拼写适用于 <see cref="AcceptCategory"/>
    /// </summary>
    [JsonPropertyName("accept_category")]
    public string? AcceptCategory { get; set; }

    /// <summary>
    /// 指定不可用的商品类目，仅用于代金券类型 ，填入后将在券面拼写不适用于 <see cref="RejectCategory"/>
    /// </summary>
    [JsonPropertyName("reject_category")]
    public string? RejectCategory { get; set; }

    /// <summary>
    /// 满减门槛字段，可用于兑换券和代金券 ，填入后将在全面拼写消费满 <see cref="LeastCost"/> 元可用
    /// </summary>
    [JsonPropertyName("least_cost")]
    public int? LeastCost { get; set; }

    /// <summary>
    /// 购买 <see cref="ObjectUseFor"/> 可用类型门槛，仅用于兑换 ，填入后自动拼写购买 <see cref="ObjectUseFor"/> 可用
    /// </summary>
    [JsonPropertyName("object_use_for")]
    public string? ObjectUseFor { get; set; }

    /// <summary>
    /// 不可以与其他类型共享门槛 ，填写false时系统将在使用须知里 拼写“不可与其他优惠共享”， 
    /// 填写true时系统将在使用须知里 拼写“可与其他优惠共享”， 默认为true
    /// </summary>
    [JsonPropertyName("can_use_with_other_discount")]
    public bool? CanUseWithOtherDiscount { get; set; }
}
