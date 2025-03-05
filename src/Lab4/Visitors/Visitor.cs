using Itmo.ObjectOrientedProgramming.Lab4.Outputs;

namespace Itmo.ObjectOrientedProgramming.Lab4.Visitors;

public class Visitor : IFileSystemComponentVisitor
{
    private readonly IOutput _driver;

    private int _depth;

    public void Visit(FileEntity component)
    {
        WriteIndented(component.Path.Split("/").Last());
    }

    public Visitor(IOutput? driver = null)
    {
        if (driver != null)
        {
            _driver = driver;
        }

        _driver = new ConsoleOutput();
    }

    public void Visit(DirectoryEntity component)
    {
        WriteIndented(component.Path.Split("/").Last());

        _depth += 1;

        foreach (IFileSystemEntity innerComponent in component.GetComponents())
        {
            innerComponent.Accept(this);
        }

        _depth -= 1;
    }

    private void WriteIndented(string value)
    {
        if (_depth is not 0)
        {
            _driver.Draw(string.Concat(Enumerable.Repeat("   ", _depth)));
            _driver.Draw("|–> ");
        }

        _driver.Draw(value);
    }
}