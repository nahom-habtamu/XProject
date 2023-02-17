using domain.common;
using domain.vehicle;

public class VehicleRepositoryImpl : VehicleRepository
{
    List<Vehicle> vehicles = new List<Vehicle>{
        new Vehicle(
            "001","1","1","Addis Ababa","TYPE","LOAD_TYPE", DateTime.Now,"SOMEMAKE","SomeModel","High","Black",
            new PersonId(new List<Uri>{
                new Uri("https://www.google.com"),
                new Uri("https://www.google.com")
            }),
            new Uri("https://www.google.com"),
            new Uri("https://www.google.com"),
            new Uri("https://www.google.com"),
            DateTime.Now,
            DateTime.Now
        ),
        new Vehicle(
            "002","2","2","Addis Ababa","TYPE","LOAD_TYPE", DateTime.Now,"SOMEMAKE","SomeModel","High","Black",
            new PersonId(new List<Uri>{
                new Uri("https://www.google.com"),
                new Uri("https://www.google.com")
            }),
            new Uri("https://www.google.com"),
            new Uri("https://www.google.com"),
            new Uri("https://www.google.com"),
            DateTime.Now,
            DateTime.Now
        ),
        new Vehicle(
            "003","3","3","Addis Ababa","TYPE","LOAD_TYPE", DateTime.Now,"SOMEMAKE","SomeModel","High","Black",
            new PersonId(new List<Uri>{
                new Uri("https://www.google.com"),
                new Uri("https://www.google.com")
            }),
            new Uri("https://www.google.com"),
            new Uri("https://www.google.com"),
            new Uri("https://www.google.com"),
            DateTime.Now,
            DateTime.Now
        ),
        new Vehicle(
            "004","4","4","Addis Ababa","TYPE","LOAD_TYPE", DateTime.Now,"SOMEMAKE","SomeModel","High","Black",
            new PersonId(new List<Uri>{
                new Uri("https://www.google.com"),
                new Uri("https://www.google.com")
            }),
            new Uri("https://www.google.com"),
            new Uri("https://www.google.com"),
            new Uri("https://www.google.com"),
            DateTime.Now,
            DateTime.Now
        ),
        new Vehicle(
            "005","5","5","Addis Ababa","TYPE","LOAD_TYPE", DateTime.Now,"SOMEMAKE","SomeModel","High","Black",
            new PersonId(new List<Uri>{
                new Uri("https://www.google.com"),
                new Uri("https://www.google.com")
            }),
            new Uri("https://www.google.com"),
            new Uri("https://www.google.com"),
            new Uri("https://www.google.com"),
            DateTime.Now,
            DateTime.Now
        ),
        new Vehicle(
            "006","6","6","Addis Ababa","TYPE","LOAD_TYPE", DateTime.Now,"SOMEMAKE","SomeModel","High","Black",
            new PersonId(new List<Uri>{
                new Uri("https://www.google.com"),
                new Uri("https://www.google.com")
            }),
            new Uri("https://www.google.com"),
            new Uri("https://www.google.com"),
            new Uri("https://www.google.com"),
            DateTime.Now,
            DateTime.Now
        )
    };

    public Task<Vehicle?> Get(string id)
    {
        return Task.Run(() => vehicles.FirstOrDefault(v => v.Id.Equals(id)));
    }

    public Task<List<string>> GetAllPlateNumbers()
    {
        return Task.Run(() => vehicles.Select(v => v.PlateNumber).ToList());
    }

    public Task<List<Vehicle>> GetAllVehicles()
    {
        return Task.Run(() => vehicles.ToList());
    }

    public Task<List<Vehicle>> GetVehiclesByDriver(string id)
    {
        return Task.Run(() => vehicles.Where(v => v.DriverId.Equals(id)).ToList());
    }

    public Task<List<Vehicle>> GetVehiclesByOwner(string id)
    {
        return Task.Run(() => vehicles.Where(v => v.OwnerId.Equals(id)).ToList());
    }

    public Task Save(Vehicle entity)
    {
        throw new NotImplementedException();
    }
}