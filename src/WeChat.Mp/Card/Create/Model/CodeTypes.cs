namespace WeChat.Mp.Card;

/// <summary>
/// 卡券码展示类型
/// </summary>
public static class CodeTypes
{
    /// <summary>
    /// 文本
    /// </summary>
    public const string CODE_TYPE_TEXT = "CODE_TYPE_TEXT";

    /// <summary>
    /// 一维码
    /// </summary>
    public const string CODE_TYPE_BARCODE = "CODE_TYPE_BARCODE";

    /// <summary>
    /// 二维码
    /// </summary>
    public const string CODE_TYPE_QRCODE= "CODE_TYPE_QRCODE";

    /// <summary>
    /// 一维码无code显示
    /// </summary>
    public const string CODE_TYPE_ONLY_BARCODE = "CODE_TYPE_ONLY_BARCODE";

    /// <summary>
    /// 二维码无code显示
    /// </summary>
    public const string CODE_TYPE_ONLY_QRCODE= "CODE_TYPE_ONLY_QRCODE";

    /// <summary>
    /// 不显示code和条形码类型
    /// </summary>
    public const string CODE_TYPE_NONE= "CODE_TYPE_NONE";

}