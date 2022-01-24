namespace WeChat.Mp.Card;

/// <summary>
/// 自定义会员信息类目，会员卡激活后显示
/// </summary>
public class CardCustomCell
{
    /// <summary>
    /// 实例化一个新的 <see cref="CardCustomCell"/>
    /// </summary>
    public CardCustomCell()
    {

    }

    /// <summary>
    /// 实例化一个新的 <see cref="CardCustomCell"/>
    /// </summary>
    /// <param name="name">入口名称</param>
    /// <param name="tips">入口右侧提示语，6个汉字内</param>
    /// <param name="url">入口跳转链接</param>
    public CardCustomCell(string name, string tips, string url)
    {
        Name = name;
        Tips = tips;
        Url = url;
    }

    /// <summary>
    /// 入口名称
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// 入口右侧提示语，6个汉字内
    /// </summary>
    [JsonPropertyName("tips")]
    public string Tips { get; set; }

    /// <summary>
    /// 入口跳转链接
    /// </summary>
    [JsonPropertyName("url")]
    public string Url { get; set; }
}