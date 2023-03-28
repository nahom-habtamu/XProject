using domain.vehicle;
using Microsoft.AspNetCore.Mvc;

namespace web.endpoints.vehicle;

[ApiController]
public class GetVehiclesByDriverController : ControllerBase
{
    private readonly VehicleRepository _repository;

    public GetVehiclesByDriverController(
        VehicleRepository repository
    )
    {
        _repository = repository;
    }

    [HttpGet]
    [Route("[controller]")]
    public async Task<List<Vehicle>> Call(string driverId)
    {
        return await _repository.GetVehiclesByDriver(driverId);
    }
}
