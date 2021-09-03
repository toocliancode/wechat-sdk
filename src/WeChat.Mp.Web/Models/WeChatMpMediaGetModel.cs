using System.ComponentModel.DataAnnotations;

namespace WeChat.Mp.Web
{
    /// <summary>
    /// 获取临时素材
    /// </summary>
    public class WeChatMpMediaGetModel
    {
        /// <summary>
        /// 素材Id
        /// </summary>
        [Required]
        public string MediaId { get; set; }

        /// <summary>
        /// 文件扩展名，默认为.png
        /// </summary>
        public string Ext { get; set; } = ".png";
    }
}
