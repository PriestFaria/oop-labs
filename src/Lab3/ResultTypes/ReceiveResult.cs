namespace Itmo.ObjectOrientedProgramming.Lab3.ResultTypes;

public abstract record ReceiveResult
{
    public abstract string Text { get; }

    public sealed record Success : ReceiveResult
    {
        public override string Text => "Success";
    }

    public sealed record NullMessageReceived : ReceiveResult
    {
        public override string Text => "Null message received";
    }

    public sealed record RejectedByFilter : ReceiveResult
    {
        public override string Text => "Rejected by filter";
    }

    public sealed record Failed(string Reason) : ReceiveResult
    {
        public override string Text => $"Failed: {Reason}";
    }
}