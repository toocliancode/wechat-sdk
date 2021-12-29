namespace WeChat.Pay;

public interface IWeChatPayAuthorizationHandler
{
    Task Handle(HttpRequestMessage message, WeChatPayOptions settings);
}
