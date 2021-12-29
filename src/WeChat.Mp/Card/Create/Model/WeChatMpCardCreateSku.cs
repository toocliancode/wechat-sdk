namespace WeChat.Mp.Card;

/// <summary>
/// 商品库存信息
/// </summary>
public class WeChatMpCardCreateSku
{
    public WeChatMpCardCreateSku()
    {
    }

    public WeChatMpCardCreateSku(int quantity)
    {
        Quantity = quantity;
    }

    /// <summary>
    /// 卡券库存的数量，上限为100000000
    /// </summary>
    public int Quantity { get; set; }
}
