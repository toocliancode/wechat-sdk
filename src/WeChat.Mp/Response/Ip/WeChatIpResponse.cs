using System.Text.Json.Serialization;

namespace WeChat.Mp.Response
{
    /// <summary>
    /// 获取微信服务器IP地址 响应
    /// </summary>
    public class WeChatIpResponse : WeChatResponse
    {
        /// <summary>
        /// 微信服务器IP地址列表
        /// </summary>
        [JsonPropertyName("ip_list")]
        public string IpList { get; set; }
    }
}
