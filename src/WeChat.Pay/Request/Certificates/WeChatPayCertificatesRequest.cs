﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WeChat.Pay.Response.Certificates;

namespace WeChat.Pay.Request
{
    /// <summary>
    /// 获取平台证书列表
    /// 
    /// https://wechatpay-api.gitbook.io/wechatpay-api-v3/jie-kou-wen-dang/ping-tai-zheng-shu
    /// </summary>
    public class WeChatPayCertificatesRequest : WeChatPayHttpReqestBase<WeChatPayCertificatesResponse>
    {
        protected override string EndpointName => WeChatPayEndpoints.Certificates;
        protected override bool EnabledSignatureCheck => false;
    }
}
