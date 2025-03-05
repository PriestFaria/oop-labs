using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.ResultTypes;

public class FilterResult
{
    public Message? Value { get; }

    public FilterResult(Message? value)
    {
        Value = value;
    }

    public class Success : FilterResult
    {
        public Success(Message? value) : base(value) { }
    }

    public class Reject : FilterResult
    {
        public Reject(Message? value) : base(value) { }
    }

    public class MessageDoesNotExist : FilterResult
    {
        public MessageDoesNotExist(Message? value) : base(value) { }
    }
}