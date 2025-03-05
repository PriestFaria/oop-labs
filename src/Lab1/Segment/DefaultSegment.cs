namespace Itmo.ObjectOrientedProgramming.Lab1.Segment;

public class DefaultSegment : ISegment
{
    public bool Success { get; private set; }

    public float Time { get; private set; }

    private float RemainingDistance { get; set; }

    public void Move(Train train)
    {
        while (RemainingDistance > 0)
        {
            train.CalculateSpeed();
            float traveledDistance = train.Speed * train.Accuracy;

            Time += train.Accuracy;
            RemainingDistance -= traveledDistance;

            if (train.Speed < 0 || (train.Speed == 0 && train.Acceleration == 0))
            {
                Success = false;
                return;
            }
        }

        Success = true;
    }

    public DefaultSegment(float distance)
    {
        if (distance < 0)
            throw new ArgumentException("Distance cannot be negative");

        RemainingDistance = distance;
    }
}