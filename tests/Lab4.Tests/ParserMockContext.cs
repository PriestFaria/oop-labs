using Itmo.ObjectOrientedProgramming.Lab4;
using Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers;

namespace Lab4.Tests;

public class ParserMockContext : ICommandParser
{
    private BaseCommandHandler? _rootHandler;

    private string[]? _parts;

    public CommandContext Context { get; } = new CommandContext();

    public ParserMockContext()
    {
        Context.SetFileSystem(new LocalFileSystem("/"));
    }

    public void Parse(string? input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            throw new ArgumentException("Input cannot be empty.");
        }

        string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length == 0)
        {
            throw new ArgumentException("Invalid command input.");
        }

        _parts = parts;
    }

    public ICommand Handle()
    {
        if (_parts == null)
        {
            throw new ArgumentException("Arguments must be parsed set before handling");
        }

        if (_rootHandler == null)
        {
            throw new ArgumentException("Handlers must be set");
        }

        return _rootHandler.Handle(_parts);
    }

    public void BuildLocalChain()
    {
        var showCommandHandler = new ShowCommandHandler(Context);
        var copyCommandHandler = new CopyCommandHandler(Context);
        var renameCommandHandler = new RenameCommandHandler(Context);
        var moveCommandHandler = new MoveCommandHandler(Context);
        var deleteCommandHandler = new DeleteCommandHandler(Context);
        var disconnectCommandHandler = new DisconnectCommandHandler(Context);
        var gotoCommandHandler = new GotoCommandHandler(Context);
        var listCommandHandler = new ListCommandHandler(Context);
        var connectCommandHandler = new ConnectCommandHandler(Context);

        connectCommandHandler.BindNextHandler(disconnectCommandHandler);
        disconnectCommandHandler.BindNextHandler(deleteCommandHandler);
        deleteCommandHandler.BindNextHandler(moveCommandHandler);
        moveCommandHandler.BindNextHandler(renameCommandHandler);
        renameCommandHandler.BindNextHandler(copyCommandHandler);
        copyCommandHandler.BindNextHandler(showCommandHandler);
        showCommandHandler.BindNextHandler(listCommandHandler);
        listCommandHandler.BindNextHandler(gotoCommandHandler);

        _rootHandler = connectCommandHandler;
    }
}