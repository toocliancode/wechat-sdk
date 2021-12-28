using FluentValidation;

namespace WeChat.Applet.Urls;

public class WeChatAppletGenerateSchemeRequestValidator : AbstractValidator<WeChatAppletGenerateSchemeRequest>
{
    public WeChatAppletGenerateSchemeRequestValidator()
    {
        RuleFor(x => x.AccessToken).NotEmpty();
    }
}
