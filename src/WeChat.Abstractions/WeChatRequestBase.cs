
using Mediator;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

using System;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WeChat
{
    [OnHandler(typeof(IWeChatRequestHandler<,>))]
    public abstract class WeChatRequestBase<TWeChatResponse> : IRequest<TWeChatResponse>
    {
        private readonly WeChatConfiguration _configuration;

        protected WeChatRequestBase()
        {
            _configuration = new();
        }

        /// <summary>
        /// 微信配置
        /// </summary>
        [JsonIgnore]
        protected virtual WeChatConfiguration Configuration => _configuration;

        /// <summary>
        /// 设置主要参数
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        public virtual WeChatConfiguration Configure(IWeChatSettings settings) => Configuration.Configure(settings);

        public virtual WeChatConfiguration Configure(string appId, string secret) => Configuration.Configure(appId, secret);

        public abstract Task<TWeChatResponse> Handler(IWeChatRequetHandleContext context);
    }
}
