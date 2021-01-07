using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentValidation;

using WeChat.Applet.Request.QrCode;

namespace WeChat.Applet.Validator.QrCode
{
    public class WeChatCreateWxaQrCodeRequestVaildator:AbstractValidator<WeChatCreateWxaQrCodeRequest>
    {
        public WeChatCreateWxaQrCodeRequestVaildator()
        {
            RuleFor(x => x.Path).NotEmpty();
        }
    }
}
