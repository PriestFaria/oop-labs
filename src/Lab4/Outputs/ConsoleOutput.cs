namespace Itmo.ObjectOrientedProgramming.Lab4.Outputs;

public class ConsoleOutput : IOutput
{
    public void Draw(string? text)
    {
        Console.Write(text);
    }
}