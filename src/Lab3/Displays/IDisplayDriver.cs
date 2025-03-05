using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public interface IDisplayDriver
{
    void Clear();

    Color Color { get; }

    void Print(string text);
}