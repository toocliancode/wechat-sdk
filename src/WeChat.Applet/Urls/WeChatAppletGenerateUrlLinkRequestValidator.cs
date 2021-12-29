using FluentValidation;

namespace WeChat.Applet.Urls;

public class WeChatAppletGenerateUrlLinkRequestValidator : AbstractValidator<WeChatAppletGenerateUrlLinkRequest>
{
    public WeChatAppletGenerateUrlLinkRequestValidator()
    {
        RuleFor(x => x.AccessToken).NotEmpty();
    }
}
