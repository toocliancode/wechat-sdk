﻿using System.Text.Json.Serialization;

namespace WeChat.Applet.Urls;

/// <summary>
/// <b>[urlscheme.generate]</b>
/// 获取小程序 scheme 码，适用于短信、邮件、外部网页、微信内等拉起小程序的业务场景。通过该接口，可以选择生成到期失效和永久有效的小程序码
/// https://developers.weixin.qq.com/miniprogram/dev/api-backend/open-api/url-scheme/urlscheme.generate.html
/// </summary>
public class WeChatAppletGenerateSchemeRequest
    : WeChatHttpRequest<WeChatAppletGenerateSchemeResponse>
{
    public static string Endpoint = "https://api.weixin.qq.com/cgi-bin/wxaapp/createwxaqrcode";

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatAppletGenerateSchemeRequest"/>
    /// </summary>
    public WeChatAppletGenerateSchemeRequest()
        : base(HttpMethod.Post)
    {
    }

    /// <summary>
    /// 实例化一个新的 <see cref="WeChatAppletGenerateSchemeRequest"/>
    /// </summary>
    /// <param name="accessToken">微信API access_token</param>
    /// <param name="jumpWxa">跳转到的目标小程序信息</param>
    /// <param name="isExpire">生成的 scheme 码类型，到期失效：true，永久有效：false</param>
    /// <param name="expireType">到期失效的 scheme 码失效类型，失效时间：0，失效间隔天数：1</param>
    /// <param name="expireTime">到期失效的 scheme 码的失效时间，为 Unix 时间戳。生成的到期失效 scheme 码在该时间前有效。
    /// 最长有效期为1年。is_expire 为 true 且 expire_type 为 0 时必填</param>
    /// <param name="expireInterval">到期失效的 scheme 码的失效间隔天数。生成的到期失效 scheme 码在该间隔时间到达前有效。
    /// 最长间隔天数为365天。is_expire 为 true 且 expire_type 为 1 时必填</param>
    public WeChatAppletGenerateSchemeRequest(
        string accessToken,
        GenerateSchemeJumpWxa? jumpWxa = default,
        bool isExpire = false,
        int expireType = 0,
        DateTime? expireTime = null,
        int? expireInterval = null)
        : this()
    {
        AccessToken = accessToken;
        JumpWxa = jumpWxa;
        IsExpire = isExpire;
        ExpireType = expireType;
        ExpireTime = expireTime;
        ExpireInterval = expireInterval;
    }

    /// <summary>
    /// 微信API access_token
    /// </summary>
    [JsonIgnore]
    public string AccessToken { get; set; }

    /// <summary>
    /// 跳转到的目标小程序信息
    /// </summary>
    [JsonPropertyName("jump_wxa")]
    public GenerateSchemeJumpWxa? JumpWxa { get; set; }

    /// <summary>
    /// 生成的 scheme 码类型，到期失效：true，永久有效：false
    /// </summary>
    [JsonPropertyName("is_expire")]
    public bool IsExpire { get; set; }

    /// <summary>
    /// 到期失效的 scheme 码失效类型，失效时间：0，失效间隔天数：1
    /// </summary>
    [JsonPropertyName("expire_type")]
    public int ExpireType { get; set; }

    /// <summary>
    /// 到期失效的 scheme 码的失效时间，为 Unix 时间戳。生成的到期失效 scheme 码在该时间前有效。
    /// 最长有效期为1年。is_expire 为 true 且 expire_type 为 0 时必填
    /// </summary>
    [JsonPropertyName("expire_time")]
    public DateTime? ExpireTime { get; set; }

    /// <summary>
    /// 到期失效的 scheme 码的失效间隔天数。生成的到期失效 scheme 码在该间隔时间到达前有效。
    /// 最长间隔天数为365天。is_expire 为 true 且 expire_type 为 1 时必填
    /// </summary>
    [JsonPropertyName("expire_interval")]
    public int? ExpireInterval { get; set; }

    protected override string GetRequestUri()
    {
        return $"{Endpoint}?access_token={AccessToken}";
    }
}