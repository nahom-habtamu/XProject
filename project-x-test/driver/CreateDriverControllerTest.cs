using Dapper;
using domain.driver;
using dtos.driver;
using persistence;
using persistence.driver;
using web.endpoints.driver;

namespace project_x_test.driver;

public class CreateDriverControllerTest
{
    [Fact]
    public async Task CreatingDriverThatAlreadyExistsShouldEditTheExisitingDataSuccessfully()
    {
        var database = InitDbContext();
        var driverRepo = new DriverRepositoryImpl(database);
        var getDriverController = new GetDriverController(driverRepo);
        var sut = new CreateDriverController(driverRepo);

        var intialRequest = InitDtoForCreatingDriverIntially();
        string intiallyCreatedDriverId = await sut.Call(intialRequest);

        var secondRequest = InitDtoForCreatingSameDriverSecondTimeWithDifferentValues(
            intiallyCreatedDriverId
        );
        string secondlyCreatedDriverId = await sut.Call(secondRequest);

        var secondlyCreatedDriver = await getDriverController.Call(secondlyCreatedDriverId);
        var expectedUpdatedDriver = new Driver(
            secondRequest.Id, secondRequest.Name!,
            secondRequest.PhoneNumber!, secondRequest.Email!,
            secondRequest.Gender!, secondRequest.DateOfBirth,
            secondRequest.SpecificAddress!, secondRequest.DrivingLicense!
        );

        Assert.Equal(secondlyCreatedDriverId, intiallyCreatedDriverId);
        Assert.Equal(secondlyCreatedDriver, expectedUpdatedDriver);

        await CleanUp(database, secondlyCreatedDriverId);
    }

    [Fact]
    public async Task CreatingDriverWithCorrectValuesShouldBeSuccessfull()
    {
        var database = InitDbContext();
        var driverRepo = new DriverRepositoryImpl(database);
        var sut = new CreateDriverController(driverRepo);
        var getDriverController = new GetDriverController(driverRepo);

        CreateDriverRequestDto createDriverRequest = InitDtoForCreatingDriverIntially();

        string createdDriverId = await sut.Call(createDriverRequest);
        var createdDriver = await getDriverController.Call(createdDriverId);

        var expectedDriver = new Driver(
            createdDriverId, createDriverRequest.Name!,
            createDriverRequest.PhoneNumber!, createDriverRequest.Email!,
            createDriverRequest.Gender!, createDriverRequest.DateOfBirth,
            createDriverRequest.SpecificAddress!,
            createDriverRequest.DrivingLicense!
        );

        Assert.Equal(createdDriver, expectedDriver);
        await CleanUp(database, createdDriverId);
    }

    private DatabaseContext InitDbContext()
    {
        return new DatabaseContext(
            new Npgsql.NpgsqlConnection(
                "Server=localhost;Port=5432;Database=ProjectX;User Id=postgres;Password=root"));
    }

    private CreateDriverRequestDto InitDtoForCreatingDriverIntially()
    {
        return new CreateDriverRequestDto
        {
            DateOfBirth = DateTime.Parse("2000-2-3"),
            DrivingLicense = "13131ddhdv1331345df3414sd3133.jpg",
            Email = "DriverX@gmail.com",
            Gender = "1",
            Name = "Driver1",
            PhoneNumber = "0911111111",
            SpecificAddress = "Somwhere in Ethiopia"
        };
    }

    private CreateDriverRequestDto
        InitDtoForCreatingSameDriverSecondTimeWithDifferentValues(string id)
    {
        return new CreateDriverRequestDto
        {
            Id = id,
            DateOfBirth = DateTime.Parse("2000-2-3"),
            DrivingLicense = "13131ddhdv1331345df3414sd3133.jpg",
            Email = "DriverXYZ@gmail.com",
            Gender = "1",
            Name = "Driver1 Edited",
            PhoneNumber = "0911111111",
            SpecificAddress = "Somwhere in Ethiopia"
        };
    }

    private async Task CleanUp(DatabaseContext database, string id)
    {
        var connection = database.Get();
        await connection.ExecuteAsync("delete from Driver where id = " + "'" + id + "'");
    }
}