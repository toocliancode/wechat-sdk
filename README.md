# WeChat-Sdk

WeChat-Sdk 是微信接口的请求封装，主要用于日常业务方便而编写，所以只实现了一些需要的接口。

#### 使用方式

##### 设置NuGet源（NuGet.config）

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageSources>
    // ...
    <add key="toocliancode" value="https://www.myget.org/F/toocliancode/api/v3/index.json" />
  </packageSources>
</configuration>
```

##### 安装依赖

```cil
# 主要的依赖
dotnet add package WeChat
# 微信公众号
dotnet add package WeChat.Mp
# 微信小程序
dotnet add package WeChat.Applet
# 微信支付
dotnet add package WeChat.Pay
```

##### 使用

```csharp
// 1.服务注册
var services = new ServiceCollection();

// 1.1 添加必要的Medation服务
services.AddMedation()
    .AddHttpClient();

// 1.2 注册微信相关的一些必要服务
services.AddWeChat();

var serviceProvider = services.BuildServiceProvider();

// 2.使用
var sender = serviceProvider.GetRequiredService<ISender>();

// 2.1 获取 access_token
var accessTokenRequest = WeChatAccessTokenRequest();

// 设置微信应用号和密钥
accessTokenRequest.Confiure(options=>
{
    options.AppId = "<appid>";
    options.Secret = "<secret>";
})
var accessTokenResponse = await sender.Send(accessTokenRequest);

if (response.IsSucceed())
{
    var token = response.AccessToken;
}

// 内置 access_token 存储器使用
var accessTokenStore = serviceProvider.GetRequiredService<IWeChatAccessTokenStore>();
var token = await accessTokenStore.GetAsync("<appid>","<secret>");

// 内置 ticket 存储器使用
var ticketStore = serviceProvider.GetRequiredService<IWeChatTicketStore>();
var ticket= await ticketStore.GetAsync("<appid>","<secret>");
```




























