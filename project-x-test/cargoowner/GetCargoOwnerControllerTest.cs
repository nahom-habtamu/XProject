using domain.cargoowner;
using persistence;
using persistence.cargoowner;
using web.endpoints.cargoowner;
namespace project_x_test.cargoowner;
public class GetCargoOwnerControllerTest
{
    [Fact]
    public void GettingCargoOwnerWithIdThatDoesntExistShowThrowAnError()
    {
        var wrongId = "wrongid";
        var sut = setUpSut();
        Assert.ThrowsAsync<Exception>(async () => await sut.Call(wrongId));
    }

    [Fact]
    public async Task GettingCargoOwnerWithIdThatExistShowParseObjectSuccessfullyAndReturnCargoOwner()
    {
        var idOne = "4650df78-9132-44d8-9168-4f90e31616e1";
        var idTwo = "4650df78-9132-44d8-9168-4f90e31616e2";
        var sut = setUpSut();

        var cargoOwnerFoundForIdOne = await sut.Call(idOne);
        var cargoOwnerFoundForIdTwo = await sut.Call(idTwo);

        var expectedCargoOwnerResultForIdOne = new CargoOwner(
            "4650df78-9132-44d8-9168-4f90e31616e1",
            "Cargo Owner 1", "0926849881", "cowner1@gmail.com",
            "Shola, Addis Ababa", "65650df78-9132-44d8-9168-4f90e31616e4.png",
            "abebe gemechu", "0911041221", "Shola, Addis Ababa", "abebe@gmail.com", "NN"
        );

        var expectedCargoOwnerResultForIdTwo = new CargoOwner(
            "4650df78-9132-44d8-9168-4f90e31616e2",
            "Cargo Owner 2", "0926849882", "cowner2@gmail.com",
            "Shola, Addis Ababa", "1230df78-9132-44d8-9168-4f90e31616e4.png",
            "abebe gemechu", "0911041221", "Shola, Addis Ababa", "abebe@gmail.com", "NN"
        );

        Assert.Equal(cargoOwnerFoundForIdOne, expectedCargoOwnerResultForIdOne);
        Assert.Equal(cargoOwnerFoundForIdTwo, expectedCargoOwnerResultForIdTwo);
    }

    private GetCargoOwnerController setUpSut()
    {
        var database = new DatabaseContext(
            new Npgsql.NpgsqlConnection(
                "Server=localhost;Port=5432;Database=ProjectX;User Id=postgres;Password=root"));
        var repository = new CargoOwnerRepositoryImpl(database);
        var sut = new GetCargoOwnerController(repository);
        return sut;
    }

}