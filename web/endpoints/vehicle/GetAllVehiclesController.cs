using domain.vehicle;
using Microsoft.AspNetCore.Mvc;

namespace web.endpoints.vehicle;

[ApiController]
public class GetAllVehiclesController : ControllerBase
{
    private readonly VehicleRepository _repository;
    private readonly ILogger<GetAllVehiclesController> _logger;

    public GetAllVehiclesController(
        ILogger<GetAllVehiclesController> logger,
        VehicleRepository repository
    )
    {
        _logger = logger;
        _repository = repository;
    }

    [HttpGet]
    [Route("[controller]")]
    public async Task<List<Vehicle>> Call()
    {
        return await _repository.GetAllVehicles();
    }
}
