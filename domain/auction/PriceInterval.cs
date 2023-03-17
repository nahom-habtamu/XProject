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

    public override bool Equals(object? obj)
    {
        if (obj == null)
            return false;

        if (ReferenceEquals(obj, this))
            return false;

        if (obj.GetType() != this.GetType())
            return false;

        var parsed = obj as PriceInterval;

        if (
            this.Min.Equals(parsed?.Min) &&
            this.Max.Equals(parsed.Max)
        )
        {
            return true;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return (this.Max.ToString() + this.Min.ToString()).GetHashCode();
    }
}
