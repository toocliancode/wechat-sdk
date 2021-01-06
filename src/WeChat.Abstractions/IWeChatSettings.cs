namespace WeChat
{
    /// <summary>
    /// 微信配置
    /// </summary>
    public interface IWeChatSettings
    {
        /// <summary>
        /// 微信应用号(公众平台AppId/开放平台AppId/小程序AppId/企业微信CorpId)
        /// </summary>
        string AppId { get; set; }

        /// <summary>
        /// 微信应用密钥
        /// </summary>
        string Secret { get; set; }
    }
}
