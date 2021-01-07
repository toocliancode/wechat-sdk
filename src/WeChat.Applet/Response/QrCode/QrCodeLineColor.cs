using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WeChat.Applet.Response.QrCode
{
    public class QrCodeLineColor
    {
        [JsonPropertyName("r")]
        public int R { get; set; }

        [JsonPropertyName("g")]
        public int G { get; set; }

        [JsonPropertyName("b")]
        public int B { get; set; }
    }
}
