
using Microsoft.Extensions.DependencyInjection.Extensions;

using WeChat.Builder;
using WeChat.Pay;

namespace WeChat;

public static class WeChatBuilderExtensions
{
    public static WeChatBuilder WithPay(this WeChatBuilder builder)
    {
        builder.Services.TryAddSingleton<IWeChatPayCertificateStore, WeChatPayCertificateStore>();
        builder.Services.TryAddSingleton<IWeChatPayPlatformCertificateStore, WeChatPayPlatformCertificateStore>();
        builder.Services.TryAddSingleton<IWeChatPayAuthorizationHandler, WeChatPayAuthorizationHandler>();
        builder.Services.TryAddSingleton<IWeChatPayResponseSignatureChecker, WeChatPayResponseSignatureChecker>();

        return builder;
    }
}
