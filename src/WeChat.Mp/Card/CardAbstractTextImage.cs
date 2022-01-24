namespace WeChat.Mp.Card;

/// <summary>
/// 图文列表，显示在详情内页，优惠券券开发者须至少传入一组图文列表
/// </summary>
public class CardAbstractTextImage
{
    /// <summary>
    /// 图片链接，必须调用 <see cref="Media.WeChatMpMediaUploadImgRequest"/> 上传图片获得链接，并在此填入，否则报错
    /// </summary>
    [JsonPropertyName("image_url")]
    public string? ImageUrl { get; set; }

    /// <summary>
    /// 图文描述
    /// </summary>
    [JsonPropertyName("text")]
    public string? Text { get; set; }
}
