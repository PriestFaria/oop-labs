using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Constants;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers;

public class RenameCommandHandler : BaseCommandHandler
{
    private readonly CommandContext _context;

    public RenameCommandHandler(CommandContext context)
    {
        _context = context;
    }

    public override ICommand Handle(string[] arguments)
    {
        if (arguments[1] != CommandConstants.RenameCommandString)
        {
            if (NextHandler == null)
            {
                throw new InvalidOperationException(CommandConstants.NoHandlerExceptionInnerString);
            }

            return NextHandler.Handle(arguments);
        }

        if (arguments.Length != 4)
        {
            throw new ArgumentException("Invalid arguments for rename command");
        }

        string path = arguments[2];
        string newName = arguments[3];
        var renameCommand = new RenameCommand(new FileEntity(path), newName, _context);

        return renameCommand;
    }
}