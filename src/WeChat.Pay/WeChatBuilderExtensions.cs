
using Microsoft.Extensions.DependencyInjection.Extensions;

using System.Collections.Generic;

using WeChat.Builder;
using WeChat.Pay;

namespace WeChat
{
    public static class WeChatBuilderExtensions
    {
        public static WeChatBuilder WithPay(this WeChatBuilder builder)
        {
            builder.Services.TryAddSingleton<IWeChatPayCertificateStore, WeChatPayCertificateStore>();
            builder.Services.TryAddSingleton<IWeChatPayPlatformCertificateStore, WeChatPayPlatformCertificateStore>();
            builder.Services.TryAddSingleton<IWeChatPayAuthorizationHandler, WeChatPayAuthorizationHandler>();
            builder.Services.TryAddSingleton<IWeChatPayResponseSignatureChecker, WeChatPayResponseSignatureChecker>();

            return builder.Configure(options =>
            {
                options.Configurations.TryAdd("WeChatPay", new WeChatConfiguration("WeChatPay"));

                options.AddOrUpdateEndpoints(new Dictionary<string, string>
                {
                    [WeChatPayEndpoints.Certificates] = WeChatPayEndpoints.CertificatesValue,

                    [WeChatPayEndpoints.TransactionsApp] = WeChatPayEndpoints.TransactionsAppValue,
                    [WeChatPayEndpoints.TransactionsJsapi] = WeChatPayEndpoints.TransactionsJsapiValue,
                    [WeChatPayEndpoints.TransactionsNative] = WeChatPayEndpoints.TransactionsNativeValue,
                    [WeChatPayEndpoints.TransactionsH5] = WeChatPayEndpoints.TransactionsH5Value,

                    [WeChatPayEndpoints.TransactionsId] = WeChatPayEndpoints.TransactionsIdValue,
                    [WeChatPayEndpoints.TransactionsOutTradeNo] = WeChatPayEndpoints.TransactionsOutTradeNoValue,

                    [WeChatPayEndpoints.TransactionsOutTradeNoClose] = WeChatPayEndpoints.TransactionsOutTradeNoCloseValue,
                });
            });
        }
    }
}
