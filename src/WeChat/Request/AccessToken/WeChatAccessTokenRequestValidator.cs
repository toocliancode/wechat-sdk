using FluentValidation;
namespace WeChat.AccessToken;

public class WeChatAccessTokenRequestValidator : AbstractValidator<WeChatAccessTokenRequest>
{
    public WeChatAccessTokenRequestValidator()
    {
        RuleFor(x => x.AppId).NotEmpty();
        RuleFor(x => x.Secret).NotEmpty();
    }
}
