using Dapper;
using domain.auction;
using dtos.auction;
using persistence;
using persistence.auction;
using persistence.cargoowner;
using web.endpoints.auction;

namespace project_x_test.auction;

public class SaveAuctionControllerTest
{
    [Fact]
    public async Task SavingAuctionWithInvalidOwnerIdShouldThrowAnExeption()
    {
        var sut = SetupSut();
        var saveAuctionRequest = new SaveAuctionRequestDto
        {
            CargoOwnerId = "wrongcargoowner",
            DeliveryPlace = "Addis Bole",
            MaxPickUpTime = "12:00",
            MinPickUpTime = "10:00",
            MaxPricePerHundredKiloGram = 120,
            MinPricePerHundredKiloGram = 100,
            OtherInformationAboutCargo = "Not many Information because I don't like this stuff",
            PickUpPlace = "Bahirdar Menaheria",
            PlannedPickUpDate = new DateTime(2023, 8, 3),
            TotalWeightOfCargo = 200,
            TypeOfCargo = "LIGHT",
        };

        await Assert.ThrowsAsync<Exception>(
            async () => await sut.Call(saveAuctionRequest)
        );
    }

    [Fact]
    public async Task SavingAuctionThatDoesntExistShouldInsertDataSuccessfully()
    {
        var sut = SetupSut();
        var getAuctionController = SetUpGetAuctionController();

        var saveAuctionRequest = InitDtoForSavingAuctionInitially();
        var savedAuctionId = await sut.Call(saveAuctionRequest);
        var savedAuction = await getAuctionController.Call(savedAuctionId);

        saveAuctionRequest.Id = savedAuctionId;
        var expectedAuction = Auction.parseFromDto(saveAuctionRequest);

        Assert.Equal(expectedAuction, savedAuction);

        await CleanUp(savedAuctionId);

    }

    [Fact]
    public async Task SavingAuctionThatExistsShouldEditTheExisitingDataSuccessfully()
    {
        var getAuctionController = SetUpGetAuctionController();
        var sut = SetupSut();

        var initialRequest = InitDtoForSavingAuctionInitially();
        string initiallySavedAuctionId = await sut.Call(initialRequest);

        var secondRequest = InitDtoForSavingAuctionSecondTime(initiallySavedAuctionId);
        string secondlySavedAuctionId = await sut.Call(secondRequest);

        var secondlySavedAuction = await getAuctionController.Call(secondlySavedAuctionId);
        var expectedAuction = Auction.parseFromDto(secondRequest);

        Assert.Equal(initiallySavedAuctionId, secondlySavedAuctionId);
        Assert.Equal(expectedAuction, secondlySavedAuction);

        await CleanUp(secondlySavedAuctionId);
    }


    private SaveAuctionController SetupSut()
    {
        var database = InitDbContext();
        var ownerRepo = new CargoOwnerRepositoryImpl(database);
        var auctionRepo = new AuctionRepositoryImpl(database);
        var sut = new SaveAuctionController(auctionRepo, ownerRepo);
        return sut;
    }

    private GetAuctionController SetUpGetAuctionController()
    {
        var database = InitDbContext();
        var repo = new AuctionRepositoryImpl(database);
        return new GetAuctionController(repo);
    }

    private SaveAuctionRequestDto InitDtoForSavingAuctionInitially()
    {
        return new SaveAuctionRequestDto
        {
            CargoOwnerId = "4650df78-9132-44d8-9168-4f90e31616e2",
            DeliveryPlace = "Addis Bole",
            MaxPickUpTime = "12:00",
            MinPickUpTime = "10:00",
            MaxPricePerHundredKiloGram = 120,
            MinPricePerHundredKiloGram = 100,
            OtherInformationAboutCargo = "Not many Information because I dont like this stuff",
            PickUpPlace = "Bahirdar Menaheria",
            PlannedPickUpDate = new DateTime(2023, 8, 3),
            TotalWeightOfCargo = 200,
            TypeOfCargo = "LIGHT",
        };
    }

    private SaveAuctionRequestDto InitDtoForSavingAuctionSecondTime(string id)
    {
        return new SaveAuctionRequestDto
        {
            Id = id,
            CargoOwnerId = "4650df78-9132-44d8-9168-4f90e31616e2",
            DeliveryPlace = "Addis Bole Manma",
            MaxPickUpTime = "01:00",
            MinPickUpTime = "12:00",
            MaxPricePerHundredKiloGram = 190,
            MinPricePerHundredKiloGram = 110,
            OtherInformationAboutCargo = "Not many Information because I very much like this stuff",
            PickUpPlace = "Bahirdar Piazza",
            PlannedPickUpDate = new DateTime(2023, 7, 3),
            TotalWeightOfCargo = 2000,
            TypeOfCargo = "HEAVY",
        };
    }

    private async Task CleanUp(string id)
    {
        var database = InitDbContext();
        var connection = database.Get();
        await connection.ExecuteAsync("delete from Auction where id = " + "'" + id + "'");
    }

    private DatabaseContext InitDbContext()
    {
        return new DatabaseContext(new Npgsql.NpgsqlConnection(
            "Server=localhost;Port=5432;Database=ProjectX;User Id=postgres;Password=root"));
    }
}