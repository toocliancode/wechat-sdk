using FluentValidation;

using WeChat.Request;

namespace WeChat.Vaildator
{
    public class WeChatTicketRequestValidator : AbstractValidator<WeChatTicketRequest>
    {
        public WeChatTicketRequestValidator()
        {
            RuleFor(x => x.Type)
                .Must((request, type) => type == "jsapi" || type == "wx_card")
                .WithMessage($"Type参数必须 等于`jsapi`或`wx_card`");
        }
    }
}
