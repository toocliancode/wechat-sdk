
using FluentValidation;

namespace WeChat.Mp.Message;

public class WeChatTemplateSendRequestVaildator : AbstractValidator<WeChatMpTemplateSendRequest>
{
    public WeChatTemplateSendRequestVaildator()
    {
        RuleFor(x => x.AccessToken).NotEmpty();
        RuleFor(x => x.ToUser).NotEmpty();
        RuleFor(x => x.TemplateId).NotEmpty();
        RuleFor(x => x.AppId).NotEmpty();
        RuleFor(x => x.Data).NotNull();
    }
}
