using Dapper;
using domain.bid;
using dtos.bid;
using persistence;
using persistence.auction;
using persistence.bid;
using persistence.driver;
using web.endpoints.bid;

namespace project_x_test.bid;

public class SaveBidControllerTest
{
    [Fact]
    public async Task SavingBidWithInvalidDriverIdShouldThrowAnExeption()
    {
        var sut = SetupSut();
        var saveBidRequest = new SaveBidRequestDto
        {
            AuctionId = "1110df78-9132-44d8-9168-4f90e31616e1",
            DriverId = "wrongdriverid",
            AdditionalInformation = "Some blah blah information tsh hgahf djhajdg ladjabfhjafj kfnkanf",
            PricePerKilogram = 290
        };

        await Assert.ThrowsAsync<Exception>(
            async () => await sut.Call(saveBidRequest)
        );
    }

    [Fact]
    public async Task SavingBidWithInvalidAuctionIdShouldThrowAnExeption()
    {
        var sut = SetupSut();
        var saveBidRequest = new SaveBidRequestDto
        {
            AuctionId = "wrongauctionid",
            DriverId = "7210df78-9132-44d8-9168-4f90e31616e1",
            AdditionalInformation = "Some blah blah information tsh hgahf djhajdg ladjabfhjafj kfnkanf",
            PricePerKilogram = 290
        };

        await Assert.ThrowsAsync<Exception>(
            async () => await sut.Call(saveBidRequest)
        );
    }

    [Fact]
    public async Task SavingBidWithSameDriverAndAuctionShouldThrowAnExeption()
    {
        var sut = SetupSut();
        var saveBidRequest = new SaveBidRequestDto
        {
            AuctionId = "1110df78-9132-44d8-9168-4f90e31616e1",
            DriverId = "7210df78-9132-44d8-9168-4f90e31616e1",
            AdditionalInformation = "Some blah blah information tsh hgahf djhajdg ladjabfhjafj kfnkanf",
            PricePerKilogram = 290
        };

        await Assert.ThrowsAsync<Exception>(
            async () => await sut.Call(saveBidRequest)
        );
    }

    [Fact]
    public async Task SavingBidThatDoesntExistShouldInsertDataSuccessfully()
    {
        var getBidController = SetUpGetBidController();
        var sut = SetupSut();

        var saveBidRequest = new SaveBidRequestDto
        {
            AuctionId = "1110df78-9132-44d8-9168-4f90e31616e2",
            DriverId = "7210df78-9132-44d8-9168-4f90e31616e1",
            AdditionalInformation = "Some blah blah information tsh hgahf djhajdg ladjabfhjafj kfnkanf",
            PricePerKilogram = 290
        };

        string savedBidId = await sut.Call(saveBidRequest);
        var savedBid = await getBidController.Call(savedBidId);

        saveBidRequest.Id = savedBidId;
        var expectedBid = Bid.parseFromDto(saveBidRequest);
        Assert.Equal(expectedBid, savedBid);

        await CleanUp(savedBidId);
    }

    [Fact]
    public async Task SavingBidThatExistsShouldEditTheExisitingDataSuccessfully()
    {
        var getBidController = SetUpGetBidController();
        var sut = SetupSut();

        var initialRequest = new SaveBidRequestDto
        {
            AuctionId = "1110df78-9132-44d8-9168-4f90e31616e2",
            DriverId = "7210df78-9132-44d8-9168-4f90e31616e1",
            AdditionalInformation = "Some blah blah information tsh hgahf djhajdg ladjabfhjafj kfnkanf",
            PricePerKilogram = 290
        };
        string initiallySavedBidId = await sut.Call(initialRequest);

        var secondRequest = new SaveBidRequestDto
        {
            Id = initiallySavedBidId,
            AuctionId = "1110df78-9132-44d8-9168-4f90e31616e3",
            DriverId = "7210df78-9132-44d8-9168-4f90e31616e2",
            AdditionalInformation = "I am gonna kill you",
            PricePerKilogram = 970
        };
        string secondlySavedBidId = await sut.Call(secondRequest);

        var secondlySavedBid = await getBidController.Call(secondlySavedBidId);
        var expectedBid = Bid.parseFromDto(secondRequest);

        Assert.Equal(initiallySavedBidId, secondlySavedBidId);
        Assert.Equal(expectedBid, secondlySavedBid);

        await CleanUp(secondlySavedBidId);
    }

    private SaveBidController SetupSut()
    {
        var database = InitDbContext();
        var bidRepo = new BidRepositoryImpl(database);
        var driverRepo = new DriverRepositoryImpl(database);
        var auctionRepo = new AuctionRepositoryImpl(database);

        var sut = new SaveBidController(auctionRepo, driverRepo, bidRepo);
        return sut;
    }

    private GetBidController SetUpGetBidController()
    {
        var database = InitDbContext();
        var bidRepo = new BidRepositoryImpl(database);
        return new GetBidController(bidRepo);
    }

    private async Task CleanUp(string id)
    {
        var database = InitDbContext();
        var connection = database.Get();
        await connection.ExecuteAsync("delete from Bid where id = " + "'" + id + "'");
    }

    private DatabaseContext InitDbContext()
    {
        return new DatabaseContext(new Npgsql.NpgsqlConnection(
            "Server=localhost;Port=5432;Database=ProjectX;User Id=postgres;Password=root"));
    }
}