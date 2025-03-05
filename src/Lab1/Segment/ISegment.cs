namespace Itmo.ObjectOrientedProgramming.Lab1.Segment;

public interface ISegment
{
    public bool Success { get; }

    public float Time { get; }

    public void Move(Train train);
}