namespace WeChat.Pay.Response
{
    /// <summary>
    /// 关单API 响应
    /// https://pay.weixin.qq.com/wiki/doc/apiv3/wxpay/pay/transactions/chapter3_6.shtml
    /// </summary>
    public class WeChatPayTransactionsOutTradeNoCloseResponse : WeChatResponseBase
    {
        public override bool IsSuccessed()
        {
            return StatusCode == System.Net.HttpStatusCode.NoContent;
        }
    }
}
