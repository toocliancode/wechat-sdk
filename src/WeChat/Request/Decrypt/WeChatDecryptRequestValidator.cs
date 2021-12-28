
using FluentValidation;

namespace WeChat.Decrypt;

public class WeChatDecryptRequestValidator<T> : AbstractValidator<WeChatDecryptRequest<T>>
    where T : WeCahtDecryptResponseBase
{
    public WeChatDecryptRequestValidator()
    {
        RuleFor(x => x.SessionKey)
            .NotEmpty();

        RuleFor(x => x.EncryptedData)
            .NotEmpty();

        RuleFor(x => x.Iv)
            .NotEmpty();
    }
}
