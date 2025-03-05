using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers;

public abstract class BaseCommandHandler
{
    public abstract ICommand Handle(string[] arguments);

    public BaseCommandHandler? NextHandler { get; private set; }

    public void BindNextHandler(BaseCommandHandler nextHandler)
    {
        NextHandler = nextHandler;
    }
}