namespace domain.auction;

public class PickUpTimeInterval
{
    public TimeSpan Min { get; set; }
    public TimeSpan Max { get; set; }

    public PickUpTimeInterval(string min, string max)
    {
        Min = TimeSpan.Parse(min);
        Max = TimeSpan.Parse(max);
    }
}