
using FluentValidation;

using WeChat.Applet.Request.Message;

namespace WeChat.Applet.Validator.Message
{
    public class WeChatSubscribeMessageSendRequestVaildator : AbstractValidator<WeChatSubscribeMessageSendRequest>
    {
        public WeChatSubscribeMessageSendRequestVaildator()
        {
            RuleFor(x => x.ToUser).NotEmpty();
            RuleFor(x => x.TemplateId).NotEmpty();
            RuleFor(x => x.Data).NotNull();
        }
    }
}
