using domain.auction;

namespace project_x_test.auction;
public class AuctionTest
{
    Auction auctionOne = new Auction(
        "4650df78-9132-44d8-9168-4f90e31616e1",
        "type", 45, "delivery place", "pickup place",
        new DateTime(2023, 10, 9), "I dont know other information", "12:00:00", "02:00:00",
        new PriceInterval(1000, 1200),"someid"
    );

    [Fact]
    public void ShouldReturnTrueWhenComparingAuctionInstancesOfSameValue()
    {

        Auction auctionTwo = new Auction(
            "4650df78-9132-44d8-9168-4f90e31616e1",
            "type", 45, "delivery place", "pickup place",
            new DateTime(2023, 10, 9), "I dont know other information", "12:00:00", "02:00:00",
            new PriceInterval(1000, 1200),"someid"
        );
        Assert.Equal(auctionOne, auctionTwo);
    }

    [Fact]
    public void ShouldReturnFalseWhenComparingAuctionInstancesOfDifferentPropertyValues()
    {
        Auction auctionTwo = new Auction(
            "4650df78-9132-44d8-9168-4f90e31616e2",
            "type", 145, "delivery place", "pickup place",
            new DateTime(2023, 10, 9), "I don't know other information", "12:00:00", "02:00:00",
            new PriceInterval(1200, 1200),"someid2"
        );
        Assert.NotEqual(auctionOne, auctionTwo);
    }

    [Fact]
    public void ShouldReturnFalseWhenComparingWithNullValue()
    {
        Assert.Equal(auctionOne.Equals(null), false);
    }
}