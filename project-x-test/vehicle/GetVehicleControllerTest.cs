using domain.exceptions;
using domain.vehicle;
using persistence;
using persistence.vehicle;
using web.endpoints.vehicle;

namespace project_x_test.vehicle;

public class GetVehicleTest
{
    [Fact]
    public async Task GettingVehicleWithWrongIdShouldThrowAnError()
    {
        var database = new DatabaseContext(
            new Npgsql.NpgsqlConnection(
                "Server=localhost;Port=5432;Database=ProjectX;User Id=postgres;Password=root"));
        var vehicleRepo = new VehicleRepositoryImpl(database);
        var sut = new GetVehicleController(vehicleRepo);

        var wrongId = "wrongvehicleid";

        var exception = await Assert.ThrowsAsync<NoDataFoundWithThisIdException>(
            async () => await sut.Call(wrongId)
        );
        Assert.Equal("Vehicle With Id: " + wrongId +  " Is Not Found", exception.Message);
    }

    [Fact]
    public async Task GettingVehicleWithIdThatExistShouldParseObjectSuccessfullyAndReturnVehicle()
    {
        var database = new DatabaseContext(
            new Npgsql.NpgsqlConnection(
                "Server=localhost;Port=5432;Database=ProjectX;User Id=postgres;Password=root"));
        var vehicleRepo = new VehicleRepositoryImpl(database);
        var sut = new GetVehicleController(vehicleRepo);

        var vehicleIdOne = "3190df78-9132-44d8-9168-4f90e31616e1";
        var vehicleIdTwo = "3190df78-9132-44d8-9168-4f90e31616e2";

        var actualVehicleOne = await sut.Call(vehicleIdOne);
        var actualVehicleTwo = await sut.Call(vehicleIdTwo);

        var expectedVehicleOne = GetExpectedVehicleByIdOne();
        var expectedVehicleTwo = GetExpectedVehicleByIdTwo();


        Assert.Equal(actualVehicleOne, expectedVehicleOne);
        Assert.Equal(actualVehicleTwo, expectedVehicleTwo);

    }

    private Vehicle GetExpectedVehicleByIdOne()
    {
        return new Vehicle(
            "3190df78-9132-44d8-9168-4f90e31616e1", "00000",
            "2150df78-9132-44d8-9168-4f90e31616e1", "7210df78-9132-44d8-9168-4f90e31616e1",
            "Addis Ababa", "SOME_VEHICLE_TYPE", "SOME_LOAD_TYPE", DateTime.Parse("04-05-2022"),
            "Make 1", "Model 1", "266KG", "Green", "7210df78-9132-44d8-9168-4f90e31616.jpg",
            "3210df78-9132-44d8-9168-4f90e31616.jpg", "5210df78-9132-44d8-9168-4f90e31616.jpg",
            DateTime.Parse("03-05-2023"), DateTime.Parse("08-05-2023"), DateTime.Parse("2023-04-20 11:43:00"),
            @"[
                'x8-9132-44d8-9168-4f90e31616e1.jpg',
                'x8-9132-44d8-9168-4f90e31616e1.jpg'
            ]"
        );
    }

    private Vehicle GetExpectedVehicleByIdTwo()
    {
        return new Vehicle(
            "3190df78-9132-44d8-9168-4f90e31616e2", "00002",
            "2150df78-9132-44d8-9168-4f90e31616e2", "7210df78-9132-44d8-9168-4f90e31616e2",
            "Addis Ababa", "SOME_VEHICLE_TYPE_2", "SOME_LOAD_TYPE_2", DateTime.Parse("04-05-2022"),
            "Make 2", "Model 2", "266KG", "Red", "1110df78-9132-44d8-9168-4f90e31616.jpg",
            "2810df78-9132-44d8-9168-4f90e31616.jpg", "9010df78-9132-44d8-9168-4f90e31616.jpg",
            DateTime.Parse("03-05-2023"), DateTime.Parse("08-05-2023"), DateTime.Parse("2023-04-20 11:44:00"),
            @"[
                'y8-9132-44d8-9168-4f90e31616e1.jpg',
                'y8-9132-44d8-9168-4f90e31616e1.jpg'
            ]"
        );
    }
}