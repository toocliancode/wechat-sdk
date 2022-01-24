namespace WeChat;

/// <summary>
/// 需要 card ticket
/// </summary>
public interface IHasCardTicket
{
    /// <summary>
    /// card ticket，不填自动获取
    /// </summary>
    string? CardTicket { get; set; }
}
