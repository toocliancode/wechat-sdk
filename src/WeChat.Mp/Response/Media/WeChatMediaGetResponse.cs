using System.Text.Json.Serialization;

namespace WeChat.Mp.Response
{
    /// <summary>
    /// 获取临时素材
    /// </summary>
    public class WeChatMediaGetResponse : WeChatResponse
    {
        /// <summary>
        /// 内容类型
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// 视频格式时有值
        /// </summary>
        [JsonPropertyName("video_url")]
        public string VideoUrl { get; set; }
    }
}
