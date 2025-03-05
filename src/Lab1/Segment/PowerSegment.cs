namespace Itmo.ObjectOrientedProgramming.Lab1.Segment;

public class PowerSegment : ISegment
{
    public bool Success { get; private set; }

    public float Time { get; private set; }

    private float RemainingDistance { get; set; }

    private float Power { get; }

    public void Move(Train train)
    {
        if (float.Abs(Power) > train.MaxPower)
        {
            Success = false;
            return;
        }

        bool slowedDown = false;
        train.ApplicatePower(Power);

        while (RemainingDistance > 0)
        {
            train.CalculateSpeed();
            float traveledDistance = train.Speed * train.Accuracy;

            Time += train.Accuracy;
            RemainingDistance -= traveledDistance;

            if (train.Speed < 0 || (train.Speed <= 0 && train.Acceleration <= 0))
            {
                Success = false;
                slowedDown = true;
                break;
            }
        }

        if (!slowedDown)
        {
            train.ResetAcceleration();
            Success = true;
        }
    }

    public PowerSegment(float power, float distance)
    {
        if (distance < 0)
            throw new ArgumentException("Distance cannot be negative");

        Power = power;
        RemainingDistance = distance;
    }
}