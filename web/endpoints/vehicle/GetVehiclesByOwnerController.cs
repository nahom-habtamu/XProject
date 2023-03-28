using domain.vehicle;
using Microsoft.AspNetCore.Mvc;

namespace web.endpoints.vehicle;

[ApiController]
public class GetVehiclesByOwnerController : ControllerBase
{
    private readonly VehicleRepository _repository;

    public GetVehiclesByOwnerController(
        VehicleRepository repository
    )
    {
        _repository = repository;
    }

    [HttpGet]
    [Route("[controller]")]
    public async Task<List<Vehicle>> Call(string ownerId)
    {
        return await _repository.GetVehiclesByOwner(ownerId);
    }
}
