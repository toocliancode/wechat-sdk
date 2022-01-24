//using FluentValidation;

//namespace WeChat.Applet.QrCode;

//public class WeChatAppletGetWxaCodeUnlimitRequestVaildator : AbstractValidator<WeChatAppletGetWxaCodeUnlimitRequest>
//{
//    public WeChatAppletGetWxaCodeUnlimitRequestVaildator()
//    {
//        RuleFor(x => x.AccessToken).NotEmpty();
//        RuleFor(x => x.Path).NotEmpty();
//        RuleFor(x => x.Scene)
//            .NotEmpty().MaximumLength(32);
//    }
//}