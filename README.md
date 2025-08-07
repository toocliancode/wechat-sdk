# WeChat-Sdk

WeChat-Sdk 是一个功能全面的微信接口封装库，提供了对微信公众号、小程序和支付接口的便捷访问。本库采用现代化的 .NET 开发方式，基于 Mediation 模式设计，具有以下特点：

- 模块化设计 ：公众号、小程序和支付功能各自独立，可按需使用
- 异步支持 ：全面支持异步编程模型
- 类型安全 ：所有接口参数和返回值均有强类型定义
- 易于集成 ：可轻松集成到 ASP.NET Core 或其他 .NET 项目中
- 缓存支持 ：内置 AccessToken 和 Ticket 缓存机制，提高性能

### 快速开始

#### 环境要求

- .NET Standard 2.0+ 或 .NET 5.0+

#### 设置 NuGet 源（NuGet.config）

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageSources>
    // ...
    <add key="toocliancode" value="https://www.myget.org/F/toocliancode/api/v3/index.json" />
  </packageSources>
</configuration>
```

#### 安装依赖

```cil
# 主要的依赖
dotnet add package WeChat

# 微信小程序
dotnet add package WeChat.Applet

# 微信公众号
dotnet add package WeChat.Mp

# 微信支付
dotnet add package WeChat.Pay
```

#### 使用示例

```csharp
// 1.服务注册
var services = new ServiceCollection();

// 1.1 添加必要的Mediation服务
services.AddMediation(config =>
{
  config.AddHttpClient();

  // 添加需要的服务配置
  config.AddWeChatMp();
  config.AddWeChatApplet();
  config.AddWeChatPay();
});

services.Configure<WeChatMpOptions>(options =>
{
  options.AppId = "";
  options.Secret = "";
});

services.Configure<WeChatAppletOptions>(options =>
{
  options.AppId = "";
  options.Secret = "";
});

services.Configure<WeChatPayOptions>(options =>
{
  options.AppId = "";
  options.Secret = "";
  options.MchId = "";
  options.TransactionNotifyUrl = ""; // 默认的支付通知地址。如果未设置，则请求接口时必须传入
  options.RefundNotifyUrl = ""; // 默认的退款通知地址
  options.Certificate = ""; // PI证书(.p12)。可为 证书文件路径 / 证书文件的Base64编码
  options.CertificatePassword = ""; // API证书密码。 默认为商户号
  options.V3Key = ""; // APIv3密钥
});

var serviceProvider = services.BuildServiceProvider();

// 2.使用
var sender = serviceProvider.GetRequiredService<ISender>();

// 2.1 获取 access_token
var accessTokenRequest = Mp.AccessToken.ToRequest("<appid>","<secret>");

var accessTokenResponse = await sender.Send(accessTokenRequest);

if (accessTokenResponse.IsSucceed())
{
    var token = accessTokenResponse.AccessToken;
}

// 内置 access_token 存储器使用
var accessTokenStore = serviceProvider.GetRequiredService<IWeChatMpAccessTokenStore>();
var token = await accessTokenStore.GetAsync();

// 内置 ticket 存储器使用
var ticketStore = serviceProvider.GetRequiredService<IWeChatMpTicketStore>();
var ticket= await ticketStore.GetAsync();

```

#### 微信公众号实现接口

- AccessToken
- JsapiConfig (微信公众号配置获取)
- MediaGet
- MediaUploadImg
- Ticket

#### 微信小程序实现接口

- AccessToken
- CheckSession
- Code2Session
- CreateQRCode
- GenerateNFCScheme
- GenerateScheme
- GenerateShortLink
- GenerateUrlLink
- GetPaidUnionid
- GetPhoneNumber
- GetQRCode
- GetUnlimitedQRCode
- QueryScheme
- QueryUrlLink
- ResetSession

#### 微信支付实现接口（基于 3.0 版本）

- PlatformCertificate
- Refunds
- TransactionsApp
- TransactionsAppSdk 客户端支付参数获取
- TransactionsClose
- TransactionsH5
- TransactionsJsapi
- TransactionsJsapiSdk 客户端支付参数获取
- TransactionsNative
- TransactionsQuery
- Notify< TransactionsNotifyResponse > 付款通知
- Notify< RefundNotifyResponse > 退款通知
