using System.Linq;
using dtos.bid;
using persistence;
using persistence.bid;
using persistence.driver;
using persistence.vehicle;
using web.endpoints.bid;

namespace project_x_test.bid;

public class GetBidsForAuctionControllerTest
{
    [Fact]
    public async Task GettingBidsByAuctionIdThatDoesntExistShouldReturnEmptyList()
    {
        var sut = SetUpSut();
        var wrongId = "wrongauctionid";

        var bids = await sut.Call(wrongId);

        Assert.False(bids.Any());
    }

    [Fact]
    public async Task GettingBidsByCorrectAuctionIdShouldParseAndReturnListOfProperResponseDto()
    {
        var sut = SetUpSut();
        var auctionIdOne = "1110df78-9132-44d8-9168-4f90e31616e1";
        var auctionIdTwo = "1110df78-9132-44d8-9168-4f90e31616e2";

        var actualParsedBidsByAuctionOne = await sut.Call(auctionIdOne);
        var actualParsedBidsByAuctionTwo = await sut.Call(auctionIdTwo);
        
        var expectedParsedBidsByAuctionOne = GetExpectedParsedBidsForIdOne();
        var expectedParsedBidsByAuctionTwo = GetExpectedParsedBidsForIdTwo();

        AssertIfActualAndExpectedAreEqualInLengthAndAreSubSetOfEachOther(
            actualParsedBidsByAuctionOne,
            expectedParsedBidsByAuctionOne
        );
        AssertIfActualAndExpectedAreEqualInLengthAndAreSubSetOfEachOther(
            actualParsedBidsByAuctionTwo,
            expectedParsedBidsByAuctionTwo
        );
    }

    private GetBidsForAuctionController SetUpSut()
    {
        var database = new DatabaseContext(
                    new Npgsql.NpgsqlConnection(
                        "Server=localhost;Port=5432;Database=ProjectX;User Id=postgres;Password=root"));
        var bidRepo = new BidRepositoryImpl(database);
        var driverRepo = new DriverRepositoryImpl(database);
        var vehicleRepo = new VehicleRepositoryImpl(database);
        var sut = new GetBidsForAuctionController(
            bidRepo,
            driverRepo,
            vehicleRepo
        );
        return sut;
    }

    private List<GetBidsForAuctionItemResponseDto> GetExpectedParsedBidsForIdOne()
    {
        return new List<GetBidsForAuctionItemResponseDto> {
            new GetBidsForAuctionItemResponseDto {
                Id = "9990df78-9132-44d8-9168-4f90e31616e1",
                DriverId = "7210df78-9132-44d8-9168-4f90e31616e1",
                DriverName = "Nahom Habtamu",
                VehicleImages = new List<string>{
                    "7210df78-9132-44d8-9168-4f90e31616.jpg"
                },
                VehicleInsuranceImage = "5210df78-9132-44d8-9168-4f90e31616.jpg",
                VehicleManufaturedDate = DateTime.Parse("2022-04-05"),
                VehicleModel = "Model 1",
                VehicleRating = 0
            }
        };
    }

    private List<GetBidsForAuctionItemResponseDto> GetExpectedParsedBidsForIdTwo()
    {
        return new List<GetBidsForAuctionItemResponseDto> {
            new GetBidsForAuctionItemResponseDto {
                Id = "9990df78-9132-44d8-9168-4f90e31616e2",
                DriverId = "7210df78-9132-44d8-9168-4f90e31616e2",
                DriverName = "Dagim Habtamu",
                VehicleImages = new List<string>{
                    "1110df78-9132-44d8-9168-4f90e31616.jpg",
                },
                VehicleInsuranceImage = "9010df78-9132-44d8-9168-4f90e31616.jpg",
                VehicleManufaturedDate = DateTime.Parse("2022-04-05"),
                VehicleModel = "Model 2",
                VehicleRating = 0
            }
        };
    }

    private void AssertIfActualAndExpectedAreEqualInLengthAndAreSubSetOfEachOther(
        List<GetBidsForAuctionItemResponseDto> actual,
        List<GetBidsForAuctionItemResponseDto> expected
    )
    {
        Assert.True(actual.Count == expected.Count);
        Assert.True(actual.All(i => CheckIfContains(expected, i)));
        Assert.True(expected.All(i => CheckIfContains(actual, i)));
    }

    private bool CheckIfContains(
        List<GetBidsForAuctionItemResponseDto> items,
        GetBidsForAuctionItemResponseDto item
    )
    {
        return items.Where(i =>
            i.Id!.Equals(item.Id) &&
            i.DriverId!.Equals(item.DriverId) &&
            i.DriverName!.Equals(item.DriverName) &&
            (
                i.VehicleImages.Intersect(item.VehicleImages).Count() ==
                item.VehicleImages.Count &&
                i.VehicleImages.Intersect(item.VehicleImages).Count() ==
                i.VehicleImages.Count
            ) &&
            i.VehicleInsuranceImage!.Equals(item.VehicleInsuranceImage) &&
            i.VehicleManufaturedDate!.Equals(item.VehicleManufaturedDate) &&
            i.VehicleModel!.Equals(item.VehicleModel) &&
            i.VehicleRating!.Equals(item.VehicleRating)
        ).Any();
    }
}