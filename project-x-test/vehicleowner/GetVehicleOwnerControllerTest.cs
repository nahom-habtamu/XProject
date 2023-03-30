using domain.exceptions;
using domain.vehicleowner;
using persistence;
using persistence.vehicleowner;
using web.endpoints.vehicleowner;

public class GetVehicleOwnerControllerTest
{
    [Fact]
    public async Task GettingVehicleOwnerWithIdThatDoesntExistShouldThrowAnError()
    {
        var wrongId = "wrongid";
        var sut = setUpSut();

        var exception = await Assert.ThrowsAsync<NoDataFoundWithThisIdException>(
            async () => await sut.Call(wrongId)
        );
        Assert.Equal("VehicleOwner With Id: " + wrongId +  " Is Not Found", exception.Message);
    }

    [Fact]
    public async Task GettingVehicleOwnerWithIdThatExistShouldParseObjectSuccessfullyAndReturnVehicleOwner()
    {
        var idOne = "2150df78-9132-44d8-9168-4f90e31616e1";
        var idTwo = "2150df78-9132-44d8-9168-4f90e31616e2";

        var sut = setUpSut();
        var vehicleOwnerFoundByIdOne = await sut.Call(idOne);
        var vehicleOwnerFoundByIdTwo = await sut.Call(idTwo);

        VehicleOwner expectedVehicleOwnerResultForIdOne = new VehicleOwner(
            "2150df78-9132-44d8-9168-4f90e31616e1",
            "Vehicle Owner 1", "0926849881", "vo1@gmail.com", "VO1 Company",
            "['2150df78-9132-44d8-9168-4f90e31616e1.jpg','2150df78-9132-44d8-9168-4f90e31616e1.jpg']",
            "vehicleowner-1", "vehicleowner1pass"
        );

        VehicleOwner expectedVehicleOwnerResultForIdTwo = new VehicleOwner(
            "2150df78-9132-44d8-9168-4f90e31616e2",
            "Vehicle Owner 2", "0926849882", "vo2@gmail.com", "VO2 Company",
            "['2150df78-9132-44d8-9168-4f90e31616e2.jpg','2150df78-9132-44d8-9168-4f90e31616e2.jpg']",
            "vehicleowner-2", "vehicleowner2pass"
        );

        Assert.Equal(vehicleOwnerFoundByIdOne, expectedVehicleOwnerResultForIdOne);
        Assert.Equal(vehicleOwnerFoundByIdTwo, expectedVehicleOwnerResultForIdTwo);
    }

    private GetVehicleOwnerController setUpSut()
    {
        var database = new DatabaseContext(
            new Npgsql.NpgsqlConnection(
                "Server=localhost;Port=5432;Database=ProjectX;User Id=postgres;Password=root"));
        var repository = new VehicleOwnerRepositoryImpl(database);
        var sut = new GetVehicleOwnerController(repository);
        return sut;
    }
}