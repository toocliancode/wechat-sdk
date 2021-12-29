namespace WeChat;

/// <summary>
/// 需要Jsapi ticket
/// </summary>
public interface IHasJsapiTicket
{
    /// <summary>
    /// jsapi ticket，不填自动获取
    /// </summary>
    string? JsapiTicket { get; set; }
}
