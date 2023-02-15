using domain.auction;

namespace project_x_test.auction;

public class PriceIntervalTest
{
    [Fact]
    public void ThrowsInvalidDataExceptionWhenInitializingWithZeroValue()
    {
        Assert.Throws<InvalidDataException>(() => new PriceInterval(0, 0));
        Assert.Throws<InvalidDataException>(() => new PriceInterval(0, 1));
        Assert.Throws<InvalidDataException>(() => new PriceInterval(1, 0));
    }

    [Fact]
    public void IntializesSuccessfullyWhenInputsAreAllNonZeroValues()
    {
        var priceInterval = new PriceInterval(10, 10);
        Assert.Equal(priceInterval.Max, 10);
        Assert.Equal(priceInterval.Min, 10);
    }
}
