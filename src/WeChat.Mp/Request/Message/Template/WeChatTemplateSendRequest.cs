using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json.Serialization;

using WeChat.Mp.Response.Message;

namespace WeChat.Mp.Request.Message
{
    /// <summary>
    /// 发送模板消息 请求
    /// https://developers.weixin.qq.com/doc/offiaccount/Message_Management/Template_Message_Interface.html#5
    /// </summary>
    public class WeChatTemplateSendRequest : WeChatMpHttpRequestBase<WeChatTemplateSendResponse>
    {
        public WeChatTemplateSendRequest()
        {
        }

        /// <summary>
        /// 实例化一个新的 发送模板消息 请求
        /// </summary>
        /// <param name="toUser">接收者openid</param>
        /// <param name="templateId">模板Id</param>
        /// <param name="url">模板跳转链接（海外帐号没有跳转能力）</param>
        /// <param name="data">
        /// 模板数据
        /// name:{
        ///     value:"",
        ///     color:""
        /// }
        /// </param>
        /// <param name="miniProgram">
        /// 跳小程序所需数据，不需跳小程序可不用传该数据
        /// appid:所需跳转到的小程序appid（该小程序appid必须与发模板消息的公众号是绑定关联关系，暂不支持小游戏）
        /// pagepath:所需跳转到小程序的具体页面路径，支持带参数,（示例index?foo=bar），要求该小程序已发布，暂不支持小游戏
        /// </param>
        public WeChatTemplateSendRequest(
            string toUser,
            string templateId,
            Dictionary<string, Dictionary<string, string>> data,
             string url = null,
            Dictionary<string, string> miniProgram = null)
        {
            ToUser = toUser;
            TemplateId = templateId;
            Url = url;
            MiniProgram = miniProgram;
            Data = data;
        }

        protected override string EndpointName => WeChatMpEndpoints.MessageTemplateSend;
        protected override HttpMethod Method => HttpMethod.Post;

        /// <summary>
        /// 接收者openid
        /// </summary>
        [JsonPropertyName("touser")]
        public string ToUser { get; set; }

        /// <summary>
        /// 模板Id
        /// </summary>
        [JsonPropertyName("template_id")]
        public string TemplateId { get; set; }

        /// <summary>
        /// 模板跳转链接（海外帐号没有跳转能力）
        /// </summary>
        [JsonPropertyName("url")]
        public string Url { get; set; }

        /// <summary>
        /// 跳小程序所需数据，不需跳小程序可不用传该数据
        /// appid:所需跳转到的小程序appid（该小程序appid必须与发模板消息的公众号是绑定关联关系，暂不支持小游戏）
        /// pagepath:所需跳转到小程序的具体页面路径，支持带参数,（示例index?foo=bar），要求该小程序已发布，暂不支持小游戏
        /// </summary>
        [JsonPropertyName("miniprogram")]
        public Dictionary<string, string> MiniProgram { get; set; }

        /// <summary>
        /// 模板数据
        /// name:{
        ///     value:"",
        ///     color:""
        /// }
        /// </summary>
        [JsonPropertyName("data")]
        public Dictionary<string, Dictionary<string, string>> Data { get; set; }

    }
}
