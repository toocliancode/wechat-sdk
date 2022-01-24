﻿namespace WeChat;

public class WeChatRequestHandler<TWeChatRequet, TWeChatResponse>
    : IWeChatRequestHandler<TWeChatRequet, TWeChatResponse>
    where TWeChatRequet : WeChatRequestBase<TWeChatResponse>
{
    private readonly IServiceProvider _serviceProvider;

    public WeChatRequestHandler(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public Task<TWeChatResponse> Handle(TWeChatRequet request, CancellationToken cancellationToken)
    {
        return request.Handle(new WeChatRequetHandleContext(_serviceProvider));
    }
}
