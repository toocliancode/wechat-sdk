# WeChat-Sdk

WeChat-Sdk 是微信接口的请求封装，涵盖公众号、小程序及支付接口，主要用于日常业务方便而编写，所以只实现了一些需要的接口。

> 郑重声明：拒绝白嫖，如果有对你有帮助请至少点亮`星星`

### 使用方式

#### 设置NuGet源（NuGet.config）

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

#### 使用

```csharp
// 1.服务注册
var services = new ServiceCollection();

// 1.1 添加必要的Medation服务
services.AddMedation()
    .AddHttpClient();

// 1.2 注册微信相关的一些必要服务
services.AddWeChat()
    // .WithPay() // 用到支付接口须添加此项配置
    ;

var serviceProvider = services.BuildServiceProvider();

// 2.使用
var sender = serviceProvider.GetRequiredService<ISender>();

// 2.1 获取 access_token
var accessTokenRequest = WeChatAccessTokenRequest();

// 设置微信应用号和密钥
accessTokenRequest.Configure(options=>
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

### 实现接口

#### WeChat

| 请求类                      | 名称                                                                                                                                      | 更新日期      | 说明  |
|:------------------------ |:--------------------------------------------------------------------------------------------------------------------------------------- | --------- | --- |
| WeChatAccessTokenRequest | 微信请求接口凭证获取 [[文档](https://developers.weixin.qq.com/doc/offiaccount/Basic_Information/Get_access_token.html)]                             | 2022年1月1日 |     |
| WeChatDecryptRequest<>   | 微信开放数据解密                                                                                                                                | 2022年1月1日 |     |
| WeChatTicketRequest      | 微信票据获取 [[文档](https://developers.weixin.qq.com/doc/offiaccount/WeChat_Invoice/Nontax_Bill/API_list.html#2.1%20%E8%8E%B7%E5%8F%96ticket)] | 2022年1月1日 |     |

#### WeChat.Applet（小程序）

| 请求类                                     | 名称                                                                                                                                | 名称2                   | 更新日期 | 说明  |
|:--------------------------------------- |:--------------------------------------------------------------------------------------------------------------------------------- | --------------------- | ---- | --- |
| WeChatAppletCode2SessionRequest         | 登录凭证校验 [[文档](https://developers.weixin.qq.com/miniprogram/dev/api-backend/open-api/login/auth.code2Session.html)]                 | auth.code2Session     |      |     |
| WeChatAppletSubscribeMessageSendRequest | 发送订阅消息 [[文档](https://developers.weixin.qq.com/miniprogram/dev/api-backend/open-api/subscribe-message/subscribeMessage.send.html)] | subscribeMessage.send |      |     |
| WeChatAppletCreateWxaQrCodeRequest      | 创建小程序二维码 [[文档](https://developers.weixin.qq.com/miniprogram/dev/api-backend/open-api/qr-code/wxacode.createQRCode.html)]          | wxacode.createQRCode  |      |     |
| WeChatAppletGetWxaCodeRequest           | 获取小程序码 [[文档](https://developers.weixin.qq.com/miniprogram/dev/api-backend/open-api/qr-code/wxacode.get.html)]                     | wxacode.get           |      |     |
| WeChatAppletGetWxaCodeUnlimitRequest    | 获取小程序码 [[文档](https://developers.weixin.qq.com/miniprogram/dev/api-backend/open-api/qr-code/wxacode.getUnlimited.html)]            | wxacode.getUnlimited  |      |     |
| WeChatAppletGenerateSchemeRequest       | 获取小程序 scheme 码 [[文档](https://developers.weixin.qq.com/miniprogram/dev/api-backend/open-api/url-scheme/urlscheme.generate.html)]   | urlscheme.generate    |      |     |
| WeChatAppletGenerateUrlLinkRequest      | 获取小程序 URL Link [[文档](https://developers.weixin.qq.com/miniprogram/dev/api-backend/open-api/url-link/urllink.generate.html)]       | urllink.generate      |      |     |
| WeChatAppletQuerySchemeRequest          | 查询小程序 scheme 码 [[文档](https://developers.weixin.qq.com/miniprogram/dev/api-backend/open-api/url-scheme/urlscheme.query.html)]      | urlscheme.query       |      |     |
| WeChatAppletQueryUrlLinkRequest         | 查询小程序 url_link 配置 [[文档](https://developers.weixin.qq.com/miniprogram/dev/api-backend/open-api/url-link/urllink.query.html)]       | urllink.query         |      |     |

#### WeChat.Mp（公众号）

##### 微信卡券

| 请求类                                        | 名称                                                                                                                           | 更新日期 | 说明  |
|:------------------------------------------ |:---------------------------------------------------------------------------------------------------------------------------- | ---- | --- |
| WeChatMpCardBatchGetRequest                | 批量查询卡券Id [[文档](https://developers.weixin.qq.com/doc/offiaccount/Cards_and_Offer/Managing_Coupons_Vouchers_and_Cards.html#3)] |      |     |
| ==>【Code】<==                               |                                                                                                                              |      |     |
| WeChatMpCardCodeCheckRequest               | 核查code                                                                                                                       |      |     |
| WeChatMpCardCodeConsumeRequest             | 核销Code                                                                                                                       |      |     |
| WeChatMpCardCodeDecryptRequest             | 加密Code解码                                                                                                                     |      |     |
| WeChatMpCardCodeDepositRequest             | 导入code                                                                                                                       |      |     |
| WeChatMpCardCodeGetRequest                 | 查询Code                                                                                                                       |      |     |
| WeChatMpCardCodeGetDepositCountRequest     | 查询导入code数目                                                                                                                   |      |     |
| WeChatMpCardCodeUnavailableRequest         | 设置卡券失效                                                                                                                       |      |     |
| WeChatMpCardCodeUpdateRequest              | 更改Code                                                                                                                       |      |     |
|                                            |                                                                                                                              |      |     |
| WeChatMpCardCreateRequest                  | 创建卡券                                                                                                                         |      |     |
| WeChatMpDataCubeGetCardBizuiInfoRequest    | 拉取卡券概况数据                                                                                                                     |      |     |
| WeChatMpDataCubeGetCardInfoRequest         | 获取免费券数据                                                                                                                      |      |     |
| WeChatMpDataCubeGetMemberCardDetailRequest | 拉取单张会员卡数据                                                                                                                    |      |     |
| WeChatMpDataCubeGetMemberCardsInfoRequest  | 拉取会员卡概况数据                                                                                                                    |      |     |
| WeChatMpCardDeleteRequest                  | 删除卡券                                                                                                                         |      |     |
| WeChatMpCardGetRequest                     | 获取卡券详情                                                                                                                       |      |     |
| ==>【礼品卡】<==                                |                                                                                                                              |      |     |
| WeChatMpCardMaintainSetRequest             | 下架礼品卡货架                                                                                                                      |      |     |
| WeChatMpCardGiftPageAddRequest             | 创建礼品卡货架                                                                                                                      |      |     |
| WeChatMpCardGiftPageBatchGetRequest        | 查询礼品卡货架列表                                                                                                                    |      |     |
| WeChatMpCardGiftPageUpdateRequest          | 修改礼品卡货架信息                                                                                                                    |      |     |
|                                            |                                                                                                                              |      |     |
| WeChatMpCardLandingPageRequest             | 创建货架                                                                                                                         |      |     |
| WeChatMpCardModifyStockRequest             | 修改库存                                                                                                                         |      |     |
| WeChatMpCardMpNewsGetHtmlRequest           | 图文消息群发卡券内容                                                                                                                   |      |     |
| WeChatMpCardPayCellSetRequest              | 卡券设置买单                                                                                                                       |      |     |
| WeChatMpCardQrcodeCreateRequest            | 创建二维码                                                                                                                        |      |     |
| WeChatMpCardSelfConsumeCellSetRequest      | 设置自助核销                                                                                                                       |      |     |
| WeChatMpCardUpdateRequest                  | 更改卡券信息                                                                                                                       |      |     |
| WeChatMpCardUserGetCardListRequest         | 获取用户已领取卡券                                                                                                                    |      |     |

##### 素材管理

| 请求类                           | 名称              | 更新日期 | 说明  |
|:----------------------------- |:--------------- | ---- | --- |
| WeChatMpMediaGetRequest       | 获取临时素材          |      |     |
| WeChatMpMediaUploadImgRequest | 上传图文消息内的图片获取URL |      |     |

##### 基础消息能力

| 请求类                         | 名称     | 更新日期 | 说明  |
|:--------------------------- |:------ | ---- | --- |
| WeChatMpTemplateSendRequest | 发送模板消息 |      |     |

##### 微信门店

| 请求类                        | 名称       | 更新日期 | 说明  |
|:-------------------------- |:-------- | ---- | --- |
| WeChatMpPoiAddRequest      | 创建门店     |      |     |
| WeChatMpPoiDeleteRequest   | 删除门店     |      |     |
| WeChatMpPoiGetRequest      | 查询门店信息   |      |     |
| WeChatMpPoiCategoryRequest | 获取门店类目   |      |     |
| WeChatMpPoiGetListRequest  | 查询门店列表   |      |     |
| WeChatMpPoiUpdateRequest   | 修改门店服务信息 |      |     |

### WeChat.Pay（微信支付）

#### 商户版

| 请求类                                         | 名称                  | 更新日期 | 说明  |
|:------------------------------------------- |:------------------- | ---- | --- |
| WeChatPayTransactionsAppRequest             | App下单API            |      |     |
| WeChatPayAppSdkRequest                      | App调起支付API 参数获取     |      |     |
| WeChatPayCertificatesRequest                | 获取平台证书列表            |      |     |
| WeChatPayTransactionsOutTradeNoCloseRequest | 关单API               |      |     |
| WeChatPayTransactionsH5Request              | H5下单API             |      |     |
| WeChatPayTransactionsJsapiRequest           | JSAPI下单API          |      |     |
| WeChatPayJsapiSdkRequest                    | JSAPI调起支付API 参数获取   |      |     |
| WeChatPayTransactionsNativeRequest          | Native下单API         |      |     |
| WeChatPayTransactionsIdRequest              | 查询订单API - 微信支付订单号查询 |      |     |
| WeChatPayTransactionsOutTradeNoRequest      | 查询订单API - 商户订单号查询   |      |     |
| WeChatPayNotifyRequest<>                    | 微信支付通知请求            |      |     |
