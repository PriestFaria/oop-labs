using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Constants;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers;

public class ShowCommandHandler : BaseCommandHandler
{
    private readonly CommandContext _context;

    public ShowCommandHandler(CommandContext context)
    {
        _context = context;
    }

    public override ICommand Handle(string[] arguments)
    {
        if (arguments[1] != CommandConstants.ShowCommandString)
        {
            if (NextHandler == null)
            {
                throw new InvalidOperationException(CommandConstants.NoHandlerExceptionInnerString);
            }

            return NextHandler.Handle(arguments);
        }

        if (arguments.Length != 5)
        {
            throw new ArgumentException("Invalid arguments for show command");
        }

        string path = arguments[2];
        string mode = arguments[4];
        var showCommand = new ShowCommand(new FileEntity(path), mode, _context);
        return showCommand;
    }
}