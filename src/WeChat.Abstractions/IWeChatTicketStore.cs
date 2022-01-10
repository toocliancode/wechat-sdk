﻿namespace WeChat;

/// <summary>
/// 微信jsapi凭据存储
/// </summary>
public interface IWeChatTicketStore
{
    /// <summary>
    /// 获取指定配置凭证
    /// </summary>
    /// <param name="appId"></param>
    /// <param name="secret"></param>
    /// <param name="ticketType">凭证类型：jsapi、wx_card</param>
    /// <returns></returns>
    Task<string> GetAsync(string appId, string secret, string ticketType = "jsapi");
}