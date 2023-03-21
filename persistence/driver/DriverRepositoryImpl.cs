using Dapper;
using domain.driver;
namespace persistence.driver;

public class DriverRepositoryImpl : DriverRepository
{
    private readonly DatabaseContext _context;

    public DriverRepositoryImpl(DatabaseContext context)
    {
        _context = context;
    }

    public Task<Driver?> Get(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Driver>> GetAllDrivers()
    {
        var connection = _context.Get();
        var sql = @"SELECT id, name, phoneNumber, email, gender, 
            dateOfBirth, specificAddress, drivingLicense FROM Driver";
        var drivers = (await connection.QueryAsync<Driver>(sql)).ToList();
        return drivers;
    }

    public Task Save(Driver entity)
    {
        throw new NotImplementedException();
    }
}