namespace Itmo.ObjectOrientedProgramming.Lab1.Segment;

public class Station : ISegment
{
    public bool Success { get; private set; }

    public float Time { get; private set; }

    public float CongestionFactor { get; }

    public float MaxSpeed { get; }

    public void Move(Train train)
    {
        if (train.Speed > MaxSpeed)
        {
            Success = false;
        }
        else
        {
            Time = CongestionFactor;
            Success = true;
        }
    }

    public Station(float congestionFactor, float maxSpeed)
    {
        if (congestionFactor < 0)
            throw new ArgumentException("Congestion Factor cannot be negative");

        if (maxSpeed < 0)
            throw new ArgumentException("Max Speed cannot be negative");

        CongestionFactor = congestionFactor;
        MaxSpeed = maxSpeed;
    }
}