using domain.driver;
using persistence;
using persistence.driver;
using web.endpoints.driver;

namespace project_x_test.driver;

public class GetAllDriversControllerTest
{
    [Fact]
    public async Task GettingAllDriversShouldSuccessfullyReadParseAndReturnProperResponseDto()
    {
        var database = new DatabaseContext(
            new Npgsql.NpgsqlConnection(
                "Server=localhost;Port=5432;Database=ProjectX;User Id=postgres;Password=root"));
        var driverRepo = new DriverRepositoryImpl(database);
        var sut = new GetAllDriversController(driverRepo);
        List<Driver> minExpectedResult = GetExpectedResponseItems();

        var parsedDrivers = await sut.Call();

        var lengthCheck = parsedDrivers.Count >= minExpectedResult.Count;
        var checkedItems = parsedDrivers.Where(
            pa => pa.Equals(minExpectedResult[0]) ||
                  pa.Equals(minExpectedResult[1]) ||
                  pa.Equals(minExpectedResult[2])
        ).ToList();
        Assert.True(lengthCheck);
        Assert.Equal(minExpectedResult.Count, checkedItems.Count);
    }

    private List<Driver> GetExpectedResponseItems()
    {
        return new List<Driver> {
            new Driver(
                "7210df78-9132-44d8-9168-4f90e31616e1",
                "Nahom Habtamu", "0926849888", "nahom@gmail.com", "0",
                new DateTime(2023, 4, 5), "Addis Ababa, Shola",
                "1250df78-9132-44d8-9168-4f90e31616e4.png"
            ),
            new Driver(
                "7210df78-9132-44d8-9168-4f90e31616e2",
                "Dagim Habtamu", "0947977597", "dagim@gmail.com", "0",
                new DateTime(2023, 4, 5), "Addis Ababa, Shola",
                "8720df78-9132-44d8-9168-4f90e31616e4.png"
            ),
            new Driver(
                "7210df78-9132-44d8-9168-4f90e31616e3",
                "Tigist Bekele", "0911041221", "tg@gmail.com", "1",
                new DateTime(2023, 4, 5), "Addis Ababa, Shola",
                "5460df78-9132-44d8-9168-4f90e31616e4.png"
            ),
        };
    }
}