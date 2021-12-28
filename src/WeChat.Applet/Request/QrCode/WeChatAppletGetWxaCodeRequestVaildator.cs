using FluentValidation;

namespace WeChat.Applet.QrCode;

public class WeChatAppletGetWxaCodeRequestVaildator : AbstractValidator<WeChatAppletGetWxaCodeRequest>
{
    public WeChatAppletGetWxaCodeRequestVaildator()
    {
        RuleFor(x => x.AccessToken).NotEmpty();
        RuleFor(x => x.Path).NotEmpty();
    }
}