namespace WeChat.Applet.Checks;

public class WeChatAppletImageSecCheckResponse
    : WeChatHttpResponse
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
