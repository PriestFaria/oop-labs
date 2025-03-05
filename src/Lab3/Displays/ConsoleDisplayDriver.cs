using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public class ConsoleDisplayDriver : IDisplayDriver
{
    public void Clear()
    {
        Console.Clear();
    }

    public Color Color { get; }

    public void Print(string text)
    {
        Console.WriteLine(Crayon.Output.Rgb(Color.R, Color.G, Color.B).Text(text));
    }

    public ConsoleDisplayDriver(Color color)
    {
        Color = color;
    }
}