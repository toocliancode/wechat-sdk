namespace WeChat.Applet.Response
{
    public class UserInfoDecryptResponse : DecryptResponseBase
    {
        public string OpenId { get; set; }

        public string NickName { get; set; }

        public string Gender { get; set; }

        public string City { get; set; }

        public string Province { get; set; }

        public string Country { get; set; }

        public string AvatarUrl { get; set; }

        public string UnionId { get; set; }
    }
}
