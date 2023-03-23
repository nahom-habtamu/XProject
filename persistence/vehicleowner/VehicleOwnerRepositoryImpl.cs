using Dapper;
using domain.vehicleowner;

namespace persistence.vehicleowner;
public class VehicleOwnerRepositoryImpl : VehicleOwnerRepository
{
    private readonly DatabaseContext _context;

    public VehicleOwnerRepositoryImpl(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<VehicleOwner?> Get(string id)
    {
        var connection = _context.Get();
        var sql = @"select id, name, phoneNumber, email, companyName, tradeLicense, userName, password from VehicleOwner WHERE id = " + "'" + id + "'";
        var vehicleOwner = (await connection.QueryAsync<VehicleOwner>(sql)).FirstOrDefault();
        return vehicleOwner;
    }

    public Task<List<VehicleOwner>> GetAllVehicleOwners()
    {
        throw new NotImplementedException();
    }

    public Task Save(VehicleOwner entity)
    {
        throw new NotImplementedException();
    }
}