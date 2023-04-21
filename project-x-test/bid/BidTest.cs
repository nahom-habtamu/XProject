using domain.bid;

namespace project_x_test.bid;
public class BidTest
{
    Bid bidOne = new Bid(
        "9990df78-9132-44d8-9168-4f90e31616e1",
        "1110df78-9132-44d8-9168-4f90e31616e1",
        "7210df78-9132-44d8-9168-4f90e31616e1",
        900,
        "as opposed to using Content here, content here, making it look like readable readable English",
        new DateTime(2023, 4, 20, 3, 5, 1)
    );

    [Fact]
    public void ShouldReturnTrueWhenComparingBidInstancesOfSameValue()
    {
        Bid bidTwo = new Bid(
            "9990df78-9132-44d8-9168-4f90e31616e1",
            "1110df78-9132-44d8-9168-4f90e31616e1",
            "7210df78-9132-44d8-9168-4f90e31616e1",
            900,
            "as opposed to using Content here, content here, making it look like readable readable English",
            new DateTime(2023, 4, 20, 3, 5, 1)
        );
        Assert.Equal(bidOne, bidTwo);
    }

    [Fact]
    public void ShouldReturnFalseWhenComparingBidInstancesOfDifferentPropertyValues()
    {
        Bid bidTwo = new Bid(
            "9990df78-9132-44d8-9168-4f90e31616e2",
            "1110df78-9132-44d8-9168-4f90e31616e2",
            "7210df78-9132-44d8-9168-4f90e31616e2",
            1000,
            "with the release of Letraset sheets containing Lorem Ipsum passages, and more things",
            new DateTime(2022, 4, 20, 1, 6, 22)
        );
        Assert.NotEqual(bidOne, bidTwo);
    }

    [Fact]
    public void ShouldReturnFalseWhenComparingWithNullValue()
    {
        Assert.Equal(bidOne.Equals(null), false);
    }
}