using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeChat
{
    public partial class WeChatMpEndpoints
    {
        /// <summary>
        /// 获取临时素材 端点名称
        /// </summary>
        public const string MediaGet = "MediaGetEndpoint";

        /// <summary>
        /// https://api.weixin.qq.com/cgi-bin/media/get?access_token=ACCESS_TOKEN&amp;media_id=MEDIA_ID
        /// </summary>
        public const string MediaGetValue = " https://api.weixin.qq.com/cgi-bin/media/get";

        /// <summary>
        /// 获取微信callback IP地址 端点名称
        /// </summary>
        public const string CallbackIp = "CallbackIpEndpoint";

        /// <summary>
        /// 获取微信callback IP地址 端点值
        /// </summary>
        public const string CallbackIpValue = "https://api.weixin.qq.com/cgi-bin/getcallbackip";

        /// <summary>
        /// 获取微信API接口 IP地址 端点名称
        /// </summary>
        public const string ApiIp = "ApiIpEndpoint";

        /// <summary>
        ///  获取微信API接口 IP地址 端点值
        /// </summary>
        public const string ApiIpValue = "https://api.weixin.qq.com/cgi-bin/get_api_domain_ip";

        /// <summary>
        /// 发送模板消息 端点名称
        /// </summary>
        public const string MessageTemplateSend = "MessageTemplateSendEndpoint";

        /// <summary>
        ///   发送模板消息 端点值
        ///  https://api.weixin.qq.com/cgi-bin/message/template/send?access_token=ACCESS_TOKEN
        /// </summary>
        public const string MessageTemplateSendValue = "https://api.weixin.qq.com/cgi-bin/message/template/send";
    }
}
