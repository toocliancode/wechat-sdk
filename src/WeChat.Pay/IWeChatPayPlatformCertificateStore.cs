using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace WeChat.Pay
{
    public interface IWeChatPayPlatformCertificateStore
    {
        Task<X509Certificate2> GetAsync(string serialNo, WeChatPaySettings settings);
    }
}
