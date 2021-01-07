using FluentValidation;

using WeChat.Applet.Request;

namespace WeChat.Applet.Validator
{
    public class WeChatCode2SessionRequestValidator : AbstractValidator<WeChatCode2SessionRequest>
    {
        public WeChatCode2SessionRequestValidator()
        {
            RuleFor(x => x.JsCode)
                .NotEmpty();
        }
    }
}
