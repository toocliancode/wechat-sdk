using Microsoft.Extensions.DependencyInjection.Extensions;

using WeChat;
using WeChat.Pay;

namespace Microsoft.Extensions.DependencyInjection;

public static class MediationConfigurationExtensions
{
    public static IMediationConfiguration AddWeChatPay(this IMediationConfiguration configuration)
    {
        configuration.AddWeChat();

        configuration.Services.TryAddSingleton<IWeChatPayCertificateStore, WeChatPayCertificateStore>();
        configuration.Services.TryAddSingleton<IWeChatPayPlatformCertificateStore, WeChatPayPlatformCertificateStore>();
        configuration.Services.TryAddSingleton<IWeChatPayAuthorizationHandler, WeChatPayAuthorizationHandler>();
        configuration.Services.TryAddSingleton<IWeChatPayResponseSignatureChecker, WeChatPayResponseSignatureChecker>();

        configuration.Services.TryAddTransient<IRequestHandler<TransactionsJsapiSdk.Request, TransactionsJsapiSdk.Response>, TransactionsJsapiSdk.Handler>();

        configuration.Services.TryAddTransient<IRequestHandler<Notify<TransactionsNotifyResponse>.Request, TransactionsNotifyResponse>, Notify<TransactionsNotifyResponse>.Handler>();
        configuration.Services.TryAddTransient<IRequestHandler<Notify<RefundNotifyResponse>.Request, RefundNotifyResponse>, Notify<RefundNotifyResponse>.Handler>();

        return configuration;
    }
}