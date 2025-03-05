using Itmo.ObjectOrientedProgramming.Lab1.Segment;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Route
{
    public IReadOnlyList<ISegment> Segments { get; private set; }

    public float TotalTime { get; private set; }

    public float MaxSpeed { get; private set; }

    public bool Success { get; private set; }

    public bool MoveTrainOnSegment(ISegment segment, Train train)
    {
        segment.Move(train);
        TotalTime += segment.Time;
        return segment.Success;
    }

    public bool MoveAllSegments(Train train)
    {
        foreach (ISegment segment in Segments)
        {
            MoveTrainOnSegment(segment, train);
            if (!segment.Success)
            {
                return false;
            }
        }

        if (train.Speed > MaxSpeed)
        {
            return false;
        }

        return true;
    }

    public void Simulate(Train train)
    {
        Success = MoveAllSegments(train);
    }

    public Route(IReadOnlyList<ISegment> segments, float maxSpeed)
    {
        if (maxSpeed < 0)
            throw new ArgumentException("Max Speed cannot be negative");

        Segments = segments;
        Success = false;
        MaxSpeed = maxSpeed;
    }
}