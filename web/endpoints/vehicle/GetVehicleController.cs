using domain.vehicle;
using Microsoft.AspNetCore.Mvc;

namespace web.endpoints.vehicle;

[ApiController]
public class GetVehicleController : ControllerBase
{
    private readonly VehicleRepository _vehicleRepo;

    public GetVehicleController(VehicleRepository vehicleRepo)
    {
        _vehicleRepo = vehicleRepo;
    }

    [HttpGet]
    [Route("[controller]")]
    public async Task<Vehicle> Call(string id)
    {
        var vehicle = await _vehicleRepo.Get(id);
        if (vehicle == null) throw new Exception("Vehicle With This Id Not Found");
        return vehicle;
    }
}
