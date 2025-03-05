namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class DeleteCommand : ICommand, IEquatable<ICommand>
{
    public CommandContext Context { get; private set; }

    public FileEntity File { get; private set; }

    public DeleteCommand(FileEntity file, CommandContext context)
    {
        Context = context;
        File = file;
    }

    public void Execute()
    {
        Context.GetCurrentFileSystem().Delete(File);
    }

    public bool Equals(ICommand? other)
    {
        if (other is DeleteCommand otherCommand)
        {
            return Equals(File, otherCommand.File);
        }

        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(File);
    }

    public override bool Equals(object? obj)
    {
        if (obj is DeleteCommand otherCommand)
        {
            return Equals(otherCommand);
        }

        return false;
    }
}