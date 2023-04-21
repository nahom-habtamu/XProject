using domain.bid;
using domain.exceptions;
using persistence;
using persistence.bid;
using web.endpoints.bid;

namespace project_x_test.bid;

public class GetBidControllerTest
{
    [Fact]
    public async Task GettingBidWithWrongIdShouldThrowAnException()
    {
        var sut = SetUpSut();
        var wrongId = "wrongbidid";

        var exception = await Assert.ThrowsAsync<NoDataFoundWithThisIdException>(
            async () => await sut.Call(wrongId)
        );
        Assert.Equal("Bid With Id: " + wrongId + " Is Not Found", exception.Message);
    }

    [Fact]
    public async Task GettingBidWithCorrectIdShouldReturnBid()
    {
        var sut = SetUpSut();
        var bidIdOne = "9990df78-9132-44d8-9168-4f90e31616e1";
        var bidIdTwo = "9990df78-9132-44d8-9168-4f90e31616e2";

        var actualBidByIdOne = await sut.Call(bidIdOne);
        var actualBidByIdTwo = await sut.Call(bidIdTwo);

        var expectedBidByIdOne = new Bid(
            "9990df78-9132-44d8-9168-4f90e31616e1",
            "1110df78-9132-44d8-9168-4f90e31616e1",
            "7210df78-9132-44d8-9168-4f90e31616e1",
            900,
            "as opposed to using Content here, content here, making it look like readable readable English",
            DateTime.Parse("2023-04-20 11:43:00")
        );

        var expectedBidByIdTwo = new Bid(
            "9990df78-9132-44d8-9168-4f90e31616e2",
            "1110df78-9132-44d8-9168-4f90e31616e2",
            "7210df78-9132-44d8-9168-4f90e31616e2",
            1000,
            "with the release of Letraset sheets containing Lorem Ipsum passages, and more things",
            DateTime.Parse("2023-04-20 11:44:00")
        );

        Assert.Equal(expectedBidByIdOne, actualBidByIdOne);
        Assert.Equal(expectedBidByIdTwo, actualBidByIdTwo);
    }

    private GetBidController SetUpSut()
    {
        var database = new DatabaseContext(
                 new Npgsql.NpgsqlConnection(
                     "Server=localhost;Port=5432;Database=ProjectX;User Id=postgres;Password=root"));
        var bidRepo = new BidRepositoryImpl(database);
        var sut = new GetBidController(bidRepo);
        return sut;
    }
}