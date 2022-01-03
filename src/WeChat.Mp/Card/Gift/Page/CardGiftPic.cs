namespace WeChat.Mp.Card;

/// <summary>
/// 封面
/// </summary>
public class CardGiftPic
{
    /// <summary>
    /// 实例化一个新的 <see cref="CardGiftPic"/>
    /// </summary>
    public CardGiftPic()
    {
    }

    /// <summary>
    /// 实例化一个新的 <see cref="CardGiftPic"/>
    /// </summary>
    /// <param name="backgroundPicUrl">卡面图片，须先将图片上传至CDN，大小控制在1000像素*600像素以下</param>
    /// <param name="defaultGiftingMsg">该卡面对应的默认祝福语，当用户没有编辑内容时会随卡默认填写为用户祝福内容</param>
    /// <param name="outerImgId">自定义的卡面的标识</param>
    public CardGiftPic(string backgroundPicUrl, string defaultGiftingMsg, string? outerImgId = default)
    {
        BackgroundPicUrl = backgroundPicUrl;
        OuterImgId = outerImgId;
        DefaultGiftingMsg = defaultGiftingMsg;
    }

    /// <summary>
    /// 卡面图片，须先将图片上传至CDN，大小控制在1000像素*600像素以下
    /// </summary>
    [JsonPropertyName("background_pic_url")]
    public string BackgroundPicUrl { get; set; }

    /// <summary>
    /// 自定义的卡面的标识
    /// </summary>
    [JsonPropertyName("outer_img_id")]
    public string? OuterImgId { get; set; }

    /// <summary>
    /// 该卡面对应的默认祝福语，当用户没有编辑内容时会随卡默认填写为用户祝福内容
    /// </summary>
    [JsonPropertyName("default_gifting_msg")]
    public string DefaultGiftingMsg { get; set; }
}
