﻿namespace WeChat.Mp.Response
{
    /// <summary>
    /// jssdk配置 响应
    /// </summary>
    public class WeChatJsapiConfigResponse
    {

        public WeChatJsapiConfigResponse()
        {
        }

        public WeChatJsapiConfigResponse(string appId, string timestamp, string nonceStr)
        {
            AppId = appId;
            Timestamp = timestamp;
            NonceStr = nonceStr;
        }

        /// <summary>
        /// appid
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 时间戳
        /// </summary>
        public string Timestamp { get; set; }

        /// <summary>
        /// 随机字符串
        /// </summary>
        public string NonceStr { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        public string Signature { get; set; }
    }
}
