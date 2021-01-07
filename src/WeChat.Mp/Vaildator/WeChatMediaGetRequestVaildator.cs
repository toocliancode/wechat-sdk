using FluentValidation;

using WeChat.Mp.Request;

namespace WeChat.Mp.Vaildator
{
    public partial class WeChatJsapiConfigRequestVaildator
    {
        public class WeChatMediaGetRequestVaildator : AbstractValidator<WeChatMediaGetRequest>
        {
            public WeChatMediaGetRequestVaildator()
            {
                RuleFor(x => x.MediaId)
                    .NotEmpty();
            }
        }
    }
}
