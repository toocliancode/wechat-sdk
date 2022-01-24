namespace WeChat.Mp.Card;

/// <summary>
/// 自定义会员信息类目，会员卡激活后显示,包含name_type (name) 和url字段
/// </summary>
public class CardCustomField
{
    /// <summary>
    /// 实例化一个新的 <see cref="CardCustomField"/>
    /// </summary>
    public CardCustomField()
    {

    }

    /// <summary>
    /// 实例化一个新的 <see cref="CardCustomField"/>
    /// </summary>
    /// <param name="nameType">会员信息类目半自定义名称类型（<see cref="CardFieldNameTypes"/>）</param>
    /// <param name="name">会员信息类目自定义名称，当开发者变更这类类目信息的value值时,不会触发系统模板消息通知用户</param>
    /// <param name="url">点击类目跳转外链url</param>
    public CardCustomField(string nameType, string name, string url)
    {
        NameType = nameType;
        Name = name;
        Url = url;
    }

    /// <summary>
    /// 会员信息类目半自定义名称类型（<see cref="CardFieldNameTypes"/>）
    /// </summary>
    [JsonPropertyName("name_type")]
    public string NameType { get; set; }

    /// <summary>
    /// 会员信息类目自定义名称，当开发者变更这类类目信息的value值时,不会触发系统模板消息通知用户
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// 点击类目跳转外链url
    /// </summary>
    [JsonPropertyName("点击类目跳转外链url")]
    public string Url { get; set; }
}
