using System.Threading.Tasks;
using System.Net.Http;

namespace WeChat.Pay
{
    public interface IWeChatPayResponseSignatureChecker
    {
        Task Check(HttpResponseMessage message,WeChatPaySettings settings);
    }
}
