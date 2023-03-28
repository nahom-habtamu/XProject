using persistence;
using persistence.vehicle;
using web.endpoints.vehicle;

namespace project_x_test.vehicle;

public class GetPlateNumbersControllerTest
{
    [Fact]
    public async Task GettingPlateNumbersShouldReturnListOfStringSuccessfully()
    {
        var database = new DatabaseContext(
            new Npgsql.NpgsqlConnection(
                "Server=localhost;Port=5432;Database=ProjectX;User Id=postgres;Password=root"));
        var vehicleRepo = new VehicleRepositoryImpl(database);
        var sut = new GetPlateNumbersController(vehicleRepo);

        var actual = await sut.Call();

        var expected = new List<string> { "00000", "00002", "00003" };
        Assert.True(actual.Count >= expected.Count);
        Assert.True(actual.All(i => expected.Contains(i)));
    }
}