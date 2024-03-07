namespace WeChat;

public interface IWeChatPayResponseSignatureChecker
{
    Task Check(HttpResponseMessage message, WeChatPayOptions options);
}
