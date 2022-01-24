namespace WeChat.Mp.Card;

/// <summary>
/// 封面摘要信息
/// </summary>
public class CardAbstract
{
    /// <summary>
    /// 实例化一个新的 <see cref="CardAbstract"/>
    /// </summary>
    public CardAbstract()
    {

    }

    /// <summary>
    /// 实例化一个新的 <see cref="CardAbstract"/>
    /// </summary>
    /// <param name="abstract">封面摘要简介</param>
    /// <param name="iconUrlList">
    /// 封面图片列表，仅支持填入一 个封面图片链接， 
    /// <see cref="Media.WeChatMpMediaUploadImgRequest"/> 上传获取图片获得链接，填写 非CDN链接会报错，并在此填入。 
    /// 建议图片尺寸像素850*350
    /// </param>
    public CardAbstract(
        string? @abstract = default,
        List<string>? iconUrlList = default)
    {
        Abstract = @abstract;
        IconUrlList = iconUrlList;
    }

    /// <summary>
    /// 封面摘要简介
    /// </summary>
    [JsonPropertyName("abstract")]
    public string? Abstract { get; set; }

    /// <summary>
    /// 封面图片列表，仅支持填入一 个封面图片链接， 
    /// <see cref="Media.WeChatMpMediaUploadImgRequest"/> 上传获取图片获得链接，填写 非CDN链接会报错，并在此填入。 
    /// 建议图片尺寸像素850*350
    /// </summary>
    [JsonPropertyName("icon_url_list")]
    public List<string>? IconUrlList { get; set; }

}
