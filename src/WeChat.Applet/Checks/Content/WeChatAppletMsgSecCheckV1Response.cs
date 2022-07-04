using System.Text.Json;
namespace WeChat.Applet.Checks;

public class WeChatAppletMsgSecCheckV1Response : WeChatHttpResponse
{
    /// <summary>
    /// true:表示有敏感信息
    /// </summary>
    /// <returns></returns>
    public bool IsRisky()
    {
        return ErrCode == 87014;
    }
}
