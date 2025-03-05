using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public class FileDisplayDriver : IDisplayDriver
{
    private readonly StreamWriter _file;

    public void Clear()
    {
        Print(string.Empty);
    }

    public Color Color { get; }

    public void Print(string text)
    {
        _file.WriteLine(text);
    }

    public FileDisplayDriver(StreamWriter file)
    {
        if (file.BaseStream == null)
        {
            throw new InvalidOperationException("File stream closed");
        }

        _file = file;
    }
}