using Itmo.ObjectOrientedProgramming.Lab3.Priorities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messages;

public record Message(string Body, string Name, Priority Priority);