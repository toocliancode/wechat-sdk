﻿using System.Text.Json.Serialization;

namespace WeChat;

public class WeChatMpHttpResponse : WeChatHttpResponse
{
    /// <summary>
    /// 错误码
    /// </summary>
    [JsonPropertyName("errcode")]
    public virtual int ErrCode { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("errmsg")]
    public virtual string ErrMsg { get; set; }

    public override bool IsSucceed()
    {
        return ErrCode == 0;
    }
}
