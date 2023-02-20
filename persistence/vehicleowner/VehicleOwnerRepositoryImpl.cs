using domain.common;
using domain.vehicleowner;

public class VehicleOwnerRepositoryImpl : VehicleOwnerRepository
{
    List<VehicleOwner> vehicleOwners = new List<VehicleOwner> {
        new VehicleOwner("Nahom", new MobileNumber("0926849888"),"nahom@gmail.com", "Abebe PLC", new Uri("https://learn.microsoft.com/en-us/aspnet/core/mvc/controllers/routing?view=aspnetcore-7.0"), "naHom","password"),
        new VehicleOwner("Nahom1", new MobileNumber("0926849888"),"nahom@gmail1.com", "Abebe PLC1", new Uri("https://learn.microsoft.com/en-us/aspnet/core/mvc/controllers/routing?view=aspnetcore-7.0"), "naHom1","password1"),
        new VehicleOwner("Nahom2", new MobileNumber("0926849888"),"nahom@gmail2.com", "Abebe PLC2", new Uri("https://learn.microsoft.com/en-us/aspnet/core/mvc/controllers/routing?view=aspnetcore-7.0"), "naHom2","password2"),
        new VehicleOwner("Nahom3", new MobileNumber("0926849888"),"nahom@gmail3.com", "Abebe PLC3", new Uri("https://learn.microsoft.com/en-us/aspnet/core/mvc/controllers/routing?view=aspnetcore-7.0"), "naHom3","password3"),
    };

    public Task<VehicleOwner?> Get(string id)
    {
        throw new NotImplementedException();
    }

    public Task<List<VehicleOwner>> GetAllVehicleOwners()
    {
        return Task.Run(() => vehicleOwners.ToList());
    }

    public Task Save(VehicleOwner entity)
    {
        throw new NotImplementedException();
    }
}