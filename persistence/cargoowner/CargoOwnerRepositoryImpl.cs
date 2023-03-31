using Dapper;
using domain.cargoowner;

namespace persistence.cargoowner;
public class CargoOwnerRepositoryImpl : CargoOwnerRepository
{
    private readonly DatabaseContext _context;
    public CargoOwnerRepositoryImpl(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<CargoOwner?> Get(string id)
    {
        var connection = _context.Get();
        var sql = @"select id, name, phoneNumber, email, specificAddress, tradeLicense,
            pointPersonName, pointPersonPhoneNumber,pointPersonSpecificAddress, pointPersonEmail, 
            pointPersonPosition from cargoowner WHERE id = " + "'" + id + "'";
        var cargoOwner = (await connection.QueryAsync<CargoOwner>(sql)).FirstOrDefault();
        return cargoOwner;
    }

    public async Task<List<CargoOwner>> GetAllCargoOwners()
    {
        var connection = _context.Get();
        var sql = @"select id, name, phoneNumber, email, specificAddress, tradeLicense,
            pointPersonName, pointPersonPhoneNumber,pointPersonSpecificAddress, pointPersonEmail, 
            pointPersonPosition from cargoowner";
        var cargoOwners = (await connection.QueryAsync<CargoOwner>(sql)).ToList();
        return cargoOwners;
    }

    public Task<string> Save(CargoOwner entity)
    {
        throw new NotImplementedException();
    }
}