using domain.vehicle;
using persistence;
using persistence.vehicle;
using web.endpoints.vehicle;

namespace project_x_test.vehicle;

public class GetVehiclesByDriverControllerTest
{
    [Fact]
    public async Task GettingVehiclesByInvalidDriverIdShouldReturnEmptyList()
    {
        var sut = SetUpSut();
        var wrongDriver = "wrongdriverid";

        var vehicles = await sut.Call(wrongDriver);

        Assert.False(vehicles.Any());
    }

    [Fact]
    public async Task GettingVehiclesByDriverShouldSuccessfullyReadParseAndReturnProperListOfVehicles()
    {
        var sut = SetUpSut();
        var driverIdOne = "7210df78-9132-44d8-9168-4f90e31616e1";
        var driverIdTwo = "7210df78-9132-44d8-9168-4f90e31616e2";

        var actualVehiclesByDriverOne = await sut.Call(driverIdOne);
        var actualVehiclesByDriverTwo = await sut.Call(driverIdTwo);


        var expectedVehiclesByDriverOne = GetExpectedVehiclesByDriverOne();
        var expectedVehiclesByDriverTwo = GetExpectedVehiclesByDriverTwo();

        AssertIfActualAndExpectedAreEqualInLengthAndAreSubSetOfEachOther(
            actualVehiclesByDriverOne,
            expectedVehiclesByDriverOne
        );
        AssertIfActualAndExpectedAreEqualInLengthAndAreSubSetOfEachOther(
            actualVehiclesByDriverTwo,
            expectedVehiclesByDriverTwo
        );
    }

    private GetVehiclesByDriverController SetUpSut()
    {
        var database = new DatabaseContext(
                    new Npgsql.NpgsqlConnection(
                        "Server=localhost;Port=5432;Database=ProjectX;User Id=postgres;Password=root"));
        var vehicleRepo = new VehicleRepositoryImpl(database);
        var sut = new GetVehiclesByDriverController(vehicleRepo);
        return sut;
    }

    private List<Vehicle> GetExpectedVehiclesByDriverOne()
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
            )
        };
    }

    private List<Vehicle> GetExpectedVehiclesByDriverTwo()
    {
        return new List<Vehicle> {
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
            )
        };
    }

    private void AssertIfActualAndExpectedAreEqualInLengthAndAreSubSetOfEachOther(
        List<Vehicle> actual,
        List<Vehicle> expected
    )
    {
        Assert.True(actual.Count == expected.Count);
        Assert.True(actual.All(i => expected.Contains(i)));
        Assert.True(expected.All(i => actual.Contains(i)));
    }

}