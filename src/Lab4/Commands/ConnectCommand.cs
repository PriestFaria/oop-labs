using Itmo.ObjectOrientedProgramming.Lab4.Services;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class ConnectCommand : ICommand, IEquatable<ICommand>
{
    public IFileSystem? FileSystem { get; private set; }

    public CommandContext Context { get; }

    public string Address { get; }

    public string Mode { get; }

    public ConnectCommand(string address, string mode, CommandContext context)
    {
        Address = address;
        Mode = mode;
        Context = context;
    }

    public void Execute()
    {
        if (Mode == "local")
        {
            FileSystem = new LocalFileSystem(Address);
            FileSystem.Connect(Address);
            Context.SetFileSystem(FileSystem);
        }
    }

    public bool Equals(ICommand? other)
    {
        if (other is ConnectCommand otherCommand)
        {
            return Equals(Address, otherCommand.Address) && Equals(Mode, otherCommand.Mode);
        }

        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Address, Mode);
    }

    public override bool Equals(object? obj)
    {
        if (obj is ConnectCommand otherCommand)
        {
            return Equals(otherCommand);
        }

        return false;
    }
}