using System.Collections.Generic;

using WeChat.Builder;

namespace WeChat
{
    public static class WeChatBuilderExtensions
    {
        public static WeChatBuilder WithApplet(this WeChatBuilder builder)
        {
            return builder.Configure(options =>
            {
                options.AddOrUpdateEndpoints(new Dictionary<string, string>
                {
                    [WeChatAppletEndpoints.Code2Session] = WeChatAppletEndpoints.Code2SessionValue,

                    [WeChatAppletEndpoints.SubscribeMessageSend] = WeChatAppletEndpoints.SubscribeMessageSendValue,

                    [WeChatAppletEndpoints.CreateQrCode] = WeChatAppletEndpoints.CreateQrCodeValue,
                    [WeChatAppletEndpoints.GetWxaCode] = WeChatAppletEndpoints.GetWxaCodeValue,
                    [WeChatAppletEndpoints.GetWxaCodeUnlimit] = WeChatAppletEndpoints.GetWxaCodeUnlimitValue,
                });
            });
        }
    }
}
