namespace WeChat.Pay;

public interface IWeChatPayAuthorizationHandler
{
    Task Handler(HttpRequestMessage message, WeChatPayOptions settings);
}
