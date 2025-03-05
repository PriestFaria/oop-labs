namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Train
{
    public float Mass { get; }

    public float Speed { get; private set; }

    public float Acceleration { get; private set; }

    public float MaxPower { get; private set; }

    public float Accuracy { get; }

    public Train(float mass, float maxPower, float accuracy)
    {
        if (mass < 0)
            throw new ArgumentException("Mass cannot be negative");

        if (accuracy <= 0)
            throw new ArgumentException("Accuracy cannot be less than or equal to zero");

        Mass = mass;
        MaxPower = maxPower;
        Accuracy = accuracy;
        Speed = 0;
        Acceleration = 0;
    }

    public void CalculateSpeed()
    {
        Speed += Acceleration * Accuracy;
    }

    public void ApplicatePower(float power)
    {
        Acceleration = power / Mass;
    }

    public void ResetAcceleration()
    {
        Acceleration = 0;
    }
}