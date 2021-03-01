using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using WeChat.Pay.Response.Jsapi;

namespace WeChat.Pay.Request
{
    public class WeChatPayTransactionsJsapiRequest : WeChatPayHttpReqestBase<WeChatPayTransactionsJsapiResponse>
    {
        protected override string EndpointName => WeChatPayEndpoints.PayTransactionsJsapi;
    }
}
