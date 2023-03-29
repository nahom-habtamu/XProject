using domain.bid;
using persistence;
using persistence.bid;
using web.endpoints.bid;

namespace project_x_test.bid;

public class GetBidsByDriverControllerTest
{
    [Fact]
    public async Task GettingBidsByInvalidDriverIdShouldReturnEmptyList()
    {
        var sut = SetUpSut();
        var wrongDriver = "wrongdriverid";

        var bids = await sut.Call(wrongDriver);

        Assert.False(bids.Any());
    }

    [Fact]
    public async Task GettingBidsByDriverShouldSuccessfullyReadParseAndReturnProperListOfBids()
    {
        var sut = SetUpSut();
        var driverIdOne = "7210df78-9132-44d8-9168-4f90e31616e1";
        var driverIdTwo = "7210df78-9132-44d8-9168-4f90e31616e2";

        var actualBidsByDriverOne = await sut.Call(driverIdOne);
        var actualBidsByDriverTwo = await sut.Call(driverIdTwo);


        var expectedBidsByDriverOne = GetExpectedBidsByDriverOne();
        var expectedBidsByDriverTwo = GetExpectedBidsByDriverTwo();

        AssertIfActualAndExpectedAreEqualInLengthAndAreSubSetOfEachOther(
            actualBidsByDriverOne,
            expectedBidsByDriverOne
        );
        AssertIfActualAndExpectedAreEqualInLengthAndAreSubSetOfEachOther(
            actualBidsByDriverTwo,
            expectedBidsByDriverTwo
        );
    }

    private GetBidsByDriverController SetUpSut()
    {
        var database = new DatabaseContext(
                    new Npgsql.NpgsqlConnection(
                        "Server=localhost;Port=5432;Database=ProjectX;User Id=postgres;Password=root"));
        var bidRepo = new BidRepositoryImpl(database);
        var sut = new GetBidsByDriverController(bidRepo);
        return sut;
    }

    private List<Bid> GetExpectedBidsByDriverOne()
    {
        return new List<Bid> {
            new Bid(
                "9990df78-9132-44d8-9168-4f90e31616e1",
                "1110df78-9132-44d8-9168-4f90e31616e1",
                "7210df78-9132-44d8-9168-4f90e31616e1",
                900,
                "as opposed to using Content here, content here, making it look like readable readable English"
            )
        };
    }

    private List<Bid> GetExpectedBidsByDriverTwo()
    {
        return new List<Bid> {
            new Bid(
                "9990df78-9132-44d8-9168-4f90e31616e2",
                "1110df78-9132-44d8-9168-4f90e31616e2",
                "7210df78-9132-44d8-9168-4f90e31616e2",
                1000,
                "with the release of Letraset sheets containing Lorem Ipsum passages, and more things"
            )
        };
    }

    private void AssertIfActualAndExpectedAreEqualInLengthAndAreSubSetOfEachOther(
        List<Bid> actual,
        List<Bid> expected
    )
    {
        Assert.True(actual.Count == expected.Count);
        Assert.True(actual.All(i => expected.Contains(i)));
        Assert.True(expected.All(i => actual.Contains(i)));
    }

}