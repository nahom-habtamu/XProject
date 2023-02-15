namespace domain.auction;

public class PriceInterval
{
    public double Min { get; set; }
    public double Max { get; set; }

    public PriceInterval(double min, double max)
    {
        if (min <= 0 || max <= 0)
        {
            throw new InvalidDataException();
        }
        Min = min;
        Max = max;
    }

}
