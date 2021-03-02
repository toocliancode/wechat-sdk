using System.Text.Json.Serialization;

namespace WeChat.Pay.Domain
{
    /// <summary>
    /// 支付者信息
    /// </summary>
    public class PayerInfo
    {
        /// <summary>
        /// 实例化一个支付者信息
        /// </summary>
        public PayerInfo()
        {
        }

        /// <summary>
        /// 实例化一个支付者信息
        /// </summary>
        /// <param name="openId">用户标识，用户在直连商户appid下的唯一标识。</param>
        public PayerInfo(string openId)
        {
            OpenId = openId;
        }

        /// <summary>
        /// 用户标识
        /// 用户在直连商户appid下的唯一标识。
        /// 示例值：oUpF8uMuAJO_M2pxb1Q9zNjWeS6o
        /// </summary>
        [JsonPropertyName("openid")]
        public string OpenId { get; set; }
    }
}
