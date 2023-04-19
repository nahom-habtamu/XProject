using domain.cargoowner;
using persistence;
using persistence.cargoowner;
using web.endpoints.cargoowner;

namespace project_x_test.cargoowner;

public class GetAllCargoOwnersControllerTest
{
    [Fact]
    public async Task GettingAllCargoOwnersShouldSuccessfullyReadParseAndReturnCargoOwnersList()
    {
        var database = new DatabaseContext(
            new Npgsql.NpgsqlConnection(
                "Server=localhost;Port=5432;Database=ProjectX;User Id=postgres;Password=root"));
        var cargoOwnerRepo = new CargoOwnerRepositoryImpl(database);
        var sut = new GetAllCargoOwnersController(cargoOwnerRepo);

        var parsedCargoOwners = await sut.Call();

        List<CargoOwner> minExpectedResult = GetExpectedResponseItems();
        var lengthCheck = parsedCargoOwners.Count >= minExpectedResult.Count;
        var checkedItems = parsedCargoOwners.Where(
            pa => pa.Equals(minExpectedResult[0]) ||
                  pa.Equals(minExpectedResult[1]) ||
                  pa.Equals(minExpectedResult[2])
        ).ToList();

        Assert.True(lengthCheck);
        Assert.Equal(minExpectedResult.Count, checkedItems.Count);
    }

    private List<CargoOwner> GetExpectedResponseItems()
    {
        return new List<CargoOwner>
        {
            new CargoOwner(
                "4650df78-9132-44d8-9168-4f90e31616e1",
                "Cargo Owner 1", "0926849881", "cowner1@gmail.com",
                "Shola, Addis Ababa", "65650df78-9132-44d8-9168-4f90e31616e4.png","username","password",
                "abebe gemechu", "0911041221", "Shola, Addis Ababa", "abebe@gmail.com", "NN"
            ),
            new CargoOwner(
                "4650df78-9132-44d8-9168-4f90e31616e2",
                "Cargo Owner 2", "0926849882", "cowner2@gmail.com",
                "Shola, Addis Ababa", "1230df78-9132-44d8-9168-4f90e31616e4.png","username","password",
                "abebe gemechu", "0911041221", "Shola, Addis Ababa", "abebe@gmail.com", "NN"
            ),
            new CargoOwner(
                "4650df78-9132-44d8-9168-4f90e31616e3",
                "Cargo Owner 3", "0926849883", "cowner3@gmail.com",
                "Shola, Addis Ababa", "0650df78-9132-44d8-9168-4f90e31616e4.png","username","password",
                "abebe gemechu", "0911041221", "Shola, Addis Ababa", "abebe@gmail.com", "NN"
            ),
        };
    }
}