namespace WeChat.Mp.Card;

public class WeChatMpCardMaintainSetResponse
    : WeChatHttpResponse
{
    /// <summary>
    /// 控制结果
    /// </summary>
    [JsonPropertyName("control_info")]
    public ControlInfo Control { get; set; }

    public class ControlInfo
    {
        /// <summary>
        /// 商户控制的该appid下所有货架的状态
        /// </summary>
        [JsonPropertyName("biz_control_type")]
        public string BizControlType { get; set; }

        /// <summary>
        /// 商户控制的该appid下所有货架的状态
        /// </summary>
        [JsonPropertyName("system_biz_control_type")]
        public string SystemBizControlType { get; set; }

        /// <summary>
        /// Page列表的结构体，为商户下所有page列表
        /// </summary>
        [JsonPropertyName("list")]
        public List<ControlItem> Items { get; set; }
    }

    public class ControlItem
    {
        /// <summary>
        /// Page的唯一id
        /// </summary>
        [JsonPropertyName("page_id")]
        public string PageId { get; set; }

        [JsonPropertyName("page_control_type")]
        public string PageControlType { get; set; }

        /// <summary>
        /// 由系统控制的货架状态
        /// </summary>
        [JsonPropertyName("system_page_control_type")]
        public string SystemPageControlType { get; set; }
    }
}
