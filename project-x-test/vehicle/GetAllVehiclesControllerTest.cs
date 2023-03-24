using domain.vehicle;
using persistence;
using persistence.vehicle;
using web.endpoints.vehicle;

namespace project_x_test.vehicle;

public class GetAllVehiclesControllerTest
{
    [Fact]
    public async Task GettingAllVehiclesShouldSuccessfullyReadParseAndReturnProperListOfVehicles()
    {
        var database = new DatabaseContext(
            new Npgsql.NpgsqlConnection(
                "Server=localhost;Port=5432;Database=ProjectX;User Id=postgres;Password=root"));
        var vehicleRepo = new VehicleRepositoryImpl(database);
        var sut = new GetAllVehiclesController(vehicleRepo);

        var parsedVehicles = await sut.Call();

        List<Vehicle> minExpectedResult = GetExpectedResponseItems();
        var lengthCheck = parsedVehicles.Count >= minExpectedResult.Count;
        var checkedItems = parsedVehicles.Where(
            pa => pa.Equals(minExpectedResult[0]) ||
                  pa.Equals(minExpectedResult[1]) ||
                  pa.Equals(minExpectedResult[2])
        ).ToList();

        Assert.True(lengthCheck);
        Assert.Equal(minExpectedResult.Count, checkedItems.Count);
    }

    private List<Vehicle> GetExpectedResponseItems()
    {
        return new List<Vehicle> {
            new Vehicle(
                "3190df78-9132-44d8-9168-4f90e31616e1","00000",
                "2150df78-9132-44d8-9168-4f90e31616e1","7210df78-9132-44d8-9168-4f90e31616e1",
                "Addis Ababa","SOME_VEHICLE_TYPE","SOME_LOAD_TYPE",DateTime.Parse("04-05-2022"),
                "Make 1", "Model 1","266KG","Green","7210df78-9132-44d8-9168-4f90e31616.jpg",
                "3210df78-9132-44d8-9168-4f90e31616.jpg","5210df78-9132-44d8-9168-4f90e31616.jpg",
                DateTime.Parse("03-05-2023"),DateTime.Parse("08-05-2023"),
                @"[
                    'x8-9132-44d8-9168-4f90e31616e1.jpg',
                    'x8-9132-44d8-9168-4f90e31616e1.jpg'
                ]"
            ),
            new Vehicle(
                "3190df78-9132-44d8-9168-4f90e31616e2","00002",
                "2150df78-9132-44d8-9168-4f90e31616e2","7210df78-9132-44d8-9168-4f90e31616e2",
                "Addis Ababa","SOME_VEHICLE_TYPE_2","SOME_LOAD_TYPE_2",DateTime.Parse("04-05-2022"),
                "Make 2", "Model 2","266KG","Red","1110df78-9132-44d8-9168-4f90e31616.jpg",
                "2810df78-9132-44d8-9168-4f90e31616.jpg","9010df78-9132-44d8-9168-4f90e31616.jpg",
                DateTime.Parse("03-05-2023"),DateTime.Parse("08-05-2023"),
                @"[
                    'y8-9132-44d8-9168-4f90e31616e1.jpg',
                    'y8-9132-44d8-9168-4f90e31616e1.jpg'
                ]"
            ),
            new Vehicle(
                "3190df78-9132-44d8-9168-4f90e31616e3","00003",
                "2150df78-9132-44d8-9168-4f90e31616e3","7210df78-9132-44d8-9168-4f90e31616e3",
                "Addis Ababa","SOME_VEHICLE_TYPE_3","SOME_LOAD_TYPE_3",DateTime.Parse("04-05-2022"),
                "Make 3", "Model 3","222KG","Yellow","3210df78-9132-44d8-9168-4f90e31616.jpg",
                "1210df78-9132-44d8-9168-4f90e31616.jpg","9010df78-9132-44d8-9168-4f90e31616.jpg",
                DateTime.Parse("03-05-2023"),DateTime.Parse("08-05-2023"),
                @"[
                    'z8-9132-44d8-9168-4f90e31616e1.jpg',
                    'z8-9132-44d8-9168-4f90e31616e1.jpg'
                ]"
            ),
        };
    }
}