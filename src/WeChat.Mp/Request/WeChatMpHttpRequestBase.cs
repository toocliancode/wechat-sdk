namespace WeChat.Mp.Request
{
    public abstract class WeChatMpHttpRequestBase<TWeChatResponse> : WeChatHttpRequestBase<TWeChatResponse>
        where TWeChatResponse : WeChatResponseBase
    {
        protected override WeChatConfiguration Configuration => base.Configuration.Configure("Mp");
    }
}
