
using FluentValidation;

using WeChat.Applet.Request.QrCode;

namespace WeChat.Applet.Validator.QrCode
{
    public class WeChatGetWxaCodeUnlimitRequestVaildator : AbstractValidator<WeChatGetWxaCodeUnlimitRequest>
    {
        public WeChatGetWxaCodeUnlimitRequestVaildator()
        {
            RuleFor(x => x.Path).NotEmpty();
            RuleFor(x => x.Scene)
                .NotEmpty().MaximumLength(32);
        }
    }
}
