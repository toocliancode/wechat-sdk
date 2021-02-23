namespace WeChat.Applet.Request
{
    public abstract class WeChatAppletHttpRequestBase<TWeChatResponse> : WeChatHttpRequestBase<TWeChatResponse>
       where TWeChatResponse : WeChatResponseBase
    {
        protected override WeChatConfiguration Configuration => base.Configuration.Configure("Applet");
    }
}
