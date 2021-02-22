using FluentValidation;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WeChat.Request;

namespace WeChat.Vaildator
{
    public class WeChatAccessTokenRequestValidator : AbstractValidator<WeChatAccessTokenRequest>
    {
        public WeChatAccessTokenRequestValidator()
        {
            RuleFor(x => x.AppId).NotEmpty();
            RuleFor(x => x.Secret).NotEmpty();
        }
    }
}
