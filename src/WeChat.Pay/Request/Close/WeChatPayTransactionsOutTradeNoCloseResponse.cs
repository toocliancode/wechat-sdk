namespace WeChat.Pay.Close;

/// <summary>
/// 关单API 响应
/// https://pay.weixin.qq.com/wiki/doc/apiv3/wxpay/pay/transactions/chapter3_6.shtml
/// </summary>
public class WeChatPayTransactionsOutTradeNoCloseResponse : WeChatHttpResponseBase
{
    public override bool IsSucceed()
    {
        return StatusCode == System.Net.HttpStatusCode.NoContent;
    }
}
