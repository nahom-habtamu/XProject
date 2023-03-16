using domain.cargoowner;
using persistence;
using persistence.cargoowner;
using web.endpoints.cargoowner;
namespace project_x_test.cargoowner;
public class GetCargoOwnerByIdTest
{
    [Fact]
    public void GettingCargoOwnerWithIdThatDoesntExistShowThrowAnError()
    {
        var wrongId = "wrongid";
        var database = new DatabaseContext(new Npgsql.NpgsqlConnection("Server=localhost;Port=5432;Database=ProjectX;User Id=postgres;Password=root"));
        var repository = new CargoOwnerRepositoryImpl(database);
        var sut = new GetCargoOwnerController(repository);

        Assert.ThrowsAsync<Exception>(async () => await sut.Call(wrongId));
    }

    [Fact]
    public async Task GettingCargoOwnerWithIdThatExistShowParseObjectSuccessfullyAndReturnCargoOwner()
    {
        var id = "4650df78-9132-44d8-9168-4f90e31616e1";
        var database = new DatabaseContext(new Npgsql.NpgsqlConnection("Server=localhost;Port=5432;Database=ProjectX;User Id=postgres;Password=root"));
        var repository = new CargoOwnerRepositoryImpl(database);
        var sut = new GetCargoOwnerController(repository);

        var cargoOwnerFound = await sut.Call(id);
        var expectedCargoOwnerResult = new CargoOwner(
            "Cargo Owner 1", "0926849881", "cowner1@gmail.com",
            "Shola, Addis Ababa", "65650df78-9132-44d8-9168-4f90e31616e4.png",
            new CargoOwnerPointPerson("NN", "abebe gemechu", "0911041221", "Shola, Addis Ababa", "abebe@gmail.com"),
            "4650df78-9132-44d8-9168-4f90e31616e1"
        );
        Assert.Equal(cargoOwnerFound, expectedCargoOwnerResult);
    }
}