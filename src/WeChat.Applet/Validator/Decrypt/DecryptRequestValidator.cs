
using FluentValidation;

using WeChat.Applet.Request.Decrypt;
using WeChat.Applet.Response.Decrypt;

namespace WeChat.Applet.Validator.Decrypt
{
    public class DecryptRequestValidator<T> : AbstractValidator<DecryptRequest<T>>
        where T : DecryptResponseBase
    {
        public DecryptRequestValidator()
        {
            RuleFor(x => x.SessionKey)
                .NotEmpty();

            RuleFor(x => x.EncryptedData)
                .NotEmpty();

            RuleFor(x => x.Iv)
                .NotEmpty();
        }
    }
}
