namespace WeChat;

public class WeChatRequetHandleContext : IWeChatRequetHandleContext
{
    public WeChatRequetHandleContext(IServiceProvider serviceProvider)
    {
        RequestServices = serviceProvider;
    }

    public IServiceProvider RequestServices { get; set; }
}
