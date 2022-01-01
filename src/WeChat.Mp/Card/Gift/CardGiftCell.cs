namespace WeChat.Mp.Card;

/// <summary>
/// 商户自定义服务入口
/// </summary>
public class CardGiftCell
{
    /// <summary>
    /// 实例化一个新的 <see cref="CardGiftCell"/>
    /// </summary>
    public CardGiftCell()
    {
    }

    /// <summary>
    /// 实例化一个新的 <see cref="CardGiftCell"/>
    /// </summary>
    /// <param name="title">自定义入口名称</param>
    /// <param name="url">自定义入口链接</param>
    public CardGiftCell(string title, string url)
    {
        Title = title;
        Url = url;
    }

    /// <summary>
    /// 自定义入口名称
    /// </summary>
    [JsonPropertyName("title")]
    public string Title { get; set; }

    /// <summary>
    /// 自定义入口链接
    /// </summary>
    [JsonPropertyName("url")]
    public string Url { get; set; }
}
