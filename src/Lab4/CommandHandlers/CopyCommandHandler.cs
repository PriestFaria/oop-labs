using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Constants;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers;

public class CopyCommandHandler : BaseCommandHandler
{
    private readonly CommandContext _context;

    public CopyCommandHandler(CommandContext context)
    {
        _context = context;
    }

    public override ICommand Handle(string[] arguments)
    {
        if (arguments[1] != CommandConstants.CopyCommandString)
        {
            if (NextHandler == null)
            {
                throw new InvalidOperationException(CommandConstants.NoHandlerExceptionInnerString);
            }

            return NextHandler.Handle(arguments);
        }

        if (arguments.Length != 4)
        {
            throw new ArgumentException("Invalid arguments for copy command");
        }

        string sourcePath = arguments[2];
        string destinationPath = arguments[3];

        var copyCommand = new CopyCommand(new FileEntity(sourcePath), new DirectoryEntity(destinationPath), _context);

        return copyCommand;
    }
}