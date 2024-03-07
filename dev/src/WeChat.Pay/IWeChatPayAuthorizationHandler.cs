namespace WeChat;

public interface IWeChatPayAuthorizationHandler
{
    Task Handle(HttpRequestMessage message, WeChatPayOptions options);
}
