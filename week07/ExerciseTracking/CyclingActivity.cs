public class CyclingActivity : Activity
{
    private double _speed; 

    public CyclingActivity(DateTime date, int lengthInMinutes, double speed)
        : base(date, lengthInMinutes)
    {
        _speed = speed;
    }

    public override double GetSpeed() => _speed;

    public override double GetDistance() => (_speed / 60) * LengthInMinutes;

    public override double GetPace() => 60 / _speed;
}