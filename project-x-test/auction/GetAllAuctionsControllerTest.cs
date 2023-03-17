using dtos.auction;
using persistence;
using persistence.auction;
using persistence.cargoowner;
using web.endpoints.auction;

public class GetAllAuctionsControllerTest
{
    [Fact]
    public async Task GettingAllAuctionsShouldSuccessfullyReadParseAndReturnProperResponseDto()
    {
        var database = new DatabaseContext(
            new Npgsql.NpgsqlConnection(
                "Server=localhost;Port=5432;Database=ProjectX;User Id=postgres;Password=root"));
        var auctionRepo = new AuctionRepositoryImpl(database);
        var cargoOwnerRepo = new CargoOwnerRepositoryImpl(database);
        var sut = new GetAllAuctionsController(auctionRepo, cargoOwnerRepo);
        List<GetAllAuctionsItemResponseDto> minExpectedResult = GetExpectedResponseItems();

        var parsedAuctions = await sut.Call();


        var lengthCheck = parsedAuctions.Count >= minExpectedResult.Count;
        var checkedItems = parsedAuctions.Where(
            pa => CheckEquality(pa, minExpectedResult[0]) ||
                  CheckEquality(pa, minExpectedResult[1]) ||
                  CheckEquality(pa, minExpectedResult[2])
        ).ToList();
        Assert.True(lengthCheck);
        Assert.Equal(minExpectedResult.Count, checkedItems.Count);
    }

    private List<GetAllAuctionsItemResponseDto> GetExpectedResponseItems()
    {
        return new List<GetAllAuctionsItemResponseDto>{
            new GetAllAuctionsItemResponseDto {
                AuctionId = "1110df78-9132-44d8-9168-4f90e31616e1",
                CargoOwnerId = "4650df78-9132-44d8-9168-4f90e31616e1",
                CargoOwnerName = "Cargo Owner 1",
                TypeOfCargo = "HEAVY",
                WeightOfCargo = 20,
                CompanyName = "",
                MinPickUpTime = TimeSpan.Parse("12:00:00"),
                MaxPickUpTime = TimeSpan.Parse("02:00:00"),
                MinPricePerHundredKiloGram = 135.45,
                MaxPricePerHundredKiloGram = 180.9,
            },

            new GetAllAuctionsItemResponseDto {
                AuctionId = "1110df78-9132-44d8-9168-4f90e31616e2",
                CargoOwnerId = "4650df78-9132-44d8-9168-4f90e31616e2",
                CargoOwnerName = "Cargo Owner 2",
                TypeOfCargo = "LIGHT",
                WeightOfCargo = 20,
                CompanyName = "",
                MinPickUpTime = TimeSpan.Parse("11:00:00"),
                MaxPickUpTime = TimeSpan.Parse("03:00:00"),
                MinPricePerHundredKiloGram = 35.45,
                MaxPricePerHundredKiloGram = 43.9,
            },

            new GetAllAuctionsItemResponseDto {
                AuctionId = "1110df78-9132-44d8-9168-4f90e31616e3",
                CargoOwnerId = "4650df78-9132-44d8-9168-4f90e31616e3",
                CargoOwnerName = "Cargo Owner 3",
                TypeOfCargo = "MEDIUM",
                WeightOfCargo = 20,
                CompanyName = "",
                MinPickUpTime = TimeSpan.Parse("02:00:00"),
                MaxPickUpTime = TimeSpan.Parse("04:00:00"),
                MinPricePerHundredKiloGram = 55.45,
                MaxPricePerHundredKiloGram = 73.9,
            },
        };
    }

    private bool CheckEquality(
        GetAllAuctionsItemResponseDto itemOne,
        GetAllAuctionsItemResponseDto itemTwo
    )
    {
        return itemOne.AuctionId!.Equals(itemTwo.AuctionId) &&
            itemOne.CargoOwnerId!.Equals(itemTwo.CargoOwnerId) &&
            itemOne.CargoOwnerName!.Equals(itemTwo.CargoOwnerName) &&
            itemOne.CompanyName!.Equals(itemTwo.CompanyName) &&
            itemOne.MinPickUpTime!.Equals(itemTwo.MinPickUpTime) &&
            itemOne.MaxPickUpTime!.Equals(itemTwo.MaxPickUpTime) &&
            itemOne.MinPricePerHundredKiloGram!.Equals(itemTwo.MinPricePerHundredKiloGram) &&
            itemOne.MaxPricePerHundredKiloGram!.Equals(itemTwo.MaxPricePerHundredKiloGram) &&
            itemOne.TypeOfCargo!.Equals(itemTwo.TypeOfCargo) &&
            itemOne.WeightOfCargo!.Equals(itemTwo.WeightOfCargo);
    }
}