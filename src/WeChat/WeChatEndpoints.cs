using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeChat
{
    public partial class WeChatEndpoints
    {
        /// <summary>
        /// 微信接口token端点名称
        /// </summary>
        public const string AccessToken = "AccessTokenEndpoint";

        public const string AccessTokenValue = "https://api.weixin.qq.com/cgi-bin/token";

        /// <summary>
        /// 调用微信JS接口的临时票据端点名称
        /// </summary>
        public const string Ticket = "TicketEndpoint";

        /// <summary>
        /// 默认值 调用微信JS接口的临时票据端点
        /// GET https://api.weixin.qq.com/cgi-bin/ticket/getticket?access_token=ACCESS_TOKEN&amp;type=jsapi
        /// </summary>
        public const string TicketValue = "https://api.weixin.qq.com/cgi-bin/ticket/getticket";
    }
}
