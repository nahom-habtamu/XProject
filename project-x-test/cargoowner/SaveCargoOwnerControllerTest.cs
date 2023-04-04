using Dapper;
using domain.cargoowner;
using dtos.cargoowner;
using persistence;
using persistence.cargoowner;
using web.endpoints.cargoowner;

namespace project_x_test.cargoowner;

public class SaveCargoOwnerControllerTest
{
    [Fact]
    public async Task SavingCargoOwnerThatExistsShouldEditTheExisitingDataSuccessfully()
    {
        var database = InitDbContext();
        var cargoOwnerRepo = new CargoOwnerRepositoryImpl(database);
        var getCargoOwnerController = new GetCargoOwnerController(cargoOwnerRepo);
        var sut = new SaveCargoOwnerController(cargoOwnerRepo);

        var initialRequest = InitDtoForSavingCargoOwnerInitially();
        string intiallySavedCargoOwnerId = await sut.Call(initialRequest);

        var secondRequest = InitDtoForSavingCargoOwnerSecondTime(intiallySavedCargoOwnerId);
        string secondlySavedCargoOwnerId = await sut.Call(secondRequest);

        var secondlySavedCargoOwner = await getCargoOwnerController.Call(secondlySavedCargoOwnerId);
        var expectedCargoOwner = CargoOwner.parseFromDto(secondRequest);

        Assert.Equal(intiallySavedCargoOwnerId, secondlySavedCargoOwnerId);
        Assert.Equal(expectedCargoOwner, secondlySavedCargoOwner);

        await CleanUp(database, secondlySavedCargoOwnerId);
    }

    [Fact]
    public async Task SavingCargoOwnerThatDoesntExistShouldInsertDataSuccessfully()
    {
        var database = InitDbContext();
        var cargoOwnerRepo = new CargoOwnerRepositoryImpl(database);
        var getCargoOwnerController = new GetCargoOwnerController(cargoOwnerRepo);
        var sut = new SaveCargoOwnerController(cargoOwnerRepo);

        var saveCargoOwnerRequest = InitDtoForSavingCargoOwnerInitially();
        string savedCargoOwnerId = await sut.Call(saveCargoOwnerRequest);

        var savedCargoOwner = await getCargoOwnerController.Call(savedCargoOwnerId);
        saveCargoOwnerRequest.Id = savedCargoOwnerId;
        var expectedCargoOwner = CargoOwner.parseFromDto(saveCargoOwnerRequest);

        Assert.Equal(expectedCargoOwner, savedCargoOwner);

        await CleanUp(database, savedCargoOwnerId);
    }

    private DatabaseContext InitDbContext()
    {
        return new DatabaseContext(new Npgsql.NpgsqlConnection(
            "Server=localhost;Port=5432;Database=ProjectX;User Id=postgres;Password=root"));
    }

    private SaveCargoOwnerRequestDto InitDtoForSavingCargoOwnerInitially()
    {
        return new SaveCargoOwnerRequestDto
        {
            Email = "cargoownertest@gmail.com",
            Name = "CargoOwner Test 1",
            PhoneNumber = "0900000000",
            SpecificAddress = "Addis Ababa, Shola",
            TradeLicense = "65650d-44d8-9168-4f90e31616e4.png",
            PointPersonEmail = "pointperson@gmail.com",
            PointPersonName = "PointPerson 1",
            PointPersonPhoneNumber = "0988888888",
            PointPersonPosition = "position",
            PointPersonSpecificAddress = "Finfineenee Kegna",
        };
    }

    private SaveCargoOwnerRequestDto InitDtoForSavingCargoOwnerSecondTime(string id)
    {
        return new SaveCargoOwnerRequestDto
        {
            Id = id,
            Email = "cargoownertest2@gmail.com",
            Name = "CargoOwner Test 2",
            PhoneNumber = "0900000011",
            SpecificAddress = "Addis Ababa, Shoddaa",
            TradeLicense = "111650d-44d8-9168-4f90e31616e4.png",
            PointPersonEmail = "pointperson2@gmail.com",
            PointPersonName = "PointPerson 2",
            PointPersonPhoneNumber = "0988888800",
            PointPersonPosition = "position2",
            PointPersonSpecificAddress = "Finfineenee Kegna 2",
        };
    }

    private static async Task CleanUp(DatabaseContext database, string id)
    {
        var connection = database.Get();
        await connection.ExecuteAsync("delete from CargoOwner where id = " + "'" + id + "'");
    }
}