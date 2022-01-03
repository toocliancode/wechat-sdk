namespace WeChat.Mp.Card;

/// <summary>
/// 主题分类
/// </summary>
public class CardGiftThemeCategory
{

    /// <summary>
    /// 实例化一个新的 <see cref="CardGiftThemeCategory"/>
    /// </summary>
    public CardGiftThemeCategory()
    {
    }

    /// <summary>
    /// 实例化一个新的 <see cref="CardGiftThemeCategory"/>
    /// </summary>
    /// <param name="title">主题分类的名称</param>
    public CardGiftThemeCategory(string title)
    {
        Title = title;
    }

    /// <summary>
    /// 主题分类的名称
    /// </summary>
    [JsonPropertyName("title")]
    public string Title { get; set; }
}