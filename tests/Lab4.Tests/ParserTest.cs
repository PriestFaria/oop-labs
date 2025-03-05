using Itmo.ObjectOrientedProgramming.Lab4;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Xunit;

namespace Lab4.Tests;

public class ParserTest
{
    private static ConnectCommand GetConfiguredConnectCommand(string address, string mode)
    {
        var context = new CommandContext();
        var connectCommand = new ConnectCommand(address, mode, context);
        return connectCommand;
    }

    private static GotoCommand GetConfiguredGotoCommand(string address)
    {
        var context = new CommandContext();
        context.SetFileSystem(new LocalFileSystem("/"));
        var gotoCommand = new GotoCommand(new DirectoryEntity(address), context);
        return gotoCommand;
    }

    private static DisconnectCommand GetConfiguredDisconnectCommand()
    {
        var context = new CommandContext();
        context.SetFileSystem(new LocalFileSystem("/"));
        var disconnectCommand = new DisconnectCommand(context);
        return disconnectCommand;
    }

    private static ListCommand GetConfiguredListCommand(string address, int depth)
    {
        var context = new CommandContext();
        context.SetFileSystem(new LocalFileSystem("/"));
        var listCommand = new ListCommand(new DirectoryEntity(address), context, depth);
        return listCommand;
    }

    private static ShowCommand GetConfiguredShowCommand(string address, string mode)
    {
        var context = new CommandContext();
        context.SetFileSystem(new LocalFileSystem("/"));
        var showCommand = new ShowCommand(new FileEntity(address), mode, context);
        return showCommand;
    }

    private static MoveCommand GetConfiguredMoveCommand(string source, string destination)
    {
        var context = new CommandContext();
        context.SetFileSystem(new LocalFileSystem("/"));
        var moveCommand = new MoveCommand(new FileEntity(source), new DirectoryEntity(destination), context);
        return moveCommand;
    }

    private static CopyCommand GetConfiguredCopyCommand(string source, string destination)
    {
        var context = new CommandContext();
        context.SetFileSystem(new LocalFileSystem("/"));
        var copyCommand = new CopyCommand(
            new FileEntity(source),
            new DirectoryEntity(destination),
            context);
        return copyCommand;
    }

    private static DeleteCommand GetConfiguredDeleteCommand(string source)
    {
        var context = new CommandContext();
        context.SetFileSystem(new LocalFileSystem("/"));
        var deleteCommand = new DeleteCommand(new FileEntity(source), context);
        return deleteCommand;
    }

    private static RenameCommand GetConfiguredRenameCommand(string source, string newName)
    {
        var context = new CommandContext();
        context.SetFileSystem(new LocalFileSystem("/"));
        var renameCommand = new RenameCommand(new FileEntity(source), newName, context);
        return renameCommand;
    }

    public static IEnumerable<object[]> Commands => new List<object[]>
    {
        new object[]
        {
            "tree goto /Users/priest_faria/Desktop/testingLab4/gotoTest",
            GetConfiguredGotoCommand("/Users/priest_faria/Desktop/testingLab4/gotoTest"),
        },
        new object[]
        {
            "tree list -d 2",
            GetConfiguredListCommand("/", 2),
        },
        new object[]
        {
            "file show /Users/priest_faria/Desktop/testingLab4/aboba.txt -m console",
            GetConfiguredShowCommand("/Users/priest_faria/Desktop/testingLab4/aboba.txt", "console"),
        },
        new object[]
        {
            "file move /Users/priest_faria/Desktop/testingLab4/aboba.txt /Users/priest_faria/Desktop/testingLab4/gotoTest",
            GetConfiguredMoveCommand(
                "/Users/priest_faria/Desktop/testingLab4/aboba.txt",
                "/Users/priest_faria/Desktop/testingLab4/gotoTest"),
        },
        new object[]
        {
            "file copy /Users/priest_faria/Desktop/testingLab4/aboba.txt /Users/priest_faria/Desktop/testingLab4/gotoTest",
            GetConfiguredCopyCommand(
                "/Users/priest_faria/Desktop/testingLab4/aboba.txt",
                "/Users/priest_faria/Desktop/testingLab4/gotoTest"),
        },
        new object[]
        {
            "file delete /Users/priest_faria/Desktop/testingLab4/aboba.txt",
            GetConfiguredDeleteCommand("/Users/priest_faria/Desktop/testingLab4/aboba.txt"),
        },
        new object[]
        {
            "file rename /Users/priest_faria/Desktop/testingLab4/aboba.txt boba.txt",
            GetConfiguredRenameCommand("/Users/priest_faria/Desktop/testingLab4/aboba.txt", "boba.txt"),
        },
        new object[]
        {
            "tree list -d 2",
            GetConfiguredListCommand("/", 2),
        },
        new object[]
        {
            "connect /Users/priest_faria/Desktop/testingLab4 -m local",
            GetConfiguredConnectCommand("/Users/priest_faria/Desktop/testingLab4", "local"),
        },
        new object[]
        {
            "disconnect",
            GetConfiguredDisconnectCommand(),
        },
    };

    [Theory]
    [MemberData(nameof(Commands))]
    public void TestCommands(string input, ICommand command)
    {
        var parser = new ParserMockContext();
        parser.Parse(input);
        parser.BuildLocalChain();
        ICommand parsedCommand = parser.Handle();

        Assert.True(command.Equals(parsedCommand));
    }
}