namespace WeChat.Mp.Card;

/// <summary>
/// 主题
/// </summary>
public class CardGiftTheme
{
    /// <summary>
    /// 实例化一个新的 <see cref="CardGiftTheme"/>
    /// </summary>
    public CardGiftTheme()
    {
        Items = new();
        Pics = new();
    }

    /// <summary>
    /// 实例化一个新的 <see cref="CardGiftTheme"/>
    /// </summary>
    /// <param name="themePicUrl">主题的封面图片，须先将图片上传至CDN 大小控制在1000px*600px</param>
    /// <param name="title">主题名称，如“圣诞”“感恩家人”</param>
    /// <param name="titleColor">主题title的颜色，直接传入色值</param>
    /// <param name="items">礼品卡列表，标识该主题可选择的面额</param>
    /// <param name="pics">封面列表</param>
    /// <param name="categoryIndex">主题标号，对应category_list内的title字段， 若填写了category_list则每个主题必填该序号</param>
    /// <param name="showSkuTitleFirst">该主题购买页是否突出商品名显示</param>
    /// <param name="isBanner">是否将当前主题设置为banner主题（主推荐）</param>
    public CardGiftTheme(
        string themePicUrl,
        string title,
        string titleColor,
        List<CardGift> items,
        List<CardGiftPic> pics,
        int categoryIndex = 0,
        bool? showSkuTitleFirst = default,
        bool? isBanner = default)
    {
        ThemePicUrl = themePicUrl;
        Title = title;
        TitleColor = titleColor;
        Items = items;
        Pics = pics;
        CategoryIndex = categoryIndex;
        ShowSkuTitleFirst = showSkuTitleFirst;
        IsBanner = isBanner;
    }

    /// <summary>
    /// 主题的封面图片，须先将图片上传至CDN 大小控制在1000px*600px
    /// </summary>
    [JsonPropertyName("theme_pic_url")]
    public string ThemePicUrl { get; set; }

    /// <summary>
    ///主题名称，如“圣诞”“感恩家人”
    /// </summary>
    [JsonPropertyName("title")]
    public string Title { get; set; }

    /// <summary>
    /// 主题title的颜色，直接传入色值
    /// </summary>
    [JsonPropertyName("title_color")]
    public string TitleColor { get; set; }

    /// <summary>
    /// 礼品卡列表，标识该主题可选择的面额
    /// </summary>
    [JsonPropertyName("item_list")]
    public List<CardGift> Items { get; set; }

    /// <summary>
    /// 封面列表
    /// </summary>
    [JsonPropertyName("pic_item_list")]
    public List<CardGiftPic> Pics { get; set; }

    /// <summary>
    /// 主题标号，对应category_list内的title字段， 
    /// 若填写了category_list则每个主题必填该序号
    /// </summary>
    [JsonPropertyName("category_index")]
    public int CategoryIndex { get; set; }

    /// <summary>
    /// 该主题购买页是否突出商品名显示
    /// </summary>
    [JsonPropertyName("show_sku_title_first")]
    public bool? ShowSkuTitleFirst { get; set; }

    /// <summary>
    /// 是否将当前主题设置为banner主题（主推荐）
    /// </summary>
    [JsonPropertyName("is_banner")]
    public bool? IsBanner { get; set; }
}
