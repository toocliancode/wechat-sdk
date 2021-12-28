using Mediator.HttpClient;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

using System.Text.Json;
using System.Text.Json.Serialization;

namespace WeChat;

public abstract class WeChatHttpRequestBase<TWeChatResponse>
    : HttpRequestBase<TWeChatResponse>
    where TWeChatResponse : WeChatResponseBase
{
    protected readonly static JsonSerializerOptions SerializerOptions = new()
    {
        Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        PropertyNameCaseInsensitive = true
    };
    private readonly WeChatConfiguration _configuration;
    public WeChatHttpRequestBase()
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

    public override HttpClient CreateClient(IHttpClientCreateContext context) => context.HttpClientFactory.CreateClient(Configuration.Name);

    public override async Task<TWeChatResponse> Response(IHttpResponseContext context)
    {
        var content = await context.Message.Content.ReadAsByteArrayAsync();
        TWeChatResponse response = null;

        try
        {
            response = JsonSerializer.Deserialize<TWeChatResponse>(content, SerializerOptions);
        }
        catch { }

        if (response == null)
        {
            response = Activator.CreateInstance<TWeChatResponse>();
        }
        response.Raw = content;
        response.StatusCode = context.Message.StatusCode;
        return response;
    }

    public override async Task Request(IHttpRequestContext context)
    {
        var options = context.RequestServices.GetRequiredService<IOptions<WeChatOptions>>().Value;

        if (string.IsNullOrWhiteSpace(Configuration.AppId))
        {
            var configuration = options.GetConfiguration(Configuration.Name);
            Configuration.Configure(configuration.AppId, configuration.Secret);
        }

        var endpoint = options.GetEndpoint(EndpointName);
        var auth = new WeChatDictionary();

        if ((this) is IEnableAccessToken)
        {
            var token = await context.RequestServices.GetRequiredService<IWeChatAccessTokenStore>().GetAsync(Configuration.AppId, Configuration.Secret);
            auth["access_token"] = token;
        }

        //if((this) is IEnableJsapiTicket)
        //{
        //    var ticket = await context.RequestServices.GetRequiredService<IWeChatJsapiTicketStore>().GetAsync(Configuration.AppId, Configuration.Secret);
        //    auth["jsapi_ticket"] = ticket;
        //}

        if (Method.Equals(HttpMethod.Get))
        {
            var body = ToDictionary();
            body.AddRange(auth);
            endpoint = $"{endpoint}?{HttpUtility.ToQuery(body)}";
        }
        else
        {
            endpoint = $"{endpoint}?{HttpUtility.ToQuery(auth)}";
            context.Message.Content = new StringContent(ToSerialize());
        }

        context.Message.Method = Method;
        context.Message.RequestUri = new Uri(endpoint);
    }

    [JsonIgnore]
    protected virtual HttpMethod Method => HttpMethod.Get;

    /// <summary>
    /// 端点名称
    /// </summary>
    [JsonIgnore]
    protected abstract string EndpointName { get; }

    public virtual WeChatDictionary ToDictionary()
    {
        var dictionary = new WeChatDictionary();
        using var document = JsonDocument.Parse(ToSerialize());

        foreach (var jsonProperty in document.RootElement.EnumerateObject())
        {
            dictionary.Add(jsonProperty.Name, jsonProperty.Value.ValueKind == JsonValueKind.Null ? null : jsonProperty.Value.ToString());
        }

        return dictionary;
    }

    public virtual string ToSerialize()
    {
        return JsonSerializer.Serialize((object)this, SerializerOptions);
    }
}