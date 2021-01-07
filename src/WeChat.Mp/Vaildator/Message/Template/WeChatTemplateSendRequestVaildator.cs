using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentValidation;

using WeChat.Mp.Request.Message;

namespace WeChat.Mp.Vaildator.Message
{
    public class WeChatTemplateSendRequestVaildator:AbstractValidator<WeChatTemplateSendRequest>
    {
        public WeChatTemplateSendRequestVaildator()
        {
            RuleFor(x => x.ToUser).NotEmpty();
            RuleFor(x => x.TemplateId).NotEmpty();
            RuleFor(x => x.Data).NotNull();
        }
    }
}
