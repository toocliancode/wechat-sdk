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
            //RuleFor(x => x.Body["appid"]).NotEmpty();
            //RuleFor(x => x.Body["secret"]).NotEmpty();
            RuleFor(x => x.Body["grant_Type"]).Equal("client_credential");
        }
    }
}
