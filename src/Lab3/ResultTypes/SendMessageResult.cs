namespace Itmo.ObjectOrientedProgramming.Lab3.ResultTypes;

public abstract record SendMessageResult
{
    public abstract string Text { get; }

    private SendMessageResult() { }

    public sealed record Success : SendMessageResult
    {
        public override string Text => "Message sent successfully.";
    }

    public sealed record MessageDoesNotExist : SendMessageResult
    {
        public override string Text => "Message does not exist.";
    }

    public sealed record Failed(string Reason) : SendMessageResult
    {
        public override string Text => $"Failed to send message: {Reason}";
    }
}