namespace WeChat.Pay;

public interface IWeChatPayResponseSignatureChecker
{
    Task Check(HttpResponseMessage message, WeChatPayOptions settings);
}
