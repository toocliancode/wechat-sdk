namespace WeChat.Mp.Poi;

public class PoiBusiness
{
    /// <summary>
    /// 门店基本信息
    /// </summary>
    [JsonPropertyName("base_info")]
    public PoiBaseInfo Info { get; set; }
}
