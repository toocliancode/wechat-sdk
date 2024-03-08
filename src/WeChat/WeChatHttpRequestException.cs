using System.Net;

namespace WeChat;

public class WeChatHttpRequestException : HttpRequestException
{
    public WeChatHttpRequestException()
    {
    }

    public WeChatHttpRequestException(string? message) : base(message)
    {
    }

    public WeChatHttpRequestException(string? message, Exception? inner) : base(message, inner)
    {
    }

    public WeChatHttpRequestException(string? message, Exception? inner, HttpStatusCode? statusCode) : base(message, inner, statusCode)
    {
    }

    public WeChatHttpRequestException(HttpRequestError httpRequestError, string? message = null, Exception? inner = null, HttpStatusCode? statusCode = null) : base(httpRequestError, message, inner, statusCode)
    {
    }
}
