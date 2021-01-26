using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WeChat.Builder;

namespace WeChat
{
    public static class WeChatBuilderExtensions
    {
        public static WeChatBuilder WithPay(this WeChatBuilder builder)
        {
            return builder.Configure(options =>
            {
                options.AddOrUpdateEndpoints(new Dictionary<string, string>
                {
                    //[WeChatMpEndpoints.ApiIp] = WeChatMpEndpoints.ApiIpValue,
                    //[WeChatMpEndpoints.CallbackIp] = WeChatMpEndpoints.CallbackIpValue,

                    //[WeChatMpEndpoints.MediaGet] = WeChatMpEndpoints.MediaGetValue,

                    //[WeChatMpEndpoints.MessageTemplateSend] = WeChatMpEndpoints.MessageTemplateSendValue,
                });
            });
        }
    }
}
