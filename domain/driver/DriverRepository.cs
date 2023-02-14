namespace domain.driver;

public interface DriverRepository : DomainRepository<Driver>
{
    Task<List<Driver>> GetAllDrivers();
}