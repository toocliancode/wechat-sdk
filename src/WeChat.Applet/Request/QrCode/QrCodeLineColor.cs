
using System.Text.Json.Serialization;

namespace WeChat.Applet.QrCode;

public class QrCodeLineColor
{
    [JsonPropertyName("r")]
    public int R { get; set; }

    [JsonPropertyName("g")]
    public int G { get; set; }

    [JsonPropertyName("b")]
    public int B { get; set; }
}