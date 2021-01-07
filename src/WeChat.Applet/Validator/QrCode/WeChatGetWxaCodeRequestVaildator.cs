
using FluentValidation;

using WeChat.Applet.Request.QrCode;

namespace WeChat.Applet.Validator.QrCode
{
    public class WeChatGetWxaCodeRequestVaildator : AbstractValidator<WeChatGetWxaCodeRequest>
    {
        public WeChatGetWxaCodeRequestVaildator()
        {
            RuleFor(x => x.Path).NotEmpty();
        }
    }
}
