using System.Net.Http;
using System.Threading.Tasks;

namespace WeChat.Pay
{
    public interface IWeChatPayAuthorizationHandler
    {
        Task Handler(HttpRequestMessage message, WeChatPaySettings settings);
    }
}
