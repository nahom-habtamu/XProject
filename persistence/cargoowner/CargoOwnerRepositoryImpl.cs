using Dapper;
using domain.cargoowner;
using Npgsql;

namespace persistence.cargoowner;
public class CargoOwnerRepositoryImpl : CargoOwnerRepository
{
    public async Task<CargoOwner?> Get(string id)
    {
        using (var connection = new NpgsqlConnection("Server=localhost;Port=5432;Database=ProjectX;User Id=postgres;Password=root"))
        {
            var cargoOwner = (await connection.QueryAsync<CargoOwner, CargoOwnerPointPerson, CargoOwner>(
                @"select id, name, phoneNumber, email, specificAddress, tradeLicense,
                  pointPersonPosition as position, pointPersonName as name, pointPersonPhoneNumber as phoneNumber, 
                  pointPersonSpecificAddress as specificAddress, pointPersonEmail as email 
                  from cargoowner where id = 
                " + id, (cargoOwner, pointPerson) =>
                {
                    cargoOwner.PointPerson = pointPerson;
                    return cargoOwner;
                }, splitOn: "id,position")).FirstOrDefault();

            return cargoOwner;
        }
    }

    public Task<List<CargoOwner>> GetAllCargoOwners()
    {
        return Task.Run(() => new List<CargoOwner>());
    }

    public Task Save(CargoOwner entity)
    {
        throw new NotImplementedException();
    }
}