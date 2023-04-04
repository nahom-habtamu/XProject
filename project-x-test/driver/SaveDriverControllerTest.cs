using Dapper;
using domain.driver;
using dtos.driver;
using persistence;
using persistence.driver;
using web.endpoints.driver;

namespace project_x_test.driver;

public class SaveDriverControllerTest
{
    [Fact]
    public async Task SavingDriverThatExistsShouldEditTheExisitingDataSuccessfully()
    {
        var database = InitDbContext();
        var driverRepo = new DriverRepositoryImpl(database);
        var getDriverController = new GetDriverController(driverRepo);
        var sut = new SaveDriverController(driverRepo);

        var intialRequest = InitDtoForSavingDriverIntially();
        string intiallySavedDriverId = await sut.Call(intialRequest);

        var secondRequest = InitDtoForSavingDriverSecondTime(intiallySavedDriverId);
        string secondlySavedDriverId = await sut.Call(secondRequest);

        var actualSecondlySavedDriver = await getDriverController.Call(secondlySavedDriverId);
        var expectedSecondlySavedDriver = Driver.parseFromDto(secondRequest);

        Assert.Equal(secondlySavedDriverId, intiallySavedDriverId);
        Assert.Equal(actualSecondlySavedDriver, expectedSecondlySavedDriver);

        await CleanUp(database, secondlySavedDriverId);
    }

    [Fact]
    public async Task SavingDriverThatDoesntExistShouldInsertDataSuccessfully()
    {
        var database = InitDbContext();
        var driverRepo = new DriverRepositoryImpl(database);
        var sut = new SaveDriverController(driverRepo);
        var getDriverController = new GetDriverController(driverRepo);

        SaveDriverRequestDto saveDriverRequest = InitDtoForSavingDriverIntially();

        string savedDriverId = await sut.Call(saveDriverRequest);
        var savedDriver = await getDriverController.Call(savedDriverId);

        saveDriverRequest.Id = savedDriverId;
        var expectedDriver = Driver.parseFromDto(saveDriverRequest);

        Assert.Equal(savedDriver, expectedDriver);
        await CleanUp(database, savedDriverId);
    }

    private DatabaseContext InitDbContext()
    {
        return new DatabaseContext(new Npgsql.NpgsqlConnection(
            "Server=localhost;Port=5432;Database=ProjectX;User Id=postgres;Password=root"));
    }

    private SaveDriverRequestDto InitDtoForSavingDriverIntially()
    {
        return new SaveDriverRequestDto
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

    private SaveDriverRequestDto
        InitDtoForSavingDriverSecondTime(string id)
    {
        return new SaveDriverRequestDto
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