using domain.driver;
using persistence;
using persistence.driver;
using web.endpoints.driver;

public class GetDriverControllerTest
{
    [Fact]
    public void GettingDriverWithIdThatDoesntExistShouldThrowAnError()
    {
        var wrongId = "wrongid";
        var sut = setUpSut();
        Assert.ThrowsAsync<Exception>(async () => await sut.Call(wrongId));
    }

    [Fact]
    public async Task GettingDriverWithIdThatExistShouldParseObjectSuccessfullyAndReturnDriver()
    {
        var id = "7210df78-9132-44d8-9168-4f90e31616e1";
        var sut = setUpSut();

        var driverFound = await sut.Call(id);
        Driver expectedDriverResult = new Driver(
            "7210df78-9132-44d8-9168-4f90e31616e1",
            "Nahom Habtamu", "0926849888", "nahom@gmail.com", "0",
            new DateTime(2023, 4, 5), "Addis Ababa, Shola",
            "1250df78-9132-44d8-9168-4f90e31616e4.png"
        );
        Assert.Equal(driverFound, expectedDriverResult);
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