using domain.vehicle;
using Microsoft.AspNetCore.Mvc;

namespace web.endpoints.vehicle;

[ApiController]
public class GetAllVehiclesController : ControllerBase
{
    private readonly VehicleRepository _repository;

    public GetAllVehiclesController(
        VehicleRepository repository
    )
    {
        _repository = repository;
    }

    [HttpGet]
    [Route("[controller]")]
    public async Task<List<Vehicle>> Call()
    {
        return await _repository.GetAllVehicles();
    }
}
