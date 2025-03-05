namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class RenameCommand : ICommand, IEquatable<ICommand>
{
    public CommandContext Context { get; }

    public FileEntity File { get; }

    public string NewName { get; }

    public RenameCommand(FileEntity file, string newName, CommandContext context)
    {
        File = file;
        Context = context;
        NewName = newName;
    }

    public void Execute()
    {
        Context.GetCurrentFileSystem().Rename(File, NewName);
    }

    public bool Equals(ICommand? other)
    {
        if (other is RenameCommand otherCommand)
        {
            return Equals(File, otherCommand.File) && Equals(NewName, otherCommand.NewName);
        }

        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(File, NewName);
    }

    public override bool Equals(object? obj)
    {
        if (obj is RenameCommand otherCommand)
        {
            return Equals(otherCommand);
        }

        return false;
    }
}