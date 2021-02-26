using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

using WeChat.Pay.Domain.Certificate;

namespace WeChat.Pay.Response.Certificates
{
    public class WeChatPayCertificatesResponse : WeChatResponseBase
    {
        [JsonPropertyName("data")]
        public List<Certificate> Certificates { get; set; }
    }
}
