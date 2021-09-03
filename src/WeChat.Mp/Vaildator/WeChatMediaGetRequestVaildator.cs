using FluentValidation;

using WeChat.Mp.Request;

namespace WeChat.Mp.Vaildator
{
    public partial class WeChatJsapiConfigRequestVaildator
    {
        public class WeChatMediaGetRequestVaildator : AbstractValidator<WeChatMpMediaGetRequest>
        {
            public WeChatMediaGetRequestVaildator()
            {
                RuleFor(x => x.MediaId)
                    .NotEmpty();
            }
        }
    }
}
