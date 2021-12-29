using System.Text.Json.Serialization;

namespace WeChat.Mp.Card;

/// <summary>
/// 卡券高级信息
/// </summary>
public class WeChatMpCardCreateAdvancedInfo
{
    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpCardCreateAdvancedInfo"/>
    /// </summary>
    public WeChatMpCardCreateAdvancedInfo()
    {

    }

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpCardCreateAdvancedInfo"/>
    /// </summary>
    /// <param name="useCondition">
    /// 使用门槛（条件）字段，
    /// 若不填写使用条件则在券面拼写：无最低消费限制，全场通用，不限品类；
    /// 并在使用说明显示： 可与其他优惠共享
    /// </param>
    /// <param name="abstract">封面摘要</param>
    /// <param name="textImageList">图文列表，显示在详情内页，优惠券券开发者须至少传入一组图文列表</param>
    /// <param name="businessService">商家服务类型（<see cref="BusinessServiceTypes"/>），可多选</param>
    /// <param name="timeLimit">使用时段限制</param>
    public WeChatMpCardCreateAdvancedInfo(
        WeChatMpCardCreateUseCondition? useCondition = default,
        WeChatMpCardCreateAbstract? @abstract = default,
        List<WeChatMpCardCreateAbstractTextImage>? textImageList = default,
        List<string>? businessService = default,
        List<WeChatMpCardCreateAbstracTimeLimit>? timeLimit = default)
    {
        UseCondition = useCondition;
        Abstract = @abstract;
        TextImageList = textImageList;
        BusinessService = businessService;
        TimeLimit = timeLimit;
    }

    /// <summary>
    /// 使用门槛（条件）字段，
    /// 若不填写使用条件则在券面拼写：无最低消费限制，全场通用，不限品类；
    /// 并在使用说明显示： 可与其他优惠共享
    /// </summary>
    [JsonPropertyName("use_condition")]
    public WeChatMpCardCreateUseCondition? UseCondition { get; set; }

    /// <summary>
    /// 封面摘要
    /// </summary>
    [JsonPropertyName("abstract")]
    public WeChatMpCardCreateAbstract? Abstract { get; set; }

    /// <summary>
    /// 图文列表，显示在详情内页，优惠券券开发者须至少传入一组图文列表
    /// </summary>
    [JsonPropertyName("text_image_list")]
    public List<WeChatMpCardCreateAbstractTextImage>? TextImageList { get; set; }

    /// <summary>
    /// 商家服务类型（<see cref="BusinessServiceTypes"/>），可多选
    /// </summary>
    /// <value>
    /// BIZ_SERVICE_DELIVER：外卖服务；
    /// BIZ_SERVICE_FREE_PARK：停车位；
    /// BIZ_SERVICE_WITH_PET：可带宠物；
    /// BIZ_SERVICE_FREE_WIFI：免费wifi
    /// </value>
    [JsonPropertyName("business_service")]
    public List<string>? BusinessService { get; set; }

    /// <summary>
    /// 使用时段限制
    /// </summary>
    [JsonPropertyName("time_limit")]
    public List<WeChatMpCardCreateAbstracTimeLimit>? TimeLimit { get; set; }
}
