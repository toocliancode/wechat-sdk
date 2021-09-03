using System.ComponentModel.DataAnnotations;

namespace WeChat.Mp.Web
{
    public class WeCahtMpJsapiConfigModel
    {
        /// <summary>
        /// 页面链接
        /// </summary>
        [Required]
        public string Url { get; set; }
    }
}
