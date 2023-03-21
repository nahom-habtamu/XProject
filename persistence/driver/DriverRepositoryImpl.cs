using domain.driver;
namespace persistence.driver;

public class DriverRepositoryImpl : DriverRepository
{
    public Task<Driver?> Get(string id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Driver>> GetAllDrivers()
    {
        throw new NotImplementedException();

    }

    public Task Save(Driver entity)
    {
        throw new NotImplementedException();

    }
}