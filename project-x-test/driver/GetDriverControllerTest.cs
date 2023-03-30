using domain.driver;
using domain.exceptions;
using persistence;
using persistence.driver;
using web.endpoints.driver;

public class GetDriverControllerTest
{
    [Fact]
    public async Task GettingDriverWithIdThatDoesntExistShouldThrowAnError()
    {
        var wrongId = "wrongid";
        var sut = setUpSut();
        await Assert.ThrowsAsync<NoDataFoundWithThisIdException>(async () => await sut.Call(wrongId));
    }

    [Fact]
    public async Task GettingDriverWithIdThatExistShouldParseObjectSuccessfullyAndReturnDriver()
    {
        var idOne = "7210df78-9132-44d8-9168-4f90e31616e1";
        var idTwo = "7210df78-9132-44d8-9168-4f90e31616e2";
        var sut = setUpSut();

        var driverFoundForIdOne = await sut.Call(idOne);
        var driverFoundForIdTwo = await sut.Call(idTwo);

        Driver expectedDriverResultForIdOne = new Driver(
            "7210df78-9132-44d8-9168-4f90e31616e1",
            "Nahom Habtamu", "0926849888", "nahom@gmail.com", "0",
            new DateTime(2023, 4, 5), "Addis Ababa, Shola",
            "1250df78-9132-44d8-9168-4f90e31616e4.png"
        );
        Driver expectedDriverResultForIdTwo = new Driver(
            "7210df78-9132-44d8-9168-4f90e31616e2",
            "Dagim Habtamu", "0947977597", "dagim@gmail.com", "0",
            new DateTime(2023, 4, 5), "Addis Ababa, Shola",
            "8720df78-9132-44d8-9168-4f90e31616e4.png"
        );
        Assert.Equal(driverFoundForIdOne, expectedDriverResultForIdOne);
        Assert.Equal(driverFoundForIdTwo, expectedDriverResultForIdTwo);
    }

    private GetDriverController setUpSut()
    {
        var database = new DatabaseContext(
            new Npgsql.NpgsqlConnection(
                "Server=localhost;Port=5432;Database=ProjectX;User Id=postgres;Password=root"));
        var repository = new DriverRepositoryImpl(database);
        var sut = new GetDriverController(repository);
        return sut;
    }
}