
using FluentValidation;

namespace WeChat.Applet.Urls;

public class WeChatAppletQueryUrlLinkRequestValidator : AbstractValidator<WeChatAppletQueryUrlLinkRequest>
{
    public WeChatAppletQueryUrlLinkRequestValidator()
    {
        RuleFor(x => x.AccessToken).NotEmpty();
        RuleFor(x => x.UrlLink).NotEmpty();
    }
}
