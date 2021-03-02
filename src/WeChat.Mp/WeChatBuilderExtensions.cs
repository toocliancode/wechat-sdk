﻿using System.Collections.Generic;

using WeChat.Builder;

namespace WeChat
{
    public static class WeChatBuilderExtensions
    {
        public static WeChatBuilder WithMp(this WeChatBuilder builder)
        {
            return builder.Configure(options =>
             {
                 options.Configurations.TryAdd("WeChatMp", new WeChatConfiguration("WeChatMp"));

                 options.AddOrUpdateEndpoints(new Dictionary<string, string>
                 {
                     [WeChatMpEndpoints.ApiIp] = WeChatMpEndpoints.ApiIpValue,
                     [WeChatMpEndpoints.CallbackIp] = WeChatMpEndpoints.CallbackIpValue,

                     [WeChatMpEndpoints.MediaGet] = WeChatMpEndpoints.MediaGetValue,

                     [WeChatMpEndpoints.MessageTemplateSend] = WeChatMpEndpoints.MessageTemplateSendValue,
                 });
             });
        }
    }
}
