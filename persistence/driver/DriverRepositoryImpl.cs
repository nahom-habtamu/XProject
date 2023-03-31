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

    private readonly string baseGetSql = @"SELECT id, name, phoneNumber, email, gender, 
        dateOfBirth, specificAddress, drivingLicense FROM Driver";

    public async Task<Driver?> Get(string id)
    {
        var sql = baseGetSql + " WHERE id = " + "'" + id + "'";
        var driver = (await QueryAndParseSelectRequest(sql)).FirstOrDefault();
        return driver;
    }

    public async Task<List<Driver>> GetAllDrivers()
    {
        var drivers = (await QueryAndParseSelectRequest(baseGetSql)).ToList();
        return drivers;
    }

    private async Task<IEnumerable<Driver>> QueryAndParseSelectRequest(string sql)
    {
        var connection = _context.Get();
        var result = (await connection.QueryAsync<Driver>(sql));
        return result;
    }

    public Task<string> Save(Driver entity)
    {
        throw new NotImplementedException();
    }
}