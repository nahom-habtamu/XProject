using domain.auction;
using persistence;
using persistence.auction;
using web.endpoints.auction;

public class GetAuctionControllerTest
{
    [Fact]
    public void GettingAuctionWithIdThatDoesntExistShouldThrowAnError()
    {
        var wrongId = "wrongid";
        var sut = setUpSut();
        Assert.ThrowsAsync<Exception>(async () => await sut.Call(wrongId));
    }

    [Fact]
    public async Task GettingAuctionWithIdThatExistShouldParseObjectSuccessfullyAndReturnAuction()
    {
        var id = "1110df78-9132-44d8-9168-4f90e31616e1";
        var sut = setUpSut();

        var auctionFound = await sut.Call(id);
        Auction expectedAuctionResult = new Auction(
            "4650df78-9132-44d8-9168-4f90e31616e1",
            "HEAVY", 20, "Idk", "Addis Ababa, Shola",
            DateTime.Parse("2023-02-03"),
            "Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum",
            "12:00:00", "02:00:00",
            new PriceInterval(135.45, 180.9),
            "1110df78-9132-44d8-9168-4f90e31616e1"
        );
        Assert.Equal(auctionFound, expectedAuctionResult);
    }

    private GetAuctionController setUpSut()
    {
        var database = new DatabaseContext(
            new Npgsql.NpgsqlConnection(
                "Server=localhost;Port=5432;Database=ProjectX;User Id=postgres;Password=root"));
        var repository = new AuctionRepositoryImpl(database);
        var sut = new GetAuctionController(repository);
        return sut;
    }
}