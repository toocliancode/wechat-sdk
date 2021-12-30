namespace WeChat.Mp.Card;

public class WeChatMpCardQrcodeCreateModel
{
    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpCardQrcodeCreateModel"/>
    /// </summary>
    public WeChatMpCardQrcodeCreateModel()
    {

    }

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatMpCardQrcodeCreateModel"/>
    /// </summary>
    /// <param name="code">卡券Code码,use_custom_code字段为true的卡券必须填写，非自定义code和导入code模式的卡券不必填写。</param>
    /// <param name="cardId">卡券Id</param>
    /// <param name="openId">
    /// （此处无需指定，指定 <see cref="WeChatMpCardQrcodeCreateRequest.OpenId"/> 即可）指定领取者的openid，只有该用户能领取。
    /// bind_openid字段为true的卡券必须填写，非指定openid不必填写
    /// </param>
    /// <param name="isUniqueCode">
    /// 指定下发二维码，生成的二维码随机分配一个code，领取后不可再次扫描。
    /// 填写true或false。
    /// 默认false，注意填写该字段时，卡券须通过审核且库存不为0。
    /// </param>
    /// <param name="outerId">
    /// 领取场景值，用于领取渠道的数据统计，默认值为0，字段类型为整型，长度限制为60位数字。
    /// 用户领取卡券后触发的[事件推送]中会带上此自定义场景值。
    /// </param>
    /// <param name="outerStr">
    /// outer_id字段升级版本，字符串类型，用户首次领卡时，会通过[领取事件推送]给商户；
    /// 对于会员卡的二维码，用户每次扫码打开会员卡后点击任何url，会将该值拼入url中，方便开发者定位扫码来源
    /// </param>
    public WeChatMpCardQrcodeCreateModel(
        string? code = default,
        string? cardId = default,
        bool? isUniqueCode = default,
        int? outerId = default,
        string? outerStr = default,
        string? openId = default)
    {
        Code = code;
        CardId = cardId;
        OpenId = openId;
        IsUniqueCode = isUniqueCode;
        OuterId = outerId;
        OuterStr = outerStr;
    }



    /// <summary>
    /// 卡券Code码,use_custom_code字段为true的卡券必须填写，非自定义code和导入code模式的卡券不必填写。
    /// </summary>
    /// <value>
    /// 示例值："110201201245"
    /// </value>
    [JsonPropertyName("code")]
    public string? Code { get; set; }

    /// <summary>
    /// 卡券Id
    /// </summary>
    /// <value>
    /// 示例值："pFS7Fjg8kV1IdDz01r4SQwMkuCKc"
    /// </value>
    [JsonPropertyName("card_id")]
    public string? CardId { get; set; }

    /// <summary>
    /// （此处无需指定，指定 <see cref="WeChatMpCardQrcodeCreateRequest.OpenId"/> 即可）指定领取者的openid，只有该用户能领取。
    /// bind_openid字段为true的卡券必须填写，非指定openid不必填写
    /// </summary>
    /// <value>
    /// 示例值："oXch-jkrxp42VQu8ldweCwDt97qo"
    /// </value>
    [JsonPropertyName("openid")]
    public string? OpenId { get; set; }

    /// <summary>
    /// 指定下发二维码，生成的二维码随机分配一个code，领取后不可再次扫描。
    /// 填写true或false。
    /// 默认false，注意填写该字段时，卡券须通过审核且库存不为0。
    /// </summary>
    [JsonPropertyName("is_unique_code")]
    public bool? IsUniqueCode { get; set; }

    /// <summary>
    /// 领取场景值，用于领取渠道的数据统计，默认值为0，字段类型为整型，长度限制为60位数字。
    /// 用户领取卡券后触发的[事件推送]中会带上此自定义场景值。
    /// </summary>
    [JsonPropertyName("outer_id")]
    public int? OuterId { get; set; }

    /// <summary>
    /// outer_id字段升级版本，字符串类型，用户首次领卡时，会通过[领取事件推送]给商户；
    /// 对于会员卡的二维码，用户每次扫码打开会员卡后点击任何url，会将该值拼入url中，方便开发者定位扫码来源
    /// </summary>
    [JsonPropertyName("")]
    public string? OuterStr { get; set; }
}
