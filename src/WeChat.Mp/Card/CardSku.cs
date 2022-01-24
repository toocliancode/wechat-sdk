namespace WeChat.Mp.Card;

/// <summary>
/// 商品库存信息
/// </summary>
public class CardSku
{
    public CardSku()
    {
    }

    public CardSku(int quantity)
    {
        Quantity = quantity;
    }

    /// <summary>
    /// 卡券库存的数量，上限为100000000
    /// </summary>
    public int Quantity { get; set; }
}
