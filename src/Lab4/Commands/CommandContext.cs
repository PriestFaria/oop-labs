using Itmo.ObjectOrientedProgramming.Lab4.Services;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class CommandContext
{
    private IFileSystem? _currentFileSystem;

    public void SetFileSystem(IFileSystem system)
    {
        _currentFileSystem = system;
    }

    public IFileSystem GetCurrentFileSystem()
    {
        if (_currentFileSystem == null)
        {
            throw new InvalidOperationException("File system must be set in context");
        }

        return _currentFileSystem;
    }
}