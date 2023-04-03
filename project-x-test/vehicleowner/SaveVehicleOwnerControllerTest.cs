using Dapper;
using domain.vehicleowner;
using dtos.vehicleowner;
using persistence;
using persistence.vehicleowner;
using web.endpoints.vehicleowner;

namespace project_x_test.vehicleowner;

public class SaveVehicleOwnerControllerTest
{
    [Fact]
    public async Task SavingVehicleOwnerThatDoesntExistShouldInsertDataSuccessfully()
    {
        var database = InitDbContext();
        var repository = new VehicleOwnerRepositoryImpl(database);
        var sut = new SaveVehicleOwnerController(repository);
        var getVehicleOwnerCont = new GetVehicleOwnerController(repository);

        var saveVehicleOwnerRequest = InitDtoForSavingVehicleOwnerInitally();
        string savedVehicleOwnerId = await sut.Call(saveVehicleOwnerRequest);
        var savedVehicleOwner = await getVehicleOwnerCont.Call(savedVehicleOwnerId);

        saveVehicleOwnerRequest.Id = savedVehicleOwnerId;
        var expectedVehicleOwner = VehicleOwner.buildFromDto(saveVehicleOwnerRequest);
        Assert.Equal(expectedVehicleOwner, savedVehicleOwner);

        await CleanUp(database, savedVehicleOwnerId);
    }

    [Fact]
    public async Task SavingVehicleOwnerThatExistsShouldEditTheExisitingDataSuccessfully()
    {
        var database = InitDbContext();
        var repository = new VehicleOwnerRepositoryImpl(database);
        var sut = new SaveVehicleOwnerController(repository);
        var getVehicleOwnerCont = new GetVehicleOwnerController(repository);


        var intialSaveRequest = InitDtoForSavingVehicleOwnerInitally();
        string intiallySavedVehicleOwnerId = await sut.Call(intialSaveRequest);

        var secondSaveRequest = InitDtoForSavingVehicleOwnerSecondTime(intiallySavedVehicleOwnerId);
        var secondlySavedVehicleOwnerId = await sut.Call(secondSaveRequest);
        var secondlySavedVehicleOwner = await getVehicleOwnerCont.Call(secondlySavedVehicleOwnerId);


        var expectedVehicleOwner = VehicleOwner.buildFromDto(secondSaveRequest);
        Assert.Equal(intiallySavedVehicleOwnerId, secondlySavedVehicleOwnerId);
        Assert.Equal(expectedVehicleOwner, secondlySavedVehicleOwner);

        await CleanUp(database, secondlySavedVehicleOwnerId);
    }

    private static DatabaseContext InitDbContext()
    {
        return new DatabaseContext(
            new Npgsql.NpgsqlConnection(
                "Server=localhost;Port=5432;Database=ProjectX;User Id=postgres;Password=root"));
    }

    private SaveVehicleOwnerRequestDto InitDtoForSavingVehicleOwnerInitally()
    {
        return new SaveVehicleOwnerRequestDto
        {
            CompanyName = "Some Company",
            Email = "company1@gmail.com",
            Name = "Abebe Gidada",
            Password = "1237781123343313",
            UserName = "abegidada",
            PhoneNumber = "0911899988",
            TradeLicense = "[\"2150df78-9132-44d8-9168-46e1.jpg\",\"2150df78-9132-44d8-9168-6e1.jpg\"]",
        };
    }

    private SaveVehicleOwnerRequestDto InitDtoForSavingVehicleOwnerSecondTime(string id)
    {
        return new SaveVehicleOwnerRequestDto
        {
            Id = id,
            CompanyName = "Some Company Changed",
            Email = "company1changed@gmail.com",
            Name = "Abebe Gidada Gebera",
            UserName = "abegidadagebera",
            Password = "1237781123343313d11",
            PhoneNumber = "0911899911",
            TradeLicense = "[\"1250df78-9132-44d8-9168-46e1.jpg\",\"9850df78-9132-44d8-9168-6e1.jpg\"]",
        };
    }

    private async Task CleanUp(DatabaseContext db, string id)
    {
        var connection = db.Get();
        await connection.ExecuteAsync("delete from VehicleOwner where id = " + "'" + id + "'");
    }
}