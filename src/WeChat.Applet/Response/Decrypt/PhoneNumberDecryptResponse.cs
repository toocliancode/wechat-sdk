namespace WeChat.Applet.Response
{
    public class PhoneNumberDecryptResponse : DecryptResponseBase
    {
        public string PhoneNumber { get; set; }

        public string PurePhoneNumber { get; set; }

        public string CountryCode { get; set; }
    }
}
