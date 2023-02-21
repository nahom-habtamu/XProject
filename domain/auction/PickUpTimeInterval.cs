namespace domain.auction;

public class PickUpTimeInterval
{
    public TimeSpan Min { get; set; }
    public TimeSpan Max { get; set; }

    public PickUpTimeInterval(TimeSpan min, TimeSpan max)
    {
        Min = min;
        Max = max;
    }
}