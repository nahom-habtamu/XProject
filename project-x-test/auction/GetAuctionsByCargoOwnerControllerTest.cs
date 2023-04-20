using domain.auction;
using persistence;
using persistence.auction;
using web.endpoints.auction;

namespace project_x_test.auction;

public class GetAuctionsByCargoOwnerControllerTest
{
    [Fact]
    public async Task GettingAuctionsByWrongCargoOwnerIdShouldReturnEmptyList()
    {
        var sut = SetUpSut();
        var wrongId = "blahblah";

        var parsedAuctions = await sut.Call(wrongId);

        Assert.Equal(parsedAuctions.Count, 0);
    }

    [Fact]
    public async Task GettingAuctionsByCorrectCargoOwnerIdShouldSuccessfullyReadParseAndReturnAuctions()
    {
        var sut = SetUpSut();
        var cargoOwnerId = "4650df78-9132-44d8-9168-4f90e31616e1";

        var parsedAuctions = await sut.Call(cargoOwnerId);

        var minExpectedResult = GetExpectedResponseItems();

        Assert.Equal(parsedAuctions.Count, minExpectedResult.Count);
        Assert.Equal(minExpectedResult.First(), parsedAuctions.First());
    }

    private static GetAuctionsByCargoOwnerController SetUpSut()
    {
        var database = new DatabaseContext(
            new Npgsql.NpgsqlConnection(
                "Server=localhost;Port=5432;Database=ProjectX;User Id=postgres;Password=root"));
        var auctionRepo = new AuctionRepositoryImpl(database);
        var sut = new GetAuctionsByCargoOwnerController(auctionRepo);
        return sut;
    }

    private List<Auction> GetExpectedResponseItems()
    {
        return new List<Auction>{
            new Auction(
                "1110df78-9132-44d8-9168-4f90e31616e1",
                "4650df78-9132-44d8-9168-4f90e31616e1",
                "HEAVY", 20, "Idk", "Addis Ababa, Shola",
                DateTime.Parse("2023-02-03"),
                "Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum",
                "12:00:00", "02:00:00",
                DateTime.Parse("2023-04-20 11:43:00"),
                new PriceInterval(135.45, 180.9)
            )
        };
    }
}