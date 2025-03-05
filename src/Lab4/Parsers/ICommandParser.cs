using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers;

public interface ICommandParser
{
    void Parse(string? input);

    ICommand Handle();
}