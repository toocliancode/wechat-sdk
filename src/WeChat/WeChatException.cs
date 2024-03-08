namespace WeChat;

public class WeChatException : Exception
{
    public WeChatException()
    {
    }

    public WeChatException(string? message) : base(message)
    {
    }

    public WeChatException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}