using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Constants;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers;

public class GotoCommandHandler : BaseCommandHandler
{
    private readonly CommandContext _context;

    public GotoCommandHandler(CommandContext context)
    {
        _context = context;
    }

    public override ICommand Handle(string[] arguments)
    {
        if (arguments[1] != CommandConstants.GotoCommandString)
        {
            if (NextHandler == null)
            {
                throw new InvalidOperationException(CommandConstants.NoHandlerExceptionInnerString);
            }

            return NextHandler.Handle(arguments);
        }

        if (arguments.Length != 3)
        {
            throw new ArgumentException("Invalid arguments for goto command");
        }

        string directoryPath = arguments[2];

        var gotoCommand = new GotoCommand(new DirectoryEntity(directoryPath), _context);
        return gotoCommand;
    }
}