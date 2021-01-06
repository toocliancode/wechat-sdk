using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WeChat.Response
{
    /// <summary>
    /// 响应 access_token 请求
    /// </summary>
    public class WeChatAccessTokenResponse : WeChatResponse
    {
        /// <summary>
        /// 获取到的凭证
        /// </summary>
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// 凭证有效时间，单位：秒
        /// </summary>
        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; set; }
    }
}
