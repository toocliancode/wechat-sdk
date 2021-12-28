namespace WeChat.Decrypt;

public class WeChatPhoneNumberDecryptResponse : WeCahtDecryptResponseBase
{
    public string PhoneNumber { get; set; }

    public string PurePhoneNumber { get; set; }

    public string CountryCode { get; set; }
}
