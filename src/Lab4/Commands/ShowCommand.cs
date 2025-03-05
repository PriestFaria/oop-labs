namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class ShowCommand : ICommand, IEquatable<ICommand>
{
    public CommandContext Context { get; }

    public FileEntity File { get; private set; }

    public string Mode { get; private set; }

    public ShowCommand(FileEntity file, string mode, CommandContext context)
    {
        File = file;
        Mode = mode;
        Context = context;
    }

    public void Execute()
    {
        Context.GetCurrentFileSystem().Show(File, Mode);
    }

    public bool Equals(ICommand? other)
    {
        if (other is ShowCommand otherCommand)
        {
            return Equals(File, otherCommand.File) && Equals(Mode, otherCommand.Mode);
        }

        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(File, Mode);
    }

    public override bool Equals(object? obj)
    {
        if (obj is ShowCommand otherCommand)
        {
            return Equals(otherCommand);
        }

        return false;
    }
}