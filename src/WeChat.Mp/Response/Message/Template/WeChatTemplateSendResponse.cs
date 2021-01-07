using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace WeChat.Mp.Response.Message
{
    public class WeChatTemplateSendResponse:WeChatResponse
    {
        /// <summary>
        /// 消息Id
        /// </summary>
        [JsonPropertyName("msgid")]
        public long MsgId { get; set; }
    }
}
