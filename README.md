# WeChat-Sdk

微信接口请求封装

## 使用方式

```C#
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

// 2.1 获取access_token
var accessTokenRequest = WeChatAccessTokenRequest();

// 设置微信应用号和密钥
accessTokenRequest.Confiure(options=>
{
    options.AppId = "<appid>";
    options.Secret = "<secret>";
})
var accessTokenResponse = await sender.Send(accessTokenRequest);

if (!response.IsSucceed())
{
    var token = response.AccessToken;
}
```


