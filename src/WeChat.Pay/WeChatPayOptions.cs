using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace WeChat;

public class WeChatPayOptions
{
    /// <summary>
    /// 微信应用号
    /// </summary>
    public string AppId { get; set; }

    /// <summary>
    /// 微信应用密钥
    /// </summary>
    public string Secret { get; set; }

    /// <summary>
    /// 商户号
    /// </summary>
    public string MchId { get; set; }

    /// <summary>
    /// 子商户应用号
    /// 仅服务商使用
    /// </summary>
    public string SubAppId { get; set; }

    /// <summary>
    /// 子商户号
    /// 仅服务商使用
    /// </summary>
    public string SubMchId { get; set; }

    /// <summary>
    /// 默认的支付通知地址。如果未设置，则请求接口时必须传入
    /// </summary>
    public string? TransactionNotifyUrl { get; set; }

    /// <summary>
    /// 默认的退款通知地址
    /// </summary>
    public string? RefundNotifyUrl { get; set; }

    private string certificate;
    private string certificatePassword;

    /// <summary>
    /// API证书(.p12)
    /// 可为 证书文件路径 / 证书文件的Base64编码
    /// </summary>
    public string Certificate
    {
        get => certificate;
        set
        {
            if (!string.IsNullOrEmpty(value))
            {
                certificate = value;
                GetCertificateInfo();
            }
        }
    }

    /// <summary>
    /// API证书密码
    /// 默认为商户号
    /// </summary>
    public string CertificatePassword
    {
        get => string.IsNullOrEmpty(certificatePassword) ? MchId : certificatePassword;
        set
        {
            if (!string.IsNullOrEmpty(value))
            {
                certificatePassword = value;
                GetCertificateInfo();
            }
        }
    }

    /// <summary>
    /// API密钥
    /// </summary>
    public string Key { get; set; }

    /// <summary>
    /// APIv3密钥
    /// </summary>
    public string V3Key { get; set; }

    /// <summary>
    /// RSA公钥
    /// 目前仅调用"企业付款到银行卡API"时使用，执行"获取RSA加密公钥API"即可获取。
    /// </summary>
    public string RsaPublicKey { get; set; }

    ///// <summary>
    ///// RSA私钥
    ///// </summary>
    //public string RsaPrivateKey { get; set; }

    ///// <summary>
    ///// RSA 序列号
    ///// </summary>
    //public string RsaSerialNumber { get; set; }

    internal X509Certificate2 Certificate2;
    internal RSA CertificateRSAPrivateKey;
    internal string CertificateSerialNo;

    private void GetCertificateInfo()
    {
        if (string.IsNullOrEmpty(Certificate) || string.IsNullOrEmpty(CertificatePassword))
        {
            return;
        }

        try
        {
            if (File.Exists(Certificate))
            {
                Certificate2 = new X509Certificate2(Certificate, CertificatePassword);
            }
            else
            {
                Certificate2 = new X509Certificate2(Convert.FromBase64String(Certificate), CertificatePassword);
            }
        }
        catch (CryptographicException)
        {
            throw new CryptographicException("反序列化证书失败，请确认是否为微信支付签发的有效PKCS#12格式证书。");
        }

        CertificateSerialNo = Certificate2.GetSerialNumberString();
#pragma warning disable CS8601
        CertificateRSAPrivateKey = Certificate2.GetRSAPrivateKey();
#pragma warning restore CS8601
    }
}
