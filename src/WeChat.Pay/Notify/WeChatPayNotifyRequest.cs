﻿using System.Text.Encodings.Web;

using WeChat.Pay.Domain;
using WeChat.Pay.Notify;

namespace WeChat.Pay;

/// <summary>
/// 微信支付通知请求
/// </summary>
/// <typeparam name="TWeChatPayNotifyResponse"></typeparam>
public class WeChatPayNotifyRequest<TWeChatPayNotifyResponse>
    : WeChatPayRequest<TWeChatPayNotifyResponse>
    where TWeChatPayNotifyResponse : WeChatPayNotifyResponseBase, new()
{
    /// <summary>
    /// 通知ID
    /// </summary>
    /// <remarks>
    /// 通知的唯一ID
    /// <para>示例值：EV-2018022511223320873</para>
    /// </remarks>
    [JsonPropertyName("id")]
    public string Id { get; set; }

    /// <summary>
    /// 通知创建时间
    /// </summary>
    /// <remarks>
    /// 通知创建的时间，格式为yyyyMMddHHmmss
    /// <para>示例值：20180225112233</para>
    /// </remarks>
    [JsonPropertyName("create_time")]
    public string CreateTime { get; set; }

    /// <summary>
    /// 通知类型
    /// </summary>
    /// <remarks>
    /// 通知的类型，支付成功通知的类型为TRANSACTION.SUCCESS
    /// <para>示例值：TRANSACTION.SUCCESS</para>
    /// </remarks>
    [JsonPropertyName("event_type")]
    public string EventType { get; set; }

    /// <summary>
    /// 概要
    /// </summary>
    /// <remarks>
    /// <para>示例值：支付成功</para>
    /// </remarks>
    [JsonPropertyName("summary")]
    public string Summary { get; set; }

    /// <summary>
    /// 通知数据类型
    /// </summary>
    /// <remarks>
    /// 通知的资源数据类型，支付成功通知为encrypt-resource
    /// <para>示例值：encrypt-resource</para>
    /// </remarks>
    [JsonPropertyName("resource_type")]
    public string ResourceType { get; set; }

    /// <summary>
    /// 通知数据
    /// </summary>
    /// <remarks>
    /// 通知资源数据
    /// json格式，见示例
    /// </remarks>
    [JsonPropertyName("resource")]
    public Resource Resource { get; set; }


    [JsonIgnore]
    public virtual JsonSerializerOptions? JsonSerializerOptions { get; set; } = new()
    {
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };

    public override Task<TWeChatPayNotifyResponse> Handle(IWeChatRequetHandleContext context)
    {
        var resourcePlaintext = CryptographyExtensions.AesGcmDecrypt(Resource.Nonce, Resource.Ciphertext, Resource.AssociatedData, Options.V3Key);
        var response = JsonSerializer.Deserialize<TWeChatPayNotifyResponse>(resourcePlaintext, JsonSerializerOptions) ?? new();
        response.ResourcePlaintext = resourcePlaintext;
        return Task.FromResult(response);
    }
}